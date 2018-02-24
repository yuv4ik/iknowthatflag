using System;
using System.IO;
using Android.App;
using IKnowThatFlag.Services;

namespace IKnowThatFlag.Droid.Services
{
    public class SqliteFileAccessHelper : ISqliteFileAccessHelper
    {
        public string GetDBFilePath(string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string dbPath = Path.Combine(path, filename);

            CopyDatabaseIfNotExists(dbPath, filename);

            return dbPath;
        }

        void CopyDatabaseIfNotExists(string dbPath, string dbFileName)
        {
            if (!File.Exists(dbPath))
            {
                using (var br = new BinaryReader(Application.Context.Assets.Open(dbFileName)))
                {
                    using (var bw = new BinaryWriter(new FileStream(dbPath, FileMode.Create)))
                    {
                        byte[] buffer = new byte[2048];
                        int length = 0;
                        while ((length = br.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            bw.Write(buffer, 0, length);
                        }
                    }
                }
            }
        }
    }
}
