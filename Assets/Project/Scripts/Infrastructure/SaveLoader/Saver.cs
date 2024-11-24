using Newtonsoft.Json;
using System.Collections.Generic;

namespace Project
{
    public class Saver
    {
        private readonly DataPresenter _dataPresenter;
        private readonly List<ISavable> _savables;
        private readonly ISaveStrategy _saveStrategy;

        public Saver(DataPresenter dataPresenter, List<ISavable> savables, ISaveStrategy saveStrategy)
        {
            _dataPresenter = dataPresenter;
            _savables = savables;
            _saveStrategy = saveStrategy;
        }

        public void Save()
        {
            Data data = _dataPresenter.Data;

            _savables.ForEach((savable) => savable.Save(data));
            
            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            _saveStrategy.Save(json);
        }

        public void Load()
        {
            Data data = _saveStrategy.TryLoad(out string json) ? JsonConvert.DeserializeObject<Data>(json) : Data.Default;
            _dataPresenter.Data = data;
            _savables.ForEach((savable) => savable.Load(data));
        }
    }
}
