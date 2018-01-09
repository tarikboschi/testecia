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
    public partial class InfoEnterprise : System.Web.UI.Page
    {
        private IRepository<Enterprise> enterpriseRepository;

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
            this.enterpriseRepository = new EnterpriseRepository();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetStates();
                SetViewStateEnterprise();
                UpdateForm();
            }
        }

        private void GetStates()
        {
            Array states = Enum.GetValues(typeof(State));
            foreach (State state in states)
            {
                ddlState.Items.Add(new ListItem(state.ToString()));
            }
        }

        private void UpdateForm()
        {
            Enterprise enterprise = this.enterpriseRepository.GetById(idEnterprise);

            if (enterprise != null)
            {
                formStatus.InnerText = "Editar Empresa";
                txtCompany.Text = enterprise.Company;
                txtStreetAdress.Text = enterprise.StreetAdress;
                txtCity.Text = enterprise.City;
                ddlState.SelectedValue = enterprise.State;
                txtZipCode.Text = enterprise.ZipCode;
                txtCorporateActivity.Text = enterprise.CorporateActivity;
            }
        }

        private void SetViewStateEnterprise()
        {
            if (Request.QueryString["id"] != null)
                idEnterprise = Convert.ToInt32(Request.QueryString["id"]);
            else
                idEnterprise = 0;
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            Enterprise enterprise = new Enterprise(
                idEnterprise,
                txtCompany.Text,
                txtStreetAdress.Text, 
                txtCity.Text, 
                ddlState.SelectedValue, 
                txtZipCode.Text, 
                txtCorporateActivity.Text);

            enterpriseRepository.Save(enterprise);

            Response.Redirect("~/Infocast/Enterprises.aspx");
        }
    }
}