using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace Sistema_Agente
{
    public class Conexion
    {
        private static MySqlConnection conexion = new MySqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

        private static MySqlConnection conectar()
        {
            try
            {
                    conexion.Open();
            }
            catch (Exception)
            {
                return null;
            }
            return conexion;
        }

        private static void desconectar()
        {
            conexion.Close();
        }

        public static bool EjecutarOperacion(string sentencia)
        {
            try
            {
                MySqlCommand mySqlCommand = new MySqlCommand(sentencia,conectar());

                if (mySqlCommand.ExecuteNonQuery() > 0)
                {
                    desconectar();
                    return true;
                }

               desconectar();
                return false;
                
            }
            catch (Exception e)
            
            {
                throw new Exception("No se realizó ninguna operación de Registro en la Base de Datos.");
            }
        }

        public static DataTable EjecutarConsulta(string Select)
        
        {
            DataTable dt = new DataTable();
            MySqlCommand mySqlCommand = new MySqlCommand(Select,conectar());

            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter(mySqlCommand);
                da.Fill(dt);
                desconectar();
                return dt;
            }
            catch(Exception x)
            {
                desconectar();
                throw new Exception("Sentencia SQL de consulta invalida.");

            }
        }
    }
}
