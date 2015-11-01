using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace qPatterns.Core.Repository.NH
{
    public class NHibernateMicrosoftSqlServerHelper<T>
    {
        private readonly string _connectionString;
        private ISessionFactory _sessionFactory;

        public ISessionFactory SessionFactory()
        {
            return _sessionFactory ?? (_sessionFactory = CreateSessionFactory());
        }

        public NHibernateMicrosoftSqlServerHelper(string connectionString)
        {
            _connectionString = connectionString;
        }

        private ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(_connectionString))
                .Mappings(m => m.FluentMappings.Add(typeof(T))) 
                .BuildSessionFactory(); 
        }

        private ISessionFactory CreateSessionFactoryWithBuildSchema()
        {
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(_connectionString))
                .Mappings(m => m.FluentMappings.Add(typeof(T)))
                .ExposeConfiguration(BuildSchema)
                .BuildSessionFactory();
        }

        private void BuildSchema(NHibernate.Cfg.Configuration cfg)
        {
            new SchemaExport(cfg).Create(false, true);
        }
    }
}
