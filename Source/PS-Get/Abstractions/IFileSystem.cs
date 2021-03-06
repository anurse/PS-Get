﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PsGet.Abstractions
{
    public interface IFileSystem
    {
        bool FileExists(string fileName);
        void DeleteFile(string fileName);
        Stream OpenFile(string fileName);
        string GetFullPath(string fileName);
        IEnumerable<string> GetAllFiles();
    }
}
