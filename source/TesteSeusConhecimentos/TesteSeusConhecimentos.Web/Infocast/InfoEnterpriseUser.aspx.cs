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
    public partial class InfoEnterpriseUser : System.Web.UI.Page
    {
        private IEnterpriseUserRepository enterpriseUserRepository;
        private IEnterpriseRepository enterpriseRepository; 
        private IUserRepository userRepository;

        private int idEnterpriseUser
        {
            set { ViewState["idEnterpriseUser"] = value; }
            get
            {
                if (ViewState["idEnterpriseUser"] != null)
                    return Convert.ToInt32(ViewState["idEnterpriseUser"]);

                return 0;
            }
        }

        public InfoEnterpriseUser()
        {
            this.enterpriseUserRepository = new EnterpriseUserRepository();
            this.enterpriseRepository = new EnterpriseRepository();
            this.userRepository = new UserRepository();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UpdateDropDownEnterprises();
                UpdateDropDownUsers();
                SetViewStateEnterpriseUser();
                UpdateForm();
                
            }
        }

        private void UpdateDropDownEnterprises()
        {
            
            var enterprises = enterpriseRepository.GetAll();

            dpdEnterprise.DataSource = enterprises.ToList();
            dpdEnterprise.DataBind();
            dpdEnterprise.Items.Insert(0, "Selecione...");
        }

        private void UpdateDropDownUsers()
        {

            var users = userRepository.GetAll();

            dpdUser.DataSource = users.ToList();
            dpdUser.DataBind();
            dpdUser.Items.Insert(0, "Selecione...");
        }


        private void SetViewStateEnterpriseUser()
        {
            if (Request.QueryString["id"] != null)
                idEnterpriseUser = Convert.ToInt32(Request.QueryString["id"]);
            else
                idEnterpriseUser = 0;
        }

        private void UpdateForm()
        {
            EnterpriseUser enterpriseUser = this.enterpriseUserRepository.GetById(idEnterpriseUser);

            if (enterpriseUser != null)
            {
                formStatus.InnerText = "Editar Relacionamento";
                
                dpdUser.SelectedValue = enterpriseUser.IdUser.ToString();

                dpdEnterprise.SelectedValue = enterpriseUser.IdEnterprise.ToString(); 
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {

            if (dpdEnterprise.SelectedValue == "Selecione..." || dpdUser.SelectedValue == "Selecione...")
            {
                Response.Redirect("~/Infocast/EnterprisesUsers.aspx");
            }

            EnterpriseUser enterpriseUser = new EnterpriseUser(
                                        idEnterpriseUser,
                                        Convert.ToInt32(dpdEnterprise.Text),
                                        Convert.ToInt32(dpdUser.Text) 
                                        );

            this.enterpriseUserRepository.Save(enterpriseUser);

            Response.Redirect("~/Infocast/EnterprisesUsers.aspx");
        }
    }
}