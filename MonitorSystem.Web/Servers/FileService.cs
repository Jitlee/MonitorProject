namespace MonitorSystem.Web.Servers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;
    using System.IO;
    using System.Drawing;
    using System.Text.RegularExpressions;
    using System.Runtime.Serialization;
    using Microsoft.VisualBasic;

    // TODO: Create methods containing your application logic.
    [EnableClientAccess()]
    public class FileService : DomainService
    {
        [Query]
        public IEnumerable<FileModel> GetImages(string path, FileOption fileOption)
        {
            var root = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Upload");
            var length = root.Length;
            var physicalPath = Path.Combine(root, path.Trim('\\'));
            if (!Directory.Exists(physicalPath))
            {
                Directory.CreateDirectory(physicalPath);
            }
            var rootDirectoryInfo = new DirectoryInfo(physicalPath);
            if (fileOption != FileOption.File)
            {
                var directoryInfos = rootDirectoryInfo.GetDirectories();
                foreach (var directoryInfo in directoryInfos)
                {
                    yield return new FileModel()
                    {
                        Url = "Directory",
                        Name = directoryInfo.Name,
                        DisplayName = directoryInfo.Name,
                        CreationTime = directoryInfo.CreationTime,
                        ModifyTime = directoryInfo.LastWriteTime,
                        IsDirectory = true,
                        DirectoryName = directoryInfo.Parent.FullName.Remove(0, length),
                    };
                }
            }

            if (fileOption != FileOption.Directory)
            {
                var fileInfos = rootDirectoryInfo.GetFiles("*.jpg").Union(rootDirectoryInfo.GetFiles("*.png"));
                foreach (var fileInfo in fileInfos)
                {
                    using (var pic = Image.FromFile(fileInfo.FullName))
                    {
                        yield return new FileModel()
                        {
                            Url = fileInfo.FullName.Remove(0, length).Replace("\\", "/").Trim('/'),
                            Name = fileInfo.Name,
                            DisplayName = fileInfo.Name,
                            FileSize = fileInfo.Length,
                            CreationTime = fileInfo.CreationTime,
                            ModifyTime = fileInfo.LastWriteTime,
                            Height = pic.Height,
                            Width = pic.Width,
                            DirectoryName = fileInfo.DirectoryName.Remove(0, length),
                        };
                    }
                }
            }
        }

        public IEnumerable<FileModel> SearchFiles(string searchPattern, FileOption fileOption)
        {
            var root = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Upload");
            var length = root.Length;
            var physicalPath = root;
            if (!Directory.Exists(physicalPath))
            {
                Directory.CreateDirectory(physicalPath);
            }

            var rootDirectoryInfo = new DirectoryInfo(physicalPath); if (fileOption != FileOption.File)
            {
                var directoryInfos = rootDirectoryInfo.GetDirectories(searchPattern, SearchOption.AllDirectories);
                foreach (var directoryInfo in directoryInfos)
                {
                    yield return new FileModel()
                    {
                        Url = "Directory",
                        Name = directoryInfo.Name,
                        DisplayName = directoryInfo.Name,
                        CreationTime = directoryInfo.CreationTime,
                        ModifyTime = directoryInfo.LastWriteTime,
                        IsDirectory = true,
                        DirectoryName = directoryInfo.Parent.FullName.Remove(0, length),
                    };
                }
            }

            if (fileOption != FileOption.Directory)
            {
                var fileInfos = rootDirectoryInfo.GetFiles(searchPattern, fileOption != FileOption.File ?  SearchOption.AllDirectories : SearchOption.TopDirectoryOnly).Where(
                    file => string.Compare("*.jpg", file.Extension, true) == 0 || string.Compare("*.png", file.Extension, true) == 0
                    );
                foreach (var fileInfo in fileInfos)
                {
                    using (var pic = Image.FromFile(fileInfo.FullName))
                    {
                        yield return new FileModel()
                        {
                            Url = fileInfo.FullName.Remove(0, length).Replace("\\", "/").Trim('/'),
                            Name = fileInfo.Name,
                            DisplayName = fileInfo.Name,
                            FileSize = fileInfo.Length,
                            CreationTime = fileInfo.CreationTime,
                            ModifyTime = fileInfo.LastWriteTime,
                            Height = pic.Height,
                            Width = pic.Width,
                            DirectoryName = fileInfo.DirectoryName.Remove(0, length),
                        };
                    }
                }
            }
        }

        public int UploadFile(string path, string fileName, byte[] buffer, bool createNew)
        {
            try
            {
                var length = AppDomain.CurrentDomain.BaseDirectory.Length;
                var physicalPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Upload", path.Trim('\\'));
                var physicalFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Upload", path.Trim('\\'), fileName);
                if (!Directory.Exists(physicalPath))
                {
                    Directory.CreateDirectory(physicalPath);
                }
                if (createNew)
                {
                    File.Delete(physicalFileName);
                }
                if (File.Exists(physicalFileName))
                {
                    // Append
                    using (var stream = new FileStream(physicalFileName, FileMode.Append))
                    {
                        stream.Write(buffer, 0, buffer.Length);
                        stream.Flush();
                        stream.Close();
                        return 0;
                    }
                }
                else
                {
                    // New
                    using (var stream = new FileStream(physicalFileName, FileMode.CreateNew))
                    {
                        stream.Write(buffer, 0, buffer.Length);
                        stream.Flush();
                        stream.Close();
                        return 0;
                    }
                }
            }
            catch
            {
                return -1;
            }
        }

        public int DeleteFile(string path, string name)
        {
            var length = AppDomain.CurrentDomain.BaseDirectory.Length;
            var physicalPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Upload", path.Trim('\\'));
            if (Directory.Exists(physicalPath))
            {
                try
                {
                    var file = Path.Combine(physicalPath, name);
                    //File.Delete(file);
                    FileSystem.Kill(file);
                }
                catch
                {
                    return -1;
                }
            }
            return 0;
        }

        public int DeleteDirectory(string path, string name)
        {
            var length = AppDomain.CurrentDomain.BaseDirectory.Length;
            var physicalPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Upload", path.Trim('\\'));
            if (Directory.Exists(physicalPath))
            {
                try
                {
                    var directory = Path.Combine(physicalPath, name.Trim('/'));
                    if (Directory.Exists(directory))
                    {
                        Directory.Delete(directory, true);
                    }
                }
                catch
                {
                    return -1;
                }
            }
            return 0;
        }

        public int CreateDirectory(string path, string folderName)
        {
            var length = AppDomain.CurrentDomain.BaseDirectory.Length;
            var physicalPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Upload", path.Trim('\\'));
            if (Directory.Exists(physicalPath))
            {
                physicalPath = Path.Combine(physicalPath, folderName);
                if (!Directory.Exists(physicalPath))
                {
                    try
                    {
                        Directory.CreateDirectory(physicalPath);
                        return 0;
                    }
                    catch
                    {
                        return -1;
                    }
                }
                return -2;
            }
            return -3;
        }

        public int RenameFile(string path, string oldName, string newName)
        {
            var length = AppDomain.CurrentDomain.BaseDirectory.Length;
            var physicalPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Upload", path.Trim('\\'));
            if (Directory.Exists(physicalPath))
            {
                physicalPath = Path.Combine(physicalPath, oldName);

                if(File.Exists(physicalPath))
                {
                    var physicalNewPath = Path.Combine(physicalPath, newName);
                    if (File.Exists(physicalNewPath))
                    {
                        try
                        {
                            FileSystem.Rename(physicalPath, physicalNewPath);
                            return 0;
                        }
                        catch { return -4; }
                    }
                    return -3;
                }
                return -2;
            }
            return -1;
        }

        public int RenameDirectory(string path, string oldName, string newName)
        {
            var length = AppDomain.CurrentDomain.BaseDirectory.Length;
            var physicalPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Upload", path.Trim('\\'));
            if (Directory.Exists(physicalPath))
            {
                physicalPath = Path.Combine(physicalPath, oldName);

                if (Directory.Exists(physicalPath))
                {
                    var physicalNewPath = Path.Combine(physicalPath, newName);
                    if (Directory.Exists(physicalNewPath))
                    {
                        try
                        {
                            Microsoft.VisualBasic.FileIO.FileSystem.RenameDirectory(physicalPath, physicalNewPath);
                            return 0;
                        }
                        catch { return -4; }
                    }
                    return -3;
                }
                return -2;
            }
            return -1;
        }
    }

    public enum FileOption
    {
        All = 0,
        File = 1,
        Directory = 2,
    }

    [Serializable()]
    [DataContractAttribute(IsReference = true)]
    public class FileModel : INotifyPropertyChanged
    {
        private string _url;

        [Key]
        [DataMemberAttribute()]
        public string Url
        {
            get { return _url; }
            set { _url = value; RaisePorpertyChanged("Uri"); }
        }

        private string _name;

        [Key]
        [DataMemberAttribute()]
        public string Name
        {
            get { return _name; }
            set { _name = value; RaisePorpertyChanged("Name"); }
        }

        private string _displayName;

        [DataMemberAttribute()]
        public string DisplayName
        {
            get { return _displayName; }
            set { _displayName = value; RaisePorpertyChanged("DisplayName"); }
        }

        private long _fileSize;

        [DataMemberAttribute()]
        public long FileSize
        {
            get { return _fileSize; }
            set { _fileSize = value; RaisePorpertyChanged("FileSize"); }
        }
        private DateTime _modifyTime;

        [DataMemberAttribute()]
        public DateTime ModifyTime
        {
            get { return _modifyTime; }
            set { _modifyTime = value; RaisePorpertyChanged("ModifyTime"); }
        }
        private DateTime _creationTime;

        [DataMemberAttribute()]
        public DateTime CreationTime
        {
            get { return _creationTime; }
            set { _creationTime = value; RaisePorpertyChanged("CreationTime"); }
        }
        private double _height;

        [DataMemberAttribute()]
        public double Height
        {
            get { return _height; }
            set { _height = value; RaisePorpertyChanged("Height"); }
        }
        private double _width;

        [DataMemberAttribute()]
        public double Width
        {
            get { return _width; }
            set { _width = value; RaisePorpertyChanged("Width"); }
        }

        private bool _isDirectory;

        [DataMemberAttribute()]
        public bool IsDirectory
        {
            get { return _isDirectory; }
            set { _isDirectory = value; RaisePorpertyChanged("IsDirectory"); }
        }

        private string _directoryName;

        [DataMemberAttribute()]
        public string DirectoryName
        {
            get { return _directoryName; }
            set { _directoryName = value; RaisePorpertyChanged("DirectoryName"); }
        }

        private int _directoriesCount;

        [DataMemberAttribute()]
        public int DirectoriesCount
        {
            get { return _directoriesCount; }
            set { _directoriesCount = value; RaisePorpertyChanged("DirectoriesCount"); }
        }

        private int _filesCount;
        [DataMemberAttribute()]
        public int FilesCount
        {
            get { return _filesCount; }
            set { _filesCount = value; RaisePorpertyChanged("FilesCount"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePorpertyChanged(string propertyName)
        {
            if (null != PropertyChanged)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}