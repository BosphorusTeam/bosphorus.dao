using System;
using System.Collections.Generic;
using System.Text;
using Bosphorus.Library.Dao.Core.Model.Dao;
using Bosphorus.Library.Dao.Core.Extension.Demo.Model.Core;
using Bosphorus.Library.Dao.Core.Extension.Demo.Model.Session;

namespace Bosphorus.Library.Dao.Core.Extension.Demo.Model.Dao
{
    public class CustomerDao: IDao<Customer>
    {
        public void Delete(IEnumerable<Customer> entities)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Delete(Customer entity)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public IList<Customer> GetAll()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public IList<Customer> GetByCriteria(params object[] criterions)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public Customer GetById<TId>(TId id)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public IList<TReturnType> GetByNamedQuery<TReturnType>(string queryName, params object[] parameters)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public IList<Customer> GetByNamedQuery(string queryName, params object[] parameters)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public IList<TReturnType> GetByQuery<TReturnType>(string queryString, params object[] parameters)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public IList<Customer> GetByQuery(string queryString, params object[] parameters)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public Customer LoadById(object id)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public Customer LoadById<TId>(TId id)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public IEnumerable<Customer> Save(IEnumerable<Customer> entities)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public Customer Save(Customer entity)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public IEnumerable<Customer> SaveOrUpdate(IEnumerable<Customer> entities)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public Customer SaveOrUpdate(Customer entity)
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

        public IEnumerable<Customer> Update(IEnumerable<Customer> entities)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public Customer Update(Customer entity)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
