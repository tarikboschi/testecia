using System;
using System.Linq;
using System.Web.UI.WebControls;
using TesteSeusConhecimentos.Domain;
using TesteSeusConhecimentos.Infra.Repositories;

namespace TesteSeusConhecimentos.Web.Infocast.Enterprise
{
    public partial class Enterprise : System.Web.UI.Page
    {
        private readonly IEnterpriseRepository _EnterpriseRepository;
        private IRelationshipRepository _RelationshipRepository;

        public Enterprise()
        {
            this._EnterpriseRepository = new EnterpriseRepository();
            this._RelationshipRepository = new RelationshipRepository();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UpdateGridEnterprises();
            }
        }

        private void UpdateGridEnterprises()
        {
            var users = _EnterpriseRepository.GetAll();
            grdEnterprises.DataSource = users.ToList();
            grdEnterprises.DataBind();
        }

        protected void grdUsers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                var idEnteprise = Convert.ToInt32(e.CommandArgument);

                switch (e.CommandName)
                {
                    case ("Remove"):

                        if (!ValidaRelacionamento(idEnteprise))
                        {
                            _EnterpriseRepository.Delete(idEnteprise);
                            UpdateGridEnterprises();
                        }
                        else
                        {
                            Alert("Empresa não pode ser excluida!");
                        }
                    
                        break;
                    case ("Edit"):
                        Response.Redirect("~/Infocast/Enterprise/InfoEnterprise.aspx?id=" + idEnteprise, true);
                        break;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        /// <summary>
        /// Metódo responsavel por validar vinculo de Empresa com Relacionamentos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool ValidaRelacionamento(int id)
        {
            bool retorno = false;
            var relacionamento = _RelationshipRepository.GetAll().Where(x => x.IdEnterprise == id).FirstOrDefault();
            if (relacionamento != null)
            {
                return true;
            }
            return retorno;
        }

        /// <summary>
        /// Mensagem de alerta javascript
        /// </summary>
        /// <param name="msg"></param>
        private void Alert(string msg)
        {
            ClientScript.RegisterStartupScript(base.GetType(), "alert_msg", string.Format("alert('{0}');", msg), true);
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Infocast/Enterprise/InfoEnterprise.aspx");
        }
    }
}