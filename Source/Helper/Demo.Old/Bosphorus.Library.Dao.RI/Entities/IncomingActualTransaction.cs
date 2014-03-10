using System;
using System.Collections;
using System.Collections.Generic;

namespace Bosphorus.Library.Dao.RI.Entities
{
	public partial class IncomingActualTransaction
	{
		protected int txnNo;
		protected int matchRef;
        protected int srcNo;
		protected string srcRef;
		protected string srcExData;
		protected string senderId;
		protected int? senderBankNo;
		protected string senderAccNo;
		protected string benId;
		protected int? benBankNo;
		protected string benAccNo;
		protected decimal amount;
		protected string ccyId;
		protected DateTime? txnDt;
		protected DateTime? transDt;
		protected int internall;
		protected int deleted;
		
		public IncomingActualTransaction()
		{
		}

        public virtual int TxnNo
		{
			get { return txnNo; }
			set { txnNo = value; }
		}
		
		public virtual int MatchRef
		{
			get { return matchRef; }
			set { matchRef = value; }
		}
		
		public virtual int SrcNo
		{
			get { return srcNo; }
			set { srcNo = value; }
		}
		
		public virtual string SrcRef
		{
			get { return srcRef; }
			set { srcRef = value; }
		}
		
		public virtual string SrcExData
		{
			get { return srcExData; }
			set { srcExData = value; }
		}
		
		public virtual string SenderId
		{
			get { return senderId; }
			set { senderId = value; }
		}
		
		public virtual int? SenderBankNo
		{
			get { return senderBankNo; }
			set { senderBankNo = value; }
		}
		
		public virtual string SenderAccNo
		{
			get { return senderAccNo; }
			set { senderAccNo = value; }
		}
		
		public virtual string BenId
		{
			get { return benId; }
			set { benId = value; }
		}
		
		public virtual int? BenBankNo
		{
			get { return benBankNo; }
			set { benBankNo = value; }
		}
		
		public virtual string BenAccNo
		{
			get { return benAccNo; }
			set { benAccNo = value; }
		}
		
		public virtual decimal Amount
		{
			get { return amount; }
			set { amount = value; }
		}
		
		public virtual string CcyId
		{
			get { return ccyId; }
			set { ccyId = value; }
		}
		
		public virtual DateTime? TxnDt
		{
			get { return txnDt; }
			set { txnDt = value; }
		}
		
		public virtual DateTime? TransDt
		{
			get { return transDt; }
			set { transDt = value; }
		}
		
		public virtual int Internal
		{
			get { return internall; }
			set { internall = value; }
		}

        public virtual int Deleted
		{
			get { return deleted; }
			set { deleted = value; }
		}
    }
}
