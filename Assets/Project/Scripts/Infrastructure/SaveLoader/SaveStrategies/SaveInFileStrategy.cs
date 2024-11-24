using System.IO;
using UnityEngine;

namespace Project
{
    public class SaveInFileStrategy : ISaveStrategy
    {
        private const string FileName = "SavedData.json";

        private readonly string _path = Path.Combine(Application.persistentDataPath, FileName);

        public void Save(string json)
        {
            using StreamWriter streamWriter = File.CreateText(_path);
            streamWriter.Write(json);
        }

        public bool TryLoad(out string json)
        {
            json = string.Empty;

            if (!File.Exists(_path))
                return false;

            using StreamReader streamReader = File.OpenText(_path);
            json = streamReader.ReadToEnd();

            return true;
        }
    }
}
