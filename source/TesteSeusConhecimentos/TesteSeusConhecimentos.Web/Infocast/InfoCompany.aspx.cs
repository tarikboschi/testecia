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
    public partial class InfoCompany : System.Web.UI.Page
    {
        private ICompanyRepository companyRepository;

        private int idCompany
        {
            set { ViewState["idCompany"] = value; }
            get
            {
                if (ViewState["idCompany"] != null)
                    return Convert.ToInt32(ViewState["idCompany"]);

                return 0;
            }
        }

        public InfoCompany()
        {
            this.companyRepository = new CompanyRepository();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetViewStateCompany();
                UpdateForm();
            }
        }

        private void SetViewStateCompany()
        {
            if (Request.QueryString["id"] != null)
                idCompany = Convert.ToInt32(Request.QueryString["id"]);
            else
                idCompany = 0;
        }

        private void UpdateForm()
        {
            Company company = this.companyRepository.GetById(idCompany);

            if (company != null)
            {
                formStatus.InnerText = "Editar Empresa";
                txtNome.Text = company.Name; 
                txtEndereco.Text = company.StreetAddress;
                txtCidade.Text = company.City;
                txtEstado.Text = company.State;
                txtCep.Text = company.ZipCode;
                txtAtividade.Text = company.CorporateActivity;
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            Company company = new Company(idCompany, txtNome.Text ,txtEndereco.Text, txtCidade.Text, txtEstado.Text, txtCep.Text, txtAtividade.Text);
            companyRepository.Save(company);
            
            Response.Redirect("~/Infocast/Companies.aspx");
        }
    }
}