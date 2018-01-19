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
    public partial class InfoRelationShip : System.Web.UI.Page
    {
        private IUserRepository userRepository;
        private ICompanyRepository companyRepository;
        private IRelationShipRepository relationshipRepository;

        private int idUser
        {
            set { ViewState["idUser"] = value; }
            get
            {
                if (ViewState["idUser"] != null)
                    return Convert.ToInt32(ViewState["idUser"]);

                return 0;
            }
        }
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

        public InfoRelationShip()
        {
            this.userRepository = new UserRepository();
            this.companyRepository = new CompanyRepository();
            this.relationshipRepository = new RelationShipRepository();
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
            if (Request.QueryString["idcompany"] != null && Request.QueryString["iduser"] != null)
            {
                idUser = Convert.ToInt32(Request.QueryString["iduser"]);
                idCompany = Convert.ToInt32(Request.QueryString["idcompany"]);
            }
            else
            {
                idUser = 0;
                idCompany = 0;
            }
        }

        private void UpdateForm()
        {
            ddlcompany.DataSource = this.companyRepository.GetAll();
            ddlcompany.DataTextField = "Name";
            ddlcompany.DataValueField = "IdCompany";
            ddlcompany.DataBind();
            ddlcompany.Items.Insert(0, new ListItem("Selecione..."));

            ddluser.DataSource = this.userRepository.GetAll();
            ddluser.DataTextField = "Name";
            ddluser.DataValueField = "IdUser";
            ddluser.DataBind();
            ddluser.Items.Insert(0, new ListItem("Selecione..."));
        }

        protected void btnRelacionar_Click(object sender, EventArgs e)
        {
            int companyid = Convert.ToInt32(ddlcompany.SelectedValue);
            int userid = Convert.ToInt32(ddluser.SelectedValue);

            RelationShip relationship = new RelationShip(userid, companyid);
            relationshipRepository.Save(relationship);
            
            Response.Redirect("~/Infocast/RelationShips.aspx");
        }
    }
}