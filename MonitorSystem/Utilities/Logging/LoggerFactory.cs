using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonitorSystem.Unilities.Logging
{
    public static class LoggerFactory
    {
        private static readonly Dictionary<string, ILogger> _loggerDictionary;
        private static LoggerLevel _level;
        private static object _thisObject;
        private static Type _type;

        static LoggerFactory()
        {
            _loggerDictionary = new Dictionary<string, ILogger>(StringComparer.OrdinalIgnoreCase);
            _level = LoggerLevel.Debug;
            _thisObject = new object();
        }

        internal static ILogger GetLogger(string channel)
        {
            if (!_loggerDictionary.ContainsKey(channel))
            {
                var logger = CreateLogger(channel);
                logger.SetLoggerLevel(_level);
                lock (_thisObject)
                {
                    _loggerDictionary.Add(channel, logger);
                }
                return logger;
            }
            return _loggerDictionary[channel];
        }

        private static ILogger CreateLogger(string channel)
        {
            if (null == _type)
            {
                try
                {
                    return (ILogger)Activator.CreateInstance(_type, channel);
                }
                catch
                {
                    return new Logger(channel);
                }
            }
            return new Logger(channel);
        }

        public static void SetLoggerLevel(LoggerLevel level)
        {
            _level = level;
            lock (_thisObject)
            {
                if (_loggerDictionary.Count > 0)
                {
                    foreach (var dict in _loggerDictionary)
                    {
                        dict.Value.SetLoggerLevel(level);
                    }
                }
            }
        }

        public static void SetLoggerInstance(Type type) 
        {
            if (!type.IsClass)
            {
                throw new ArgumentException("Type must be a class.");
            }
            if (!(type is ILogger))
            {
                throw new ArgumentException("Type must be from ILogger interfaces inherited.");
            }
            var constructors = type.GetConstructors(System.Reflection.BindingFlags.Public);
            foreach (var constructor in constructors)
            {
                var parameters = constructor.GetParameters();
                if (parameters.Length == 1 && parameters[0].ParameterType == typeof(string))
                {
                    _type = type;
                    _loggerDictionary.Clear();
                    break;
                }
            }
            throw new ArgumentException("Type must have a string argument constructor.");
        }
    }
}
