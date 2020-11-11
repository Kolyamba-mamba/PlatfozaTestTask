using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace PlatfozaTestTask.API.Models
{
    public class UserMap : ClassMapping<User>
    {
        public UserMap()
        {
            Table("`User`");
            Id(x => x.Id, m => m.Generator(new GuidGeneratorDef()));
            Property(x => x.Name);
            Property(x => x.BirthDate);
            Property(x => x.Amount);
            ManyToOne(x => x.Account, m => 
                m.Column("Account_Id"));
        }
    }
}