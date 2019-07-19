using Logger.Enums;
using Logger.Models.Contracts;
using Logger.Models.IOManagement;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Logger.Models.Files
{
    public class LogFile : IFile
    {
        private const string dateFormat = "M/dd/yyyy h:mm:ss tt";

        private const string currentDirectory = "\\logs\\";
        private const string currentFile = "log.txt";

        private string currentPath;
        private IIOManager IOManager;

        public LogFile()
        {
            this.IOManager = new IOManager(currentDirectory, currentFile);
            currentPath = this.IOManager.GetCurentPath();
            IOManager.EnsureDirectoryAndFileExist();
            Path = currentPath + currentDirectory + currentFile;
        }
        public string Path { get; private set; }

        public ulong Size => GetFileSize();

        private ulong GetFileSize()
        {
            string text = File.ReadAllText(Path);

            ulong size = (ulong)text.ToCharArray().Where(c => Char.IsLetter(c)).Sum(c => (int)c);

            return size;

        }

        public string Write(ILayout layout, IError error)
        {
            string format = layout.Format;

            DateTime dateTime = error.DateTime;
            string message = error.Message;
            Level level = error.Level;

            string formattedMessage = string.Format(format
                , dateTime.ToString(dateFormat, CultureInfo.InvariantCulture)
                , level.ToString()
                , message);

            return formattedMessage;
        }
    }
}
