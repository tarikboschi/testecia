using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TesteSeusConhecimentos.Domain;
using TesteSeusConhecimentos.Infra;

namespace TesteSeusConhecimentos.Web.Infocast
{
    public partial class Users : System.Web.UI.Page
    {
        private IUserRepository userRepository;

        public Users()
        {
            this.userRepository = new UserRepository();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UpdateGridUsers();
            }
        }

        protected void grdUsers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int idUser = Convert.ToInt32(e.CommandArgument);

            switch (e.CommandName)
            {
                case ("Remove"):
                    userRepository.Delete(idUser);
                    UpdateGridUsers();
                    break;
                case ("Edit"):
                    Response.Redirect("~/Infocast/InfoUser.aspx?id=" + idUser, true);
                    break;
            }
           
        }

        private void UpdateGridUsers()
        {
            var users = userRepository.GetAll();
            grdUsers.DataSource = users.ToList();
            grdUsers.DataBind();
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Infocast/InfoUser.aspx");
        }
    }
}