using System;
using TesteSeusConhecimentos.Domain;
using TesteSeusConhecimentos.Entities;
using TesteSeusConhecimentos.Infra;

namespace TesteSeusConhecimentos.Web.Infocast
{
    public partial class InfoEnterprise : System.Web.UI.Page
    {
        private IRepository<Enterprise> enterprisesRepository;

        private int idEnterprise
        {
            set { ViewState["idEnterprise"] = value; }
            get
            {
                if (ViewState["idEnterprise"] != null)
                    return Convert.ToInt32(ViewState["idEnterprise"]);

                return 0;
            }
        }

        public InfoEnterprise()
        {
            this.enterprisesRepository = new EnterprisesRepository();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetViewStateUser();
                UpdateForm();
            }
        }

        private void SetViewStateUser()
        {
            if (Request.QueryString["id"] != null)
                idEnterprise = Convert.ToInt32(Request.QueryString["id"]);
            else
                idEnterprise = 0;
        }

        private void UpdateForm()
        {
            Enterprise enterprise = this.enterprisesRepository.GetById<Enterprise>(idEnterprise);

            if (enterprise != null)
            {
                formStatus.InnerText = "Editar Empresa";
                txtStreetAdress.Text = enterprise.StreetAdress;
                txtCity.Text = enterprise.City;
                txtState.Text = enterprise.State;
                txtZipCode.Text = enterprise.ZipCode;
                txtCorporateActivity.Text = enterprise.CorporateActivity;
            }

        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            Enterprise enterprise = new Enterprise(idEnterprise, txtStreetAdress.Text, txtCity.Text, txtState.Text, txtZipCode.Text, txtCorporateActivity.Text);
            enterprisesRepository.Save(enterprise);

            Response.Redirect("~/Infocast/Enterprises.aspx");
        }
    }
}