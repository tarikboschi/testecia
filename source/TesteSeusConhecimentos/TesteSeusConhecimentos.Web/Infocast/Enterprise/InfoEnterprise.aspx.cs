using System;
using TesteSeusConhecimentos.Domain;
using TesteSeusConhecimentos.Infra.Repositories;

namespace TesteSeusConhecimentos.Web.Infocast.Enterprise
{
    public partial class InfoEnterprise : System.Web.UI.Page
    {

        private readonly IEnterpriseRepository _EnterpriseRepository;

        private int IdEnterprise
        {
            set { ViewState["idEnterprise"] = value; }
            get
            {
                return ViewState["idEnterprise"] != null ? Convert.ToInt32(ViewState["idEnterprise"]) : 0;
            }
        }

        public InfoEnterprise()
        {
            this._EnterpriseRepository = new EnterpriseRepository();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            SetViewStateUser();
            UpdateForm();
        }

        private void SetViewStateUser()
        {
            IdEnterprise = Request.QueryString["id"] != null ? Convert.ToInt32(Request.QueryString["id"]) : 0;
        }


        private void UpdateForm()
        {
            var enterprise = this._EnterpriseRepository.GetById(IdEnterprise);

            if (enterprise == null) return;
            formStatus.InnerText = "Editar Empresa";
            txtStreetAdress.Text = enterprise.StreetAdress;
            txtCity.Text = enterprise.City;
            txtState.Text = enterprise.State;
            TxtZipCode.Text = enterprise.ZipCode;
            TxtCorporateActivity.Text = enterprise.CorporateActivity;
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            var enterprise = new Entities.Enterprise(IdEnterprise,
                                                        txtStreetAdress.Text,
                                                        txtCity.Text,
                                                        txtState.Text,
                                                        TxtZipCode.Text,
                                                        TxtCorporateActivity.Text);
            _EnterpriseRepository.Save(enterprise);

            Response.Redirect("~/Infocast/Enterprise/Enterprises.aspx");
        }
    }
}