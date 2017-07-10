using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System.Configuration;

namespace TesteSeusConhecimentos.Entities
{
    public class FluentSessionFactory
    {

        private static ISessionFactory session;
        private static string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|TesteSeusConhecimentos.mdf;Integrated Security=True";

        public static ISessionFactory criarSession()
        {
            
            if (session != null)
                return session;

            IPersistenceConfigurer configDB = MsSqlConfiguration.MsSql2012.ConnectionString(connectionString);

            var configMap = Fluently.Configure().Database(configDB).Mappings(c => c.FluentMappings.AddFromAssemblyOf<Mapping.UserMap>());
            session = configMap.BuildSessionFactory();

            return session;

        }


        public static ISession abrirSession()
        {
            return criarSession().OpenSession();
        }

    }
}
