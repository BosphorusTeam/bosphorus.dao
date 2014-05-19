using Bosphorus.Dao.NHibernate.Demo.Model.Legacy;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace Bosphorus.Dao.NHibernate.Demo.Business.Dal.Legacy
{
    public class AutoMappingOverride : IAutoMappingOverride<IMPORTCARGOINFOSERVICE>
    {
        public void Override(AutoMapping<IMPORTCARGOINFOSERVICE> mapping)
        {
            mapping.Table("IMPORTCARGOINFOSERVICE");
            mapping.LazyLoad();
            mapping.Id(x => x.IMPORTCARGOINFOSERVICEID).GeneratedBy.Assigned().Column("IMPORTCARGOINFOSERVICEID");
            mapping.Map(x => x.IMPORTCARGOINFOID).Column("IMPORTCARGOINFOID").Length(16);
            mapping.Map(x => x.SERVICEID).Column("SERVICEID").Length(16);
            mapping.Map(x => x.VOLUME).Column("VOLUME").Length(22);
            mapping.Map(x => x.AUDIT_CREATE_DATE).Column("AUDIT_CREATE_DATE").Length(11);
            mapping.Map(x => x.AUDITCREATEDBY).Column("AUDITCREATEDBY").Length(22);
            mapping.Map(x => x.AUDITCREATEUNITID).Column("AUDITCREATEUNITID").Length(22);
            mapping.Map(x => x.AUDIT_MODIFY_DATE).Column("AUDIT_MODIFY_DATE").Length(11);
            mapping.Map(x => x.AUDITMODIFIEDBY).Column("AUDITMODIFIEDBY").Length(22);
            mapping.Map(x => x.AUDITMODIFYUNITID).Column("AUDITMODIFYUNITID").Length(22);
            mapping.Map(x => x.AUDIT_DELETED).Column("AUDIT_DELETED").Length(1);
            mapping.Map(x => x.APPLICATION_VERSION).Column("APPLICATION_VERSION").Length(16);
            mapping.Map(x => x.APPLICATIONID).Column("APPLICATIONID").Length(22);
            mapping.Map(x => x.FREE_OF_CHARGE).Column("FREE_OF_CHARGE").Length(1);
            mapping.Map(x => x.SERVICE_COUNT).Column("SERVICE_COUNT").Length(22);
            mapping.Map(x => x.LOVSERVICETYPEID).Column("LOVSERVICETYPEID").Length(22);
        }
    }
}
