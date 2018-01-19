using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TesteSeusConhecimentos.Domain;
using TesteSeusConhecimentos.Infra;

namespace TesteSeusConhecimentos.Web.Infocast
{
    public partial class Companies : System.Web.UI.Page
    {
        private ICompanyRepository companyRepository;

        public Companies()
        {
            this.companyRepository = new CompanyRepository();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UpdateGridCompanies();
            }
        }

        protected void grdCompanies_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int idCompany = Convert.ToInt32(e.CommandArgument);

            switch (e.CommandName)
            {
                case ("Remove"):
                    companyRepository.Delete(idCompany);
                    UpdateGridCompanies();
                    break;
                case ("Edit"):
                    Response.Redirect("~/Infocast/InfoCompany.aspx?id=" + idCompany, true);
                    break;
            }
           
        }

        private void UpdateGridCompanies()
        {
            var Companies = companyRepository.GetAll();
            grdCompanies.DataSource = Companies.ToList();
            grdCompanies.DataBind();
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Infocast/InfoCompany.aspx");
        }
    }
}