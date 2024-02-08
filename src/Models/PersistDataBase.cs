using NETWorkerService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETWorkerService.Models
{
    internal class PersistDataBase : IPersistData
    {
        public IConfiguration Configuration { get; private set; }

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
