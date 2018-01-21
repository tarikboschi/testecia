using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TesteSeusConhecimentos.Domain;

namespace TesteSeusConhecimentos.Web.Infocast
{
    public partial class Relationships : System.Web.UI.Page
    {
       private IRelationshipRepository relationshipRepository;

        public Relationships()
        {
            this.relationshipRepository = new RelationshipRepository();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UpdateGridRelationship();
            }
        }

        private void UpdateGridRelationship()
        {
            var relationships = relationshipRepository.GetAll();
            grdRelationships.DataSource = relationships.ToList();
            grdRelationships.DataBind();
        }

        protected void btnNovoRelacionamento_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Infocast/InfoRelationship.aspx");
        }

        protected void grdRelationships_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int idRelationship = Convert.ToInt32(e.CommandArgument);

            switch (e.CommandName)
            {
                case ("Remove"):
                    relationshipRepository.Delete(idRelationship);
                    UpdateGridRelationship();
                    break;
                case ("Edit"):
                    Response.Redirect("~/Infocast/InfoRelationship.aspx?id=" + idRelationship, true);
                    break;
            }
        }
    }
}