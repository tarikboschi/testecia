using System;
using System.Linq;
using TesteSeusConhecimentos.Domain;
using TesteSeusConhecimentos.Entities;
using TesteSeusConhecimentos.Infra;

namespace TesteSeusConhecimentos.Web.Infocast
{
    public partial class InfoRelationship : System.Web.UI.Page
    {
        private IRelationshipRepository relationshipRepository;
        private IEnterpriseRepository enterpriseRepository;
        private IUserRepository userRepository;

        private int idRelationship
        {
            set { ViewState["idRelationship"] = value; }
            get
            {
                if (ViewState["idRelationship"] != null)
                    return Convert.ToInt32(ViewState["idRelationship"]);
                return 0;
            }
        }

        public InfoRelationship()
        {
            this.relationshipRepository = new RelationshipRepository();
            this.enterpriseRepository = new EnterpriseRepository();
            this.userRepository = new UserRepository();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregaDropDownListUsers();
                CarregaDropDownListEnterprises();
                SetViewStateRelationship();
                UpdateForm();
            }
        }

        private void CarregaDropDownListUsers()
        {
            var users = userRepository.GetAll();
            listUsers.DataTextField = "Name";
            listUsers.DataValueField = "IdUser";
            listUsers.DataSource = users.ToList();
            listUsers.DataBind();
            listUsers.Items.Insert(0, "Selecione...");
            listUsers.SelectedIndex = 0;
        }

        private void CarregaDropDownListEnterprises()
        {
            var enterprises = enterpriseRepository.GetAll();
            listEmpresa.DataTextField = "CorporateActivity";
            listEmpresa.DataValueField = "IdEnterprise";
            listEmpresa.DataSource = enterprises.ToList();
            listEmpresa.DataBind();
            listEmpresa.Items.Insert(0, "Selecione...");
            listEmpresa.SelectedIndex = 0;
        }

        private void SetViewStateRelationship()
        {
            if (Request.QueryString["id"] != null)
                idRelationship = Convert.ToInt32(Request.QueryString["id"]);
            else
                idRelationship = 0;
        }

        private void UpdateForm()
        {
            var relationship = this.relationshipRepository.GetById(idRelationship);

            if (relationship != null)
            {
                formStatus.InnerText = "Editar Empresa";
                listEmpresa.SelectedValue = relationship.Enterprise.IdEnterprise.ToString();
                listUsers.SelectedValue = relationship.User.IdUser.ToString();
            }
        }

        protected void btnRelacionar_Click(object sender, EventArgs e)
        {
            var relationship = new Relationship(idRelationship, new Enterprise { IdEnterprise = Convert.ToInt32(listEmpresa.SelectedValue) }, new User { IdUser = Convert.ToInt32(listUsers.SelectedValue) });
            relationshipRepository.Save(relationship);

            Response.Redirect("~/Infocast/Relationships.aspx");
        }
    }
}