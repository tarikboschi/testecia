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
    public partial class InfoRelationship : System.Web.UI.Page
    {
        private IEnterpriseXUserRepository enterpriseXUserRepository;
        private IEnterpriseRepository enterpriseRepository;
        private IUserRepository userRepository;

        private int idEnterpriseXUser
        {
            set { ViewState["idEnterpriseXUser"] = value; }
            get
            {
                if (ViewState["idEnterpriseXUser"] != null)
                {
                    return Convert.ToInt32(ViewState["idEnterpriseXUser"]);
                }
                return 0;
            }
        }

        public InfoRelationship()
        {
            this.userRepository = new UserRepository();
            this.enterpriseRepository = new EnterpriseRepository();
            this.enterpriseXUserRepository = new EnterpriseXUserRepository();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownDataSource();

                SetViewStateEnterprise();
                UpdateForm();
            }
        }

        private void DropDownDataSource()
        {
            ddlEnterprise.DataSource = enterpriseRepository.GetAll();
            ddlEnterprise.DataBind();

            ddlUsers.DataSource = userRepository.GetAll();
            ddlUsers.DataBind();
        }

        private void SetViewStateEnterprise()
        {
            if (Request.QueryString["id"] != null)
                idEnterpriseXUser = Convert.ToInt32(Request.QueryString["id"]);
            else
                idEnterpriseXUser = 0;
        }

        private void UpdateForm()
        {
            EnterpriseXUser obj = this.enterpriseXUserRepository.GetById(idEnterpriseXUser);
            if (obj != null)
            {
                formStatus.InnerText = "Editar Relacionamento";
                ddlEnterprise.SelectedItem.Value = Convert.ToString(obj.IdEnterprise);
                ddlUsers.SelectedItem.Value = Convert.ToString(obj.IdUser);
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            EnterpriseXUser obj = new EnterpriseXUser(idEnterpriseXUser, Convert.ToInt32(ddlEnterprise.SelectedItem.Value), Convert.ToInt32(ddlUsers.SelectedItem.Value));
            enterpriseXUserRepository.Save(obj);

            Response.Redirect("~/Infocast/Relationship.aspx");
        }
    }
}