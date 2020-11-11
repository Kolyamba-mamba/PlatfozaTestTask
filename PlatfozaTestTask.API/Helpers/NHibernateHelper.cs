using System.Reflection;
using Microsoft.Extensions.Configuration;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Mapping.ByCode;
using NHibernate.Tool.hbm2ddl;

namespace PlatfozaTestTask.API.Helpers
{
    public class NHibernateHelper
    {
        private ISessionFactory _sessionFactory;
        private readonly IConfiguration _configuration;

        public NHibernateHelper(IConfiguration configuration) => 
            _configuration = configuration;

        private ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory != null) return _sessionFactory;
                var cfg = new Configuration()
                    .DataBaseIntegration(db => {
                        db.ConnectionString = _configuration.GetSection("DbConnection").Value; //потом получать из appsettings 
                        db.Dialect<MsSql2008Dialect>();
                    });
                var mapper = new ModelMapper();
                mapper.AddMappings(Assembly.GetExecutingAssembly().GetExportedTypes());
                HbmMapping mapping = mapper.CompileMappingForAllExplicitlyAddedEntities();
                cfg.AddMapping(mapping);
                new SchemaUpdate(cfg).Execute(true, true);
                _sessionFactory = cfg.BuildSessionFactory();
                return _sessionFactory;
            }
        }

        public ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}