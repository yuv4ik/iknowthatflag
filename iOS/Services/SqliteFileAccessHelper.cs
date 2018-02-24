using System;
using System.IO;
using Foundation;
using IKnowThatFlag.Services;

namespace IKnowThatFlag.iOS.Services
{
    public class SqliteFileAccessHelper : ISqliteFileAccessHelper
    {
        public string GetDBFilePath(string filename)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            string dbPath = Path.Combine(libFolder, filename);

            CopyDatabaseIfNotExists(dbPath, filename);

            return dbPath;
        }

        void CopyDatabaseIfNotExists(string dbPath, string dbFileNameWithExtension)
        {
            if (!File.Exists(dbPath))
            {
                var dbFileNameSegments = dbFileNameWithExtension.Split('.');
                var existingDb = NSBundle.MainBundle.PathForResource(dbFileNameSegments[0], dbFileNameSegments[1]);
                File.Copy(existingDb, dbPath);
            }
        }
    }
}
