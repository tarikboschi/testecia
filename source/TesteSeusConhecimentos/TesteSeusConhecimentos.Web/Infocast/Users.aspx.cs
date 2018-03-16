using System;
using System.Linq;
using System.Web.UI.WebControls;
using TesteSeusConhecimentos.Domain;
using TesteSeusConhecimentos.Entities;
using TesteSeusConhecimentos.Infra;

namespace TesteSeusConhecimentos.Web.Infocast
{
    public partial class Users : System.Web.UI.Page
    {
        private IRepository<User> userRepository;

        public Users() { this.userRepository = new UserRepository(); }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { UpdateGrid(); }
        }

        protected void grdUsers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int idUser = Convert.ToInt32(e.CommandArgument);

            switch (e.CommandName)
            {
                case ("Remove"):
                    userRepository.Delete(idUser);
                    UpdateGrid();
                    break;
                case ("Edit"):
                    Response.Redirect("~/Infocast/InfoUser.aspx?id=" + idUser, true);
                    break;
            }

        }

        private void UpdateGrid()
        {
            var obj = userRepository.GetAll<User>();
            grdUsers.DataSource = obj.ToList();
            grdUsers.DataBind();
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Infocast/InfoUser.aspx");
        }
    }
}