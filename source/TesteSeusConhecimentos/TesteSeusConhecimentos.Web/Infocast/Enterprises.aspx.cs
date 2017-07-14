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
    public partial class Enterprises : System.Web.UI.Page
    {
        private IEnterpriseRepository enterpriseRep;

        public Enterprises()
        {
            this.enterpriseRep = new EnterpriseRepository();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                UpdateGridEnterprises();
        }

        private void UpdateGridEnterprises()
        {
            grdEnterprises.DataSource = enterpriseRep.GetAll().ToList();
            grdEnterprises.DataBind();
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Infocast/InfoEnterprise.aspx");
        }

        protected void grdEnterprises_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int idEnterprise = Convert.ToInt32(e.CommandArgument);

            switch (e.CommandName)
            {
                case ("Remove"):
                    enterpriseRep.Delete(idEnterprise);
                    UpdateGridEnterprises();
                    break;
                case ("Edit"):
                    Response.Redirect("~/Infocast/InfoEnterprise.aspx?id=" + idEnterprise, true);
                    break;
            }
        }
    }
}