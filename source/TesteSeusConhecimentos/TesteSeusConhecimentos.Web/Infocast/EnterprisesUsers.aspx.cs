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
    public partial class EnterprisesUsers : System.Web.UI.Page
    {
        private IEnterpriseUserRepository enterpriseUserRepository;

        public EnterprisesUsers()
        {
            this.enterpriseUserRepository = new EnterpriseUserRepository();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UpdateGridEnterprisesUsers();
            }
        }

        protected void grdEnterprisesUsers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int idEnterpriseUser = Convert.ToInt32(e.CommandArgument);

            switch (e.CommandName)
            {
                case ("Remove"):
                    enterpriseUserRepository.Delete(idEnterpriseUser);
                    UpdateGridEnterprisesUsers();
                    break;
                case ("Edit"):
                    Response.Redirect("~/Infocast/InfoEnterpriseUser.aspx?id=" + idEnterpriseUser, true);
                    break;
            }

        }

        private void UpdateGridEnterprisesUsers()
        {
            var enterprisesUsers = enterpriseUserRepository.GetAll();
            grdEnterprisesUsers.DataSource = enterprisesUsers.ToList();
            grdEnterprisesUsers.DataBind();
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Infocast/InfoEnterpriseUser.aspx");
        }
    }
}