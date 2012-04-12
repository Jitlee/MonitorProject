using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace MonitorSystem.Unilities.Logging
{
    internal class Logger : ILogger
    {
        private string _channel;

        private LoggerLevel _level;

        public Logger(string channel)
        {
            _channel = channel;
        }

        public void SetLoggerLevel(LoggerLevel level)
        {
            _level = level;
        }

        public void Error(string message)
        {
            if (_level != LoggerLevel.NoLog)
            {
                LogMessage(message);
            }
        }

        public void Error(string message, params object[] args)
        {
            if (_level != LoggerLevel.NoLog)
            {
                LogMessage(message, args);
            }
        }

        public void Debug(string message)
        {
            if (_level != LoggerLevel.NoLog
                && _level != LoggerLevel.Error)
            {
                LogMessage(message);
            }
        }

        public void Debug(string message, params object[] args)
        {
            if (_level != LoggerLevel.NoLog
                && _level != LoggerLevel.Error)
            {
                LogMessage(message, args);
            }
        }

        public void Trance(string message)
        {
            if (_level != LoggerLevel.NoLog
                && _level != LoggerLevel.Error
                && _level != LoggerLevel.Debug)
            {
                LogMessage(message);
            }
        }

        public void Trance(string message, params object[] args)
        {
            if (_level != LoggerLevel.NoLog
                && _level != LoggerLevel.Error
                && _level != LoggerLevel.Debug)
            {
                LogMessage(message, args);
            }
        }

        private void LogMessage(string message)
        {
            Console.WriteLine(string.Format("<{0}> <{1}> <{2}> {3}",
                DateTime.Now.ToString("mm:ss"),
                _channel,
                _level,
                message));
        }

        private void LogMessage(string message, params object[] args)
        {
            Console.WriteLine(string.Format(
                string.Format("<{0}> <{1}> <{2}> {3}",
                   DateTime.Now.ToString("mm:ss"),
                   _channel,
                   _level,
                   message), args));
        }
    }
}
