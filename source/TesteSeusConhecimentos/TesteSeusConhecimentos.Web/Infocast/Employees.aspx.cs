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
    public partial class Employees : System.Web.UI.Page
    {
        private EmployeeRepository employeeRepository;

        public Employees()
        {
            this.employeeRepository = new EmployeeRepository();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UpdateGridEmployees();
            }

        }

        private void UpdateGridEmployees()
        {
            var employees = employeeRepository.GetAll();
            grdEmployess.DataSource = employees.ToList();
            grdEmployess.DataBind();
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Infocast/InfoEmployee.aspx");
        }

        protected void grdEmployees_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int idEnterprise = Convert.ToInt32(e.CommandArgument);

            switch (e.CommandName)
            {
                case ("Remove"):
                   // enterpriseRepository.Delete(idEnterprise);
                    UpdateGridEmployees();
                    break;
            }

        }
    }
}