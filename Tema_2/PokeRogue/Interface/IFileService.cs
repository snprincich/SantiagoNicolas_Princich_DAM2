namespace PokeRogue.Interface
{
    public interface IFileService
    {
        public interface IFileService<T> where T : class
        {
            IEnumerable<T> Load(string filePath);
            void Save(string filePath, IEnumerable<T> contacts);
        }
    }
}
