namespace NETWorkerService.Models
{
    using NETWorkerService.Interfaces;

    internal class PersistDataBase : IPersistData
    {
        public IConfiguration Configuration { get; private set; }
        public string Name { get; set; }


        public PersistDataBase(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public virtual void DeleteData(string data)
        {
            throw new NotImplementedException();
        }

        public virtual void PersistData(string data)
        {
            throw new NotImplementedException();
        }

        public virtual void SaveData(string data)
        {
            throw new NotImplementedException();
        }
    }
}
