using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System.Configuration;
using TesteSeusConhecimentos.Entities.Mapping;

namespace TesteSeusConhecimentos.Entities
{
    public class FluentSessionFactory
    {
        private static ISessionFactory session;
        private static string connectionString = ConfigurationManager.ConnectionStrings["Conexao"].ConnectionString;

        public static ISessionFactory criarSession()
        {
            if (session != null) return session;
            IPersistenceConfigurer configDB = MsSqlConfiguration.MsSql2012.ConnectionString(connectionString);

            var configMap = Fluently.Configure().Database(configDB)
                .Mappings(c => c.FluentMappings.AddFromAssemblyOf<UserMap>())
                .Mappings(c => c.FluentMappings.AddFromAssemblyOf<EnterpriseMap>())
                .Mappings(c => c.FluentMappings.AddFromAssemblyOf<RelationshipMap>())
                .ExposeConfiguration(c => new SchemaUpdate(c).Execute(false, true));

            session = configMap.BuildSessionFactory();
            return session;
        }

        public static ISession abrirSession()
        {
            return criarSession().OpenSession();
        }
    }
}