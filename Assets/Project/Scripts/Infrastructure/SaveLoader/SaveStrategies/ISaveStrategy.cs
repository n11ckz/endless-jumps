namespace Project
{
    public interface ISaveStrategy
    {
        public void Save(string json);
        public bool TryLoad(out string json);
    }
}
