using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HolaMundoWeb
{
    public partial class WFIngreso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Configurar();
        }

        protected void Configurar()
        {
            // Configuro el formulario
            LabelTitulo.Text = "Ingreso de personas";
            Label1.Text = "Ingrese nombre";
            Label2.Text = "Ingrese apellido";
            Label3.Text = "Ingrese edad";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // Obtengo los datos del formulario
            String strnombre = TextBox1.Text;
            String strapellido = TextBox2.Text;
            String stredad = TextBox3.Text;

            // Conectar a la base de datos
            SqlConnection con = new SqlConnection(Properties.Settings.Default.Conexion);
            con.Open();

            // Sql de insercion
            String sql = "insert into Persona values ('" + strnombre + "','"+ strapellido + "'," + stredad + ")";

            // Inserta en la tabla
            try
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
       
                LabelTitulo.Text = "Datos guardados correctamente";
                con.Close(); 
            }
            catch (Exception)
            {
                Label1.Text = "Hay error";
            }
        }

    }
}