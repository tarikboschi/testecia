using System;
using System.Web.UI.WebControls;
using TesteSeusConhecimentos.Domain;
using TesteSeusConhecimentos.Entities;
using TesteSeusConhecimentos.Infra;

namespace TesteSeusConhecimentos.Web.Infocast
{
    public partial class Relationships : System.Web.UI.Page
    {
        private RelationshipRepository<DtoBase> baseRepository;

        public Relationships()
        {
            this.baseRepository = new RelationshipRepository<DtoBase>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { UpdateForm(); }
        }

        private void UpdateForm()
        {
            var enterprise = this.baseRepository.GetAll<Enterprise>();
            ddlEnterprise.DataSource = enterprise;
            ddlEnterprise.DataTextField = "CorporateActivity";
            ddlEnterprise.DataValueField = "IdEnterprise";

            ddlEnterprise.DataBind();
            ddlEnterprise.Items.Insert(0, new ListItem("Selecione...", "-1"));

            var user = this.baseRepository.GetAll<User>();
            ddlUser.DataSource = user;
            ddlUser.DataTextField = "Name";
            ddlUser.DataValueField = "IdUser";

            ddlUser.DataBind();
            ddlUser.Items.Insert(0, new ListItem("Selecione...", "-1"));
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            var enterprise = new Relationship(ddlEnterprise.SelectedIndex, ddlUser.SelectedIndex);
            baseRepository.Save(enterprise);
            Response.Redirect("~/Infocast/Relationships.aspx");
        }
    }
}