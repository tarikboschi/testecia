using System;
using System.Linq;
using System.Web.UI.WebControls;
using TesteSeusConhecimentos.Domain;
using TesteSeusConhecimentos.Infra.Repositories;

namespace TesteSeusConhecimentos.Web.Infocast
{
    public partial class Users : System.Web.UI.Page
    {
        private IUserRepository userRepository;
        private IRelationshipRepository _RelationshipRepository;
        public Users()
        {
            this.userRepository = new UserRepository();
            this._RelationshipRepository = new RelationshipRepository();
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
                    if (!ValidaRelacionamento(idUser))
                    {
                        userRepository.Delete(idUser);
                        UpdateGridUsers();
                    }
                    else
                    {
                        Alert("Usuário não pode ser excluido!");
                    }
                    break;
                case ("Edit"):
                    Response.Redirect("~/Infocast/User/InfoUser.aspx?id=" + idUser, true);
                    break;
            }
           
        }

        /// <summary>
        /// Metódo responsavel por validar vinculo de Usuário com Relacionamentos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool ValidaRelacionamento(int id)
        {
            bool retorno = false;
            var relacionamento = _RelationshipRepository.GetAll().Where(x => x.IdUser == id).FirstOrDefault();
            if (relacionamento != null)
            {
                return true;
            }

            return retorno;
        }


        /// <summary>
        /// Mensagem alerta javascript
        /// </summary>
        /// <param name="msg"></param>
        private void Alert(string msg)
        {
            ClientScript.RegisterStartupScript(base.GetType(), "alert_msg", string.Format("alert('{0}');", msg), true);
        }


        private void UpdateGridUsers()
        {
            var users = userRepository.GetAll();
            grdUsers.DataSource = users.ToList();
            grdUsers.DataBind();
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Infocast/User/InfoUser.aspx");
        }
    }
}