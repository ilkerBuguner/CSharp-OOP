using MXGP.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Repositories
{
    public class Repository<T> : IRepository<T>
    {
        protected List<T> entities;
        public Repository()
        {
            entities = new List<T>();
        }
        public void Add(T model)
        {
            entities.Add(model);
        }

        public IReadOnlyCollection<T> GetAll()
        {
            return entities.AsReadOnly();
        }

        public virtual T GetByName(string name)
        {
            return entities.FirstOrDefault();
        }

        public bool Remove(T model)
        {
            if (entities.Contains(model))
            {
                entities.Remove(model);
                return true;
            }

            return false;
        }
    }
}
