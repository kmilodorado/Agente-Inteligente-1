using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sistema_Agente
{
    public partial class RestablecerSistema : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable c = Conexion.EjecutarConsulta("SELECT * FROM escenario;");
            for (int i=1;i<=c.Rows.Count;i++)
            {
                Conexion.EjecutarOperacion("DELETE FROM `sistema`.`escenario` WHERE  `Fila`="+i+";");
                Conexion.EjecutarOperacion("INSERT INTO `sistema`.`escenario` (`Fila`, `A`, `B`, `C`, `D`, `E`, `F`, `G`, `H`, `I`, `J`) VALUES ('"+i+"', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0');");
            }
        }
    }
}