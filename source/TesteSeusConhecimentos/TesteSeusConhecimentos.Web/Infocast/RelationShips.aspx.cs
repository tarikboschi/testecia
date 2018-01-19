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
    public partial class RelationShips : System.Web.UI.Page
    {
        private IRelationShipRepository relationshipRepository;

        public RelationShips()
        {
            this.relationshipRepository = new RelationShipRepository();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UpdateGridUsers();
            }
        }

        protected void grdUsers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { '|' });
            int idUser = Convert.ToInt32(commandArgs[0]);
            int idCompany = Convert.ToInt32(commandArgs[1]);

            switch (e.CommandName)
            {
                case ("Remove"):
                    relationshipRepository.Delete(idCompany,idUser);
                    UpdateGridUsers();
                    break;
                case ("Edit"):
                    Response.Redirect("~/Infocast/InfoRelationShip.aspx?idcompany="+idCompany+"&iduser="+idUser, true);
                    break;
            }
           
        }

        private void UpdateGridUsers()
        {
            var users = relationshipRepository.GetView();
            grdUsers.DataSource = users;
            grdUsers.DataBind();
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Infocast/InfoRelationShip.aspx");
        }
    }
}