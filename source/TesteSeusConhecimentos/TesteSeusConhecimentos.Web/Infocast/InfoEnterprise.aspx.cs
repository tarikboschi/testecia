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
        private IEnterpriseRepository enterpriseRepository;

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
                SetViewStateEnterprise();
                UpdateForm();
            }
        }

        private void SetViewStateEnterprise()
        {
            if (Request.QueryString["id"] != null)
                idEnterprise = Convert.ToInt32(Request.QueryString["id"]);
            else
                idEnterprise = 0;
        }

        private void UpdateForm()
        {
            Enterprise enterprise = this.enterpriseRepository.GetById(idEnterprise);

            if (enterprise != null)
            {
                formStatus.InnerText = "Editar Empresa";
                txtName.Text = enterprise.Name;
                txtEndereco.Text = enterprise.StreetAdress;
                txtCidade.Text = enterprise.City;
                txtEstado.Text = enterprise.State;
                txtCep.Text = enterprise.ZipCode;
                txtAtividade.Text = enterprise.CorporateActivity;
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            Enterprise enterprise = new Enterprise(
                                        idEnterprise, 
                                        txtName.Text, 
                                        txtEndereco.Text,
                                        txtCidade.Text,
                                        txtEstado.Text,
                                        txtCep.Text,
                                        txtAtividade.Text
                                        );

            this.enterpriseRepository.Save(enterprise);

            Response.Redirect("~/Infocast/Enterprises.aspx");
        }
    }
}