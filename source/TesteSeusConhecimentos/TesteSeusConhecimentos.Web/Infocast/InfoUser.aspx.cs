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
    public partial class InfoUser : System.Web.UI.Page
    {
        private IUserRepository userRepository;

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

        public InfoUser()
        {
            this.userRepository = new UserRepository();
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
                idUser = Convert.ToInt32(Request.QueryString["id"]);
            else
                idUser = 0;
        }

        private void UpdateForm()
        {
            User user = this.userRepository.GetById(idUser);

            if (user != null)
            {
                formStatus.InnerText = "Editar Usuário";
                txtName.Text = user.Name;
                txtLastName.Text = user.LastName;
                txtEmail.Text = user.Email;
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            User user = new User(idUser, txtName.Text, txtLastName.Text, txtEmail.Text);
            userRepository.Save(user);
            
            Response.Redirect("~/Infocast/Users.aspx");
        }
    }
}