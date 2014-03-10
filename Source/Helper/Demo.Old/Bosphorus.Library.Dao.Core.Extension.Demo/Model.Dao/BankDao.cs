using System;
using System.Collections.Generic;
using System.Text;
using Bosphorus.Library.Dao.Core.Extension.Demo.Model.Core;
using Bosphorus.Library.Dao.Core.Model.Dao;
using Bosphorus.Library.Dao.Core.Extension.Demo.Model.Session;

namespace Bosphorus.Library.Dao.Core.Extension.Demo.Model.Dao
{
    public class BankDao: IDao<Bank>
    {
        public void Delete(Bank entity)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public IList<Bank> GetAll()
        {
            IList<Bank> list = new List<Bank>();
            list.Add(new Bank());
            list.Add(new Bank());
            list.Add(new Bank());
            list.Add(new Bank());

            return list;
        }

        public void Delete(IEnumerable<Bank> entities)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public IList<Bank> GetByCriteria(params object[] criterions)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public Bank GetById<TId>(TId id)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public IList<TReturnType> GetByNamedQuery<TReturnType>(string queryName, params object[] parameters)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public IList<Bank> GetByNamedQuery(string queryName, params object[] parameters)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public IList<TReturnType> GetByQuery<TReturnType>(string queryString, params object[] parameters)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public IList<Bank> GetByQuery(string queryString, params object[] parameters)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public Bank LoadById(object id)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public Bank LoadById<TId>(TId id)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public IEnumerable<Bank> Save(IEnumerable<Bank> entities)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public Bank Save(Bank entity)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public IEnumerable<Bank> SaveOrUpdate(IEnumerable<Bank> entities)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public Bank SaveOrUpdate(Bank entity)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public Bosphorus.Library.Dao.Core.Model.Session.ISession Session
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public IEnumerable<Bank> Update(IEnumerable<Bank> entities)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public Bank Update(Bank entity)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
