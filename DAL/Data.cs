using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Data
    {
        SqlConnection oConnection = new SqlConnection();

        public Data()
        {
            oConnection.ConnectionString = System.Configuration.ConfigurationManager
                .ConnectionStrings["webformConnectionString"].ToString();
        }

        /// <summary>
        /// Ejecuta la consulta y devuelve la primer columna de la primer fila en el resultset retornado por la consulta.
        /// </summary>
        /// <param name="Query"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>

        public object ExecuteScalar(string Query, SqlParameter[] parameters)
        {
            object result = null;
            SqlCommand command = new SqlCommand(Query, oConnection);
            
            if (parameters != null && parameters.Length > 0) command.Parameters.AddRange(parameters);

            try
            {
                oConnection.Open();
                result = command.ExecuteScalar();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                oConnection.Close();
            }

            return result;
        }

        /// <summary>
        /// Devuelve la cantidad de filas afectadas
        /// </summary>
        /// <param name="Query"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>

        public int ExecuteWithoutResults(string Query, SqlParameter[] parameters)
        {
            int countAffectedRows = 0;
            SqlCommand command = new SqlCommand(Query, oConnection);

            if(parameters != null && parameters.Length > 0) command.Parameters.AddRange(parameters);

            try
            {
                oConnection.Open();
                countAffectedRows = command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                oConnection.Close();
            }

            return countAffectedRows;
        }

        /// <summary>
        /// Nos devuelve un datatable 
        /// </summary>
        /// <param name="Query"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>

        public DataTable GetDataTable(string Query, SqlParameter[] parameters)
        {
            var dt = new DataTable();
            SqlCommand command = new SqlCommand(Query, oConnection);

            if (parameters != null && parameters.Length > 0) command.Parameters.AddRange(parameters);

            var da = new SqlDataAdapter();
            da.SelectCommand = command;

            try
            {
                oConnection.Open();
                da.Fill(dt);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                oConnection.Close();
            }

            return dt;
        }
    }
}
