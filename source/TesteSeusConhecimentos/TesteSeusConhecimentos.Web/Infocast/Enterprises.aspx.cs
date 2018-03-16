using System;
using System.Linq;
using System.Web.UI.WebControls;
using TesteSeusConhecimentos.Domain;
using TesteSeusConhecimentos.Entities;
using TesteSeusConhecimentos.Infra;

namespace TesteSeusConhecimentos.Web.Infocast
{
    public partial class Enterprises : System.Web.UI.Page
    {
        private IRepository<Enterprise> userRepository;

        public Enterprises() { this.userRepository = new EnterprisesRepository(); }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { UpdateGrid(); }
        }

        protected void grdEnterprises_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);

            switch (e.CommandName)
            {
                case ("Remove"):
                    userRepository.Delete(id);
                    UpdateGrid();
                    break;
                case ("Edit"):
                    Response.Redirect("~/Infocast/InfoEnterprise.aspx?id=" + id, true);
                    break;
            }
        }

        private void UpdateGrid()
        {
            var obj = userRepository.GetAll<Enterprise>();
            grdEnterprises.DataSource = obj.ToList();
            grdEnterprises.DataBind();
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Infocast/InfoEnterprise.aspx");
        }
    }
}