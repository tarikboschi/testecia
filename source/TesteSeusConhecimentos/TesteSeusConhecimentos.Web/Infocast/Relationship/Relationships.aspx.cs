using System;
using System.Web.UI.WebControls;
using TesteSeusConhecimentos.Domain;
using TesteSeusConhecimentos.Infra.Repositories;

namespace TesteSeusConhecimentos.Web.Infocast.Relationship
{
    public partial class Relationships : System.Web.UI.Page
    {
        #region Properties
        private readonly IRelationshipRepository _relationshipRepository;
        private readonly IUserRepository _userRepository;
        private readonly IEnterpriseRepository _enterpriseRepository;

        public Relationships()
        {
            this._relationshipRepository = new RelationshipRepository();
            this._userRepository = new UserRepository();
            this._enterpriseRepository = new EnterpriseRepository();
        }
        #endregion

        #region Methods
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UpdateGridRelationships();
            }
        }

        protected void grdRelationships_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var idRelationship = Convert.ToInt32(e.CommandArgument);

            switch (e.CommandName)
            {
                case ("Remove"):
                    _relationshipRepository.Delete(idRelationship);
                    UpdateGridRelationships();
                    break;
                case ("Edit"):
                    Response.Redirect("~/Infocast/RelationShip/InfoRelationship.aspx?id=" + idRelationship, true);
                    break;
            }

        }


        protected void grdRelationships_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType != DataControlRowType.DataRow)
                return;

            var relationship = e.Row.DataItem as Entities.Relationship;
      
            var usuario = _userRepository.GetById(relationship.IdUser);
            var enterprise = _enterpriseRepository.GetById(relationship.IdEnterprise);

            Label UserName = (Label)e.Row.FindControl("UserName");
            Label NomeEmpresa = (Label)e.Row.FindControl("NomeEmpresa");
            Label Logradouro = (Label)e.Row.FindControl("Logradouro");

            UserName.Text = usuario.Name + " " + usuario.LastName;
            NomeEmpresa.Text = enterprise.CorporateActivity;
            Logradouro.Text = enterprise.StreetAdress + ", " + enterprise.City + ", " + enterprise.State + ", " + enterprise.ZipCode;
                
        }

        private void UpdateGridRelationships()
        {
            grdRelationships.DataSource = _relationshipRepository.GetAll();
            grdRelationships.DataBind();
        }

     
        protected void btnNovo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Infocast/Relationship/InfoRelationship.aspx");
        }
        #endregion
    }
}