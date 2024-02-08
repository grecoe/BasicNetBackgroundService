namespace NETWorkerService.Interfaces
{
    public interface IPersistData
    {
        IConfiguration Configuration { get;  }


        void PersistData(string data);
        void SaveData(string data);
        void DeleteData(string data);

    }
}
