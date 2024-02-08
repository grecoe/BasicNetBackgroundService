namespace NETWorkerService.Interfaces
{
    public interface IPersistData
    {
        IConfiguration Configuration { get;  }
        
        string Name { get; }

        void PersistData(string data);
        void SaveData(string data);
        void DeleteData(string data);

    }
}
