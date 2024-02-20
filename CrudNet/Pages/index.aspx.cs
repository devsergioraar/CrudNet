using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CrudNet.Pages
{
    public partial class index : System.Web.UI.Page
    {
        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarTabla();
        }

        void CargarTabla()
        {
            SqlCommand cmd = new SqlCommand("sp_load",con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            gvusuarios.DataSource = dt;
            gvusuarios.DataBind();
            con.Close();
        }

        protected void btncreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Crud.aspx?op=c");
        }

        protected void btnread_Click(object sender, EventArgs e)
        {
            string id = "";
            buscador(sender, ref id);

            Response.Redirect("~/Pages/Crud.aspx?id="+id+"&op=r");
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            string id = "";
            buscador(sender, ref id);

            Response.Redirect("~/Pages/Crud.aspx?id=" + id + "&op=u");
        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            string id = "";
            buscador(sender, ref id);

            Response.Redirect("~/Pages/Crud.aspx?id=" + id + "&op=d");
        }

        private void buscador(object sender, ref string id)
        {
            id = "";
            Button btnConsultar = (Button)sender;
            GridViewRow selectedrow = (GridViewRow)btnConsultar.NamingContainer;
            id = selectedrow.Cells[1].Text;
        }
    }
}