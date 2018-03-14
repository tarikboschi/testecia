using System;
using TesteSeusConhecimentos.Domain;
using TesteSeusConhecimentos.Infra.Repositories;

namespace TesteSeusConhecimentos.Web.Infocast.Relationship
{
    public partial class InfoRelationship : System.Web.UI.Page
    {
        #region Properties
        private readonly IUserRepository _userRepository;
        private readonly IEnterpriseRepository _enterpriseRepository;
        private readonly IRelationshipRepository _relationshipRepository;



        public InfoRelationship()
        {
            this._userRepository = new UserRepository();
            this._enterpriseRepository = new EnterpriseRepository();
            this._relationshipRepository = new RelationshipRepository();
        }
        #endregion

        #region Methods
        private int idRelationship
        {
            set { ViewState["idRelationship"] = value; }
            get
            {
                return ViewState["idRelationship"] != null ? Convert.ToInt32(ViewState["idRelationship"]) : 0;
            }
        }



        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (IsPostBack) return;
                SetViewStateRelationship();
                UpdateForm();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }

        }

        private void SetViewStateRelationship()
        {
            idRelationship = Request.QueryString["id"] != null ? Convert.ToInt32(Request.QueryString["id"]) : 0;
        }

        private void UpdateForm()
        {
            try
            {
                var relationship = _relationshipRepository.GetById(idRelationship);
                if (relationship == null)
                {
                    InitializeDropDowns();
                }

                formStatus.InnerText = "Editar Relacionamento";

                var users = _userRepository.GetAll();
                var enterprises = _enterpriseRepository.GetAll();

                ddlUser.DataSource = users;
                ddlEnterprise.DataSource = enterprises;

                ddlUser.DataBind();
                ddlEnterprise.DataBind();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        private void InitializeDropDowns()
        {
            ddlUser.Items.Add("Selecione...");
            ddlUser.Items[0].Value = "0";
            ddlUser.Items[0].Selected = true;

            ddlEnterprise.Items.Add("Selecione...");
            ddlEnterprise.Items[0].Value = "0";
            ddlEnterprise.Items[0].Selected = true;
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            var relationship = new Entities.Relationship(idRelationship
                                                        , Convert.ToInt32(ddlUser.SelectedValue)
                                                        , Convert.ToInt32(ddlEnterprise.SelectedValue));
            _relationshipRepository.Save(relationship);

            Response.Redirect("~/Infocast/RelationShip/Relationships.aspx");
        }

        #endregion
    }
}
