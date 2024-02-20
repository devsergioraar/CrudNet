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
    public partial class CRUD : System.Web.UI.Page
    {
        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        public static string sID = "-1";
        public static string sOpc = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            
            //obtener id
            if (!Page.IsPostBack)
            {
                sID = null;
                sOpc = null;
                if (!string.IsNullOrWhiteSpace(Request.QueryString["id"]))
                {
                    sID = Request.QueryString["id"].ToString();
                }

                if (!string.IsNullOrWhiteSpace(sID))
                {
                    CargarDatos();
                    
                    tbdate.TextMode = TextBoxMode.DateTime;
                }
                 
                if (!string.IsNullOrWhiteSpace(Request.QueryString["op"]))
                {
                    sOpc = Request.QueryString["op"].ToString();
                    this.btnvolver.Visible = true;
                    switch (sOpc)
                    {
                        case "c":
                            this.lbltitulo.Text = "Ingresar nuevo usuario";
                            this.btncreate.Visible = true;
                            break;
                        case "r":
                            this.lbltitulo.Text = "Consulta de usuario";
                            break;
                        case "u":
                            this.lbltitulo.Text = "Modificar usuario";
                            this.btnupdate.Visible = true;
                            break;
                        case "d":
                            this.lbltitulo.Text = "Eliminar usuario";
                            this.btndelete.Visible = true;
                            break;
                        
                        default:
                            break;

                    }
                }
            }
        }

        void CargarDatos()
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("sp_read", con);
            da.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@Id", SqlDbType.Int).Value = sID;

            DataSet ds = new DataSet();
            ds.Clear();

            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            if (dt.Rows.Count>0)
            {
                DataRow dr = dt.Rows[0];
                tbnombre.Text = dr["Nombre"].ToString();
                tbedad.Text = dr["Edad"].ToString();
                tbemail.Text = dr["Correo"].ToString();
                DateTime fecha = (DateTime)dr["Fecha_Nacimiento"];

                tbdate.Text = fecha.ToString("dd/MM/yyyy");
            }
            con.Close();
        }

        protected void btncreate_Click(object sender, EventArgs e)
        {
            int aux = 0; DateTime dt = DateTime.Now;
            SqlCommand cmd = new SqlCommand("sp_create",con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Nombre",SqlDbType.VarChar).Value = tbnombre.Text;

            int.TryParse(tbedad.Text, out aux);
            cmd.Parameters.Add("@Edad", SqlDbType.Int).Value = aux;

            cmd.Parameters.Add("@Correo", SqlDbType.VarChar).Value = tbemail.Text;

            DateTime.TryParse(tbdate.Text, out dt);
            cmd.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = dt;

            cmd.ExecuteNonQuery();
            con.Close();

            Response.Redirect("index.aspx");
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            int aux = 0; DateTime dt = DateTime.Now;
            SqlCommand cmd = new SqlCommand("sp_update", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = sID;

            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = tbnombre.Text;

            int.TryParse(tbedad.Text, out aux);
            cmd.Parameters.Add("@Edad", SqlDbType.Int).Value = aux;

            cmd.Parameters.Add("@Correo", SqlDbType.VarChar).Value = tbemail.Text;

            DateTime.TryParse(tbdate.Text, out dt);
            cmd.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = dt;

            cmd.ExecuteNonQuery();
            con.Close();

            Response.Redirect("index.aspx");
        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            int aux = 0; DateTime dt = DateTime.Now;
            SqlCommand cmd = new SqlCommand("sp_delete", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = sID;

            cmd.ExecuteNonQuery();
            con.Close();

            Response.Redirect("index.aspx");
        }

        protected void btnvolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
    }
}