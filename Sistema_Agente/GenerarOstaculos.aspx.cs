using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sistema_Agente
{
    public partial class GenerarOstaculos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int anterior = 0,azar=0;
            string col = "";

            for (int i = 1; i < 7; i++)
            {
                col = columna(i);
                do
                {
                    do {
                        azar = rnd.Next(1, 4);
                    } while (anterior == azar);

                } while ("0"!=Consulta(azar,col));
                Modificacion(azar,col);
                anterior = azar;
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
            string sql = "UPDATE `sistema`.`escenario` SET `{0}`='3' WHERE  `Fila`={1};";//Cadena de texto en codigo sql para consultar el usuario
            sql = string.Format(sql, Columna, fila);//Concatenador de string
            Conexion.EjecutarOperacion(sql);
        }

        private string columna(int o)
        {
            switch (o)
            {
                case 1:
                    return "C";
                    break;
                case 2:
                    return "D";
                    break;
                case 3:
                    return "E";
                    break;
                case 4:
                    return "F";
                    break;
                case 5:
                    return "G";
                    break;
                default:
                    return "H";
                    break;
            }
        }

    }
}