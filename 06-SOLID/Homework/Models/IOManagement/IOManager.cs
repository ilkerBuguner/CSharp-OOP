using Logger.Models.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Logger.Models.IOManagement
{
    public class IOManager : IIOManager
    {
        private string currentPath;
        private string currentDirectory;
        private string currentFile;

        public IOManager(string currentDirectory, string currentFile)
        {
            this.currentPath = GetCurentPath();
            this.currentDirectory = currentDirectory;
            this.currentFile = currentFile;
        }
        public string CurrentDirectoryPath => this.currentPath + this.currentDirectory;

        public string CurrentFilePath => CurrentDirectoryPath + currentFile;

        public void EnsureDirectoryAndFileExist()
        {
            if (!Directory.Exists(CurrentDirectoryPath))
            {
                Directory.CreateDirectory(this.CurrentDirectoryPath);
            }

            File.WriteAllText(CurrentFilePath, "");
        }

        public string GetCurentPath()
        {
            return Directory.GetCurrentDirectory();
        }
    }
}
