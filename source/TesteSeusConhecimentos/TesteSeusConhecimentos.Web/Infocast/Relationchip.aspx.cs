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
    public partial class Relationchip : System.Web.UI.Page
    {
        private IEnterpriseRepository enterprise;
        private IUserRepository users;

        public Relationchip()
        {
            this.enterprise = new EnterpriseRepository();
            this.users = new UserRepository();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetDdlEmpresa();
                SetDdlUsuario();
                SetGrid();
                ViewDdls();
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            if (ddlEmpresa.SelectedIndex != 0 || ddlUsuario.SelectedIndex != 0)
            {
                Enterprise _enterprise = new Enterprise();
                _enterprise = enterprise.GetById(Convert.ToInt32(ddlEmpresa.SelectedValue));

                List<User> _list = new List<User>();
                _list.Add(users.GetById(Convert.ToInt32(ddlUsuario.SelectedValue)));

                _enterprise.Users = _list;

                enterprise.Save(_enterprise);

                SetGrid();

                ViewDdls();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "Alerta", "alert('Preencha todos os campos');", true);
            }
        }

        private void SetDdlEmpresa()
        {
            ddlEmpresa.DataTextField = "CorporateActivy";
            ddlEmpresa.DataValueField = "IdEnterprise";
            ddlEmpresa.DataSource = enterprise.GetAll().ToList();
            ddlEmpresa.DataBind();
            ddlEmpresa.Items.Insert(0,"Selecione uma empresa");
        }

        private void SetDdlUsuario()
        {
            ddlUsuario.DataTextField = "Name";
            ddlUsuario.DataValueField = "IdUser";
            ddlUsuario.DataSource = users.GetAll().ToList();
            ddlUsuario.DataBind();
            ddlUsuario.Items.Insert(0, "Selecione um usuário");
        }

        private void ViewDdls()
        {
            ddlEmpresa.SelectedIndex = 0;
            ddlUsuario.SelectedIndex = 0;
        }

        private void SetGrid()
        {
            grdRelationchip.DataSource = enterprise.GetRelationchip();
            grdRelationchip.DataBind();
        }

        protected void grdRelationchip_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string Chave = e.CommandArgument.ToString();

            string idEnterprise = Chave.Substring(0, Chave.IndexOf(";"));
            string idUser = Chave.Substring(Chave.IndexOf(";") + 1, Chave.Length - (Chave.IndexOf(";")+1));

            enterprise.DeleteRelationchip(idEnterprise,idUser);

            SetGrid();
        }
    }
}