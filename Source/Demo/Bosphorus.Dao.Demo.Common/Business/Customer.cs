﻿using System.Collections.Generic;

namespace Bosphorus.Dao.Demo.Common.Business
{
    public class Customer
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual IList<Account> Accounts { get; set; }
        public virtual CustomerType CustomerType { get; set; }
        public virtual Account PrimaryAccount { get; set; }
    }
}