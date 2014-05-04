using System;

namespace Bosphorus.Dao.NHibernate.Demo.Model.Default.Legacy {
    
    public class IMPORTCARGOINFOSERVICE {

        public virtual Guid IMPORTCARGOINFOSERVICEID { get; set; }
        public virtual Guid? IMPORTCARGOINFOID { get; set; }
        public virtual Guid? SERVICEID { get; set; }
        public virtual float? VOLUME { get; set; }
        public virtual string AUDIT_CREATE_DATE { get; set; }
        public virtual int? AUDITCREATEDBY { get; set; }
        public virtual int? AUDITCREATEUNITID { get; set; }
        public virtual string AUDIT_MODIFY_DATE { get; set; }
        public virtual int? AUDITMODIFIEDBY { get; set; }
        public virtual int? AUDITMODIFYUNITID { get; set; }
        public virtual string AUDIT_DELETED { get; set; }
        public virtual string APPLICATION_VERSION { get; set; }
        public virtual short? APPLICATIONID { get; set; }
        public virtual string FREE_OF_CHARGE { get; set; }
        public virtual short? SERVICE_COUNT { get; set; }
        public virtual short? LOVSERVICETYPEID { get; set; }
    }
}
