using System;
using System.Collections;
using System.Collections.Generic;

namespace Bosphorus.Library.Dao.RI.Entities
{
	public class Account 
	{
		protected string accNo;
		protected string baseNo;
		protected string accClass;
		protected string accDesc;
		protected decimal? openBalance;
		protected decimal? currBalance;
		protected decimal? dod;
		protected decimal? tod;
		protected decimal? confTradeTotal;
		protected string department;
		protected decimal? bondTotal;
		protected decimal? securityTotal;
		
		public Account()
		{
		}
		
		public virtual string AccNo
		{
			get { return accNo; }
			set { accNo = value; }
		}
		
		public virtual string BaseNo
		{
			get { return baseNo; }
			set { baseNo = value; }
		}
		
		public virtual string AccClass
		{
			get { return accClass; }
			set { accClass = value; }
		}
		
		public virtual string AccDesc
		{
			get { return accDesc; }
			set { accDesc = value; }
		}
		
		public virtual decimal? OpenBalance
		{
			get { return openBalance; }
			set { openBalance = value; }
		}
		
		public virtual decimal? CurrBalance
		{
			get { return currBalance; }
			set { currBalance = value; }
		}
		
		public virtual decimal? Dod
		{
			get { return dod; }
			set { dod = value; }
		}
		
		public virtual decimal? Tod
		{
			get { return tod; }
			set { tod = value; }
		}
		
		public virtual decimal? ConfTradeTotal
		{
			get { return confTradeTotal; }
			set { confTradeTotal = value; }
		}
		
		public virtual string Department
		{
			get { return department; }
			set { department = value; }
		}
		
		public virtual decimal? BondTotal
		{
			get { return bondTotal; }
			set { bondTotal = value; }
		}
		
		public virtual decimal? SecurityTotal
		{
			get { return securityTotal; }
			set { securityTotal = value; }
		}
	}
}
