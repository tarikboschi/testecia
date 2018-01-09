using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TesteSeusConhecimentos.Entities;

namespace TesteSeusConhecimentos.Infra
{
    public class EmployeeRepository
    {
        public List<Employee> GetAll()
        {
            using (ISession session = FluentSessionFactory.abrirSession())
            {
                var employees =
                 (from e in session.Query<Enterprise>()
                  from u in e.Users
                  select new Employee { Enterprise = e, User = u });

                return employees.ToList();
            }
        }

        public void Save(Employee employee)
        {
            using (ISession session = FluentSessionFactory.abrirSession())
            {
                using (ITransaction transacao = session.BeginTransaction())
                {
                    try
                    {
                        var user = session.Get<User>(1);
                        var enterprise = session.Get<Enterprise>(1);

                        user.Enterprises.Add(employee.Enterprise);
                        enterprise.Users.Add(employee.User);

                        session.Flush();
                        transacao.Commit();
                    }
                    catch (Exception e)
                    {
                        if (!transacao.WasCommitted)
                        {
                            transacao.Rollback();
                        }
                        throw new Exception("Erro ao inserir relacionamento: " + e.Message);
                    }
                }
            }
        }
    }
}
