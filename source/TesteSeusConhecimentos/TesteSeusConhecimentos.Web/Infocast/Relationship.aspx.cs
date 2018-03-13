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
    public partial class Relationship : System.Web.UI.Page
    {
        private IEnterpriseXUserRepository enterpriseXUserRepository;

        public Relationship()
        {
            this.enterpriseXUserRepository = new EnterpriseXUserRepository();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UpdateGridEnterprisesXUsers();
            }
        }

        private void UpdateGridEnterprisesXUsers()
        {
            IList<EnterpriseXUser> lista = enterpriseXUserRepository.GetAll();
            grdRelationship.DataSource = lista.ToList();
            grdRelationship.DataBind();
        }

        protected void grdEnterprisesXUser_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int idEnterpriseXUser = Convert.ToInt32(e.CommandArgument);

            switch (e.CommandName)
            {
                case ("Remove"):
                    enterpriseXUserRepository.Delete(idEnterpriseXUser);
                    UpdateGridEnterprisesXUsers();
                    break;
                case ("Edit"):
                    Response.Redirect("~/Infocast/InfoRelationship.aspx?id=" + idEnterpriseXUser, true);
                    break;
            }

        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Infocast/InfoRelationship.aspx");
        }
    }
}