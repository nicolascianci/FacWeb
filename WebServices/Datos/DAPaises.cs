using Entity.Parametros;
using Entity.Response;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DAPaises
    {
        public List<ResponsePais> listarPaises(ENRegistroEmpresa paramss)
        {
			try
			{
                string cs = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                var lista = new List<ResponsePais>();

                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_listarPaises",conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using(SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while(rdr.Read())
                        {
                            var result = new ResponsePais();
                            result.idpais = Convert.ToInt32(rdr["idpais"]);
                            result.pais = Convert.ToString(rdr["pais"]);
                            lista.Add(result);
                        }
                    }
                }

                return lista;
            }
			catch (Exception ex)
			{

				throw ex;
			}
        }
    }
}
