using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TesteSeusConhecimentos.Domain;
using TesteSeusConhecimentos.Entities;
using TesteSeusConhecimentos.Infra;

namespace TesteSeusConhecimentos.Web.Infocast
{
    public partial class InfoEmployee : System.Web.UI.Page
    {
        private IRepository<Enterprise> enterpriseRepository;
        private IRepository<User> userRepository;
        private EmployeeRepository employeeRepository;

        public InfoEmployee()
        {
            this.enterpriseRepository = new EnterpriseRepository();
            this.userRepository = new UserRepository();
            this.employeeRepository = new EmployeeRepository();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetEnterprises();
                GetUsers();
            }
        }

        private void GetUsers()
        {
            var users = from x in userRepository.GetAll()
                        select new{
                            x.IdUser,
                            FullName = String.Format("{0} {1}", x.Name, x.LastName)
                        };

            ddlUser.DataTextField = "FullName";
            ddlUser.DataValueField = "IdUser";
            ddlUser.DataSource = users;
            ddlUser.DataBind();
        }

        private void GetEnterprises()
        {
            var enterprises = enterpriseRepository.GetAll();
            ddlEnterprise.DataTextField = "Company";
            ddlEnterprise.DataValueField = "IdEnterprise";
            ddlEnterprise.DataSource = enterprises.ToList();
            ddlEnterprise.DataBind();
        }

        protected void btnRelacionar_Click(object sender, EventArgs e)
        {
            Enterprise enterprise = enterpriseRepository.GetById(Convert.ToInt32(ddlEnterprise.SelectedValue));
            User user = userRepository.GetById(Convert.ToInt32(ddlUser.SelectedValue));

            Employee employee = new Employee(enterprise, user);

            employeeRepository.Save(employee);

            Response.Redirect("~/Infocast/Employees.aspx");
        }
    }
}