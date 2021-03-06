﻿using PCLStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCLStorage
{
    public static class FileExtensions
    {
        public static async Task<IFile> SaveByteArrayToThisFile(this IFile file, byte[] byteArray)
        {
            using (var fileHandler = await file.OpenAsync(FileAccess.ReadAndWrite))
            {
                await fileHandler.WriteAsync(byteArray, 0, byteArray.Length);
            }

            return file;
        }

    }
}
