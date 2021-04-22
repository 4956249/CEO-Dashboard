using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace daemon_console.DataConnection
{
    public static class DBAccess
    {
        static DBAccess()
        {

        }

        /// <summary>
        /// A method to create a SqlCommand accepting parameters
        /// </summary>
        /// <param name="connectionstring"></param>
        /// <param name="commandText"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static SqlCommand CreateSPCommand(string connectionstring, string commandText, System.Data.SqlClient.SqlParameter[] parameters1, params SqlParameter[] parameters)
        {
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = commandText;
            foreach (SqlParameter parameter in parameters)
            {
                comm.Parameters.Add(parameter);
            }
            return comm;
        }

        public static SqlCommand CreateSPCommandWithOutput(string connectionstring, string commandText, ParameterDirection paramdirect, params SqlParameter[] parameters)
        {
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = commandText;
            foreach (SqlParameter parameter in parameters)
            {
                comm.Parameters.Add(parameter);
            }
            return comm;
        }


        public static SqlCommand CreateSPCommandWithOutput(string connectionstring, string commandText, string outparam)
        {
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = commandText;
            comm.Parameters.Add(outparam, SqlDbType.Bit).Direction = ParameterDirection.Output;
            //foreach (SqlParameter parameter in parameters)
            //{
            //    comm.Parameters.Add(parameter);
            //}
            return comm;
        }

        /// <summary>
        /// A Method to create a SqlCommand
        /// </summary>
        /// <param name="connectionstring"></param>
        /// <param name="commandText"></param>
        /// <returns></returns>
        public static SqlCommand CreateCommand(string connectionstring, string commandText)
        {
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = commandText;
            return comm;
        }
    }
}
