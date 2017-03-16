using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sistema_Agente
{
    public partial class ActualizarEscenario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable c = Conexion.EjecutarConsulta("SELECT * FROM escenario;");
            string Table = "";
            for (int i = 0; i < c.Rows.Count; i++)
            {
                Table += "<tr>";
                Table += "<td style='text-align:center'>" + imagen(c.Rows[i]["A"].ToString()) + "</td>";
                Table += "<td style='text-align:center'>" + imagen(c.Rows[i]["B"].ToString()) + "</td>";
                Table += "<td style='text-align:center'>" + imagen(c.Rows[i]["C"].ToString())+ "</td>";
                Table += "<td style='text-align:center'>" + imagen(c.Rows[i]["D"].ToString()) + "</td>";
                Table += "<td style='text-align:center'>" + imagen(c.Rows[i]["E"].ToString()) + "</td>";
                Table += "<td style='text-align:center'>" + imagen(c.Rows[i]["F"].ToString()) + "</td>";
                Table += "<td style='text-align:center'>" + imagen(c.Rows[i]["G"].ToString()) + "</td>";
                Table += "<td style='text-align:center'>" + imagen(c.Rows[i]["H"].ToString()) + "</td>";
                Table += "<td style='text-align:center'>" + imagen(c.Rows[i]["I"].ToString()) + "</td>";
                Table += "<td style='text-align:center'>" + imagen(c.Rows[i]["J"].ToString()) + "</td>";
                Table += "</tr>";
            }
            Response.Write(Table);
        }

        private string imagen(string valor)
        {
            string img = " ";
            switch (valor)
            {
                case "1":
                    img = "<img src='/Imagen/atleta-corriendo.gif' height='50' width='50' />";
                    break;
                case "2":
                    img = "<img src='/Imagen/atleta-corriendo.gif' height='50' width='50' />";
                    break;
                case "3":
                    img = "<img src='/Imagen/Barrera.png' height='50' width='50' />";
                    break;

            }
            return img;
        }
    }
}