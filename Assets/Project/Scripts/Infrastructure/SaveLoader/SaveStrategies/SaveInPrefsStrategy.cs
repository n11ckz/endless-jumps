using UnityEngine;

namespace Project
{
    public class SaveInPrefsStrategy : ISaveStrategy
    {
        private const string Key = nameof(Key);

        public void Save(string json)
        {
            PlayerPrefs.SetString(Key, json);
            PlayerPrefs.Save();
        }

        public bool TryLoad(out string json)
        {
            json = PlayerPrefs.GetString(Key, string.Empty);
            return PlayerPrefs.HasKey(Key);
        }
    }
}
