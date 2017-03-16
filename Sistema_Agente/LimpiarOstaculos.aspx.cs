using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sistema_Agente
{
    public partial class LimpiarOstaculos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string col = "";

            for (int i = 1; i < 7; i++)
            {
                col = columna(i);
                for (int j=1;j<=3;j++) {
                    if (Consulta(j, col) == "3")
                    {
                        Modificacion(j, col);
                    }
                }
            }

        }

        private string Consulta(int fila, string Columna)
        {
            string sql = "SELECT `{0}` FROM escenario where fila={1};";//Cadena de texto en codigo sql para consultar el usuario
            sql = string.Format(sql, Columna, fila);//Concatenador de string
            return Conexion.EjecutarConsulta(sql).Rows[0][Columna].ToString();
        }

        private void Modificacion(int fila, string Columna)
        {
            string sql = "UPDATE `sistema`.`escenario` SET `{0}`='0' WHERE  `Fila`={1};";//Cadena de texto en codigo sql para consultar el usuario
            sql = string.Format(sql, Columna, fila);//Concatenador de string
            Conexion.EjecutarOperacion(sql);
        }

        private string columna(int o)
        {
            string letra = "";
            switch (o)
            {
                case 1:
                    letra="C";
                    break;
                case 2:
                    letra = "D";
                    break;
                case 3:
                    letra = "E";
                    break;
                case 4:
                    letra = "F";
                    break;
                case 5:
                    letra = "G";
                    break;
                default:
                    letra = "H";
                    break;
            }
            return letra;
        }
    }
}