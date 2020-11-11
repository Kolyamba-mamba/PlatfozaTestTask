using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace PlatfozaTestTask.API.Models
{
    public class AccountMap : ClassMapping<Account>
    {
        public AccountMap()
        {
            Table("`Account`");
            Id(x => x.Id, m => m.Generator(new GuidGeneratorDef()));
            Property(x => x.Login);
            Property(x => x.Password);
        }
    }
}