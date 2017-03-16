using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sistema_Agente
{
    public partial class UbicacionAgente : System.Web.UI.Page
    {
        //Cargar Pagina
        protected void Page_Load(object sender, EventArgs e)
        {
            Random rnd = new Random();
            String[] col;
            for (int i=1;i<=2;i++)
            {
                col = colfil(i,rnd.Next(1,7));
                Modificacion(i,col[1],col[0]);
            }
        }

        //Ubicacion del agente en la columnas determinas para el inicio
        private string[] colfil(int agente,int azar)
        {
            string[] cf = new string[2];
            if (agente == 1)
            {
                switch (azar)
                {
                    case 1:
                        cf[0] = "A";
                        cf[1] = "1";
                        break;
                    case 2:
                        cf[0] = "A";
                        cf[1] = "2";
                        break;
                    case 3:
                        cf[0] = "A";
                        cf[1] = "3";
                        break;
                    case 4:
                        cf[0] = "B";
                        cf[1] = "1";
                        break;
                    case 5:
                        cf[0] = "B";
                        cf[1] = "2";
                        break;
                    default:
                        cf[0] = "B";
                        cf[1] = "3";
                        break;
                }

            }
            else
            {
                switch (azar)
                {
                    case 1:
                        cf[0] = "I";
                        cf[1] = "1";
                        break;
                    case 2:
                        cf[0] = "I";
                        cf[1] = "2";
                        break;
                    case 3:
                        cf[0] = "I";
                        cf[1] = "3";
                        break;
                    case 4:
                        cf[0] = "J";
                        cf[1] = "1";
                        break;
                    case 5:
                        cf[0] = "J";
                        cf[1] = "2";
                        break;
                    default:
                        cf[0] = "J";
                        cf[1] = "3";
                        break;
                }
            }
            return cf;
        }

        //Modificación del agente en la base de datos
        private void Modificacion(int Agente,string fila, string Columna)
        {
            string sql = "UPDATE `sistema`.`escenario` SET `{0}`='{2}' WHERE  `Fila`={1};";//Cadena de texto en codigo sql para consultar el usuario
            sql = string.Format(sql, Columna, fila,Agente);//Concatenador de string
            Conexion.EjecutarOperacion(sql);
        }
    }
}