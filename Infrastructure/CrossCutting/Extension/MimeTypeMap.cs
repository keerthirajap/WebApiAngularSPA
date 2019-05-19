using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CrossCutting.Extension
{
    public static class MimeTypeMap
    {
        /// <summary>
        /// Retrieves the MimeType bound to the given filename or extension by looking into the Windows Registry entries.
        /// NOTE: This method supports only the MimeTypes registered in the server OS / Windows installation.
        /// </summary>
        /// <param name="fileNameOrExtension">a valid filename (file.txt) or extension (.txt or txt)</param>
        /// <returns>A valid Mime Type (es. text/plain)</returns>
        public static string GetMimeTypeByWindowsRegistry(string fileNameOrExtension)
        {
            var types = GetMimeTypes();
            var ext = System.IO.Path.GetExtension(fileNameOrExtension).ToLowerInvariant();
            return types[ext];
        }

        private static string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = System.IO.Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        private static Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"},
                {".pgp", "text/pgp"},
            };
        }
    }
}