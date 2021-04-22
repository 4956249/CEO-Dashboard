using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using daemon_console.DataConnection;



namespace daemon_console.DataHandler
{    public static class DBAccessMethods
    {
        public static bool HasError { get; set; }
        public static string ErrorMessage { get; set; }

        static DBAccessMethods()
        {

        }

        public static bool InValidDataTable(string ColumnName, DataTable dtTest, int dtIndex)
        {
            bool result;
            try
            {
                if (String.IsNullOrEmpty(dtTest.Rows[dtIndex][ColumnName].ToString()))
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            catch (Exception ex)
            {
                result = true;             
            }
            return result;
        }

        #region Error Logging
        /// <summary>
        /// Logs error using LogError storedproc in database
        /// </summary>
        /// <param name="ex">Message from exception</param>
        public static void LogError(Exception ex)
        {
            //string connstring = CSAConfig.connectionString;

            //SqlCommand mycomm = CreateSPCommand("LogError", new SqlParameter("Message", ex.Message));
            //try
            //{
            //    mycomm.Connection.Open();
            //    mycomm.ExecuteNonQuery();
            //    mycomm.Connection.Close();
            //}
            //catch (Exception exTrap)
            //{
            //    DBAccessMethods.LogError(exTrap);
            //    throw exTrap;
            //}
            //finally
            //{
            //    mycomm.Connection.Close();
            //}
        }
        #endregion
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

        #region Parameterized Stored Procedure
        public static class ExecParamStoredProc
        {
            /// <summary>
            /// Executes parameterized stored procedure without returning a value 
            /// </summary>
            /// <param name="connectionstring"></param>
            /// <param name="procedureName"></param>
            /// <param name="parameters"></param>
            public static void noReturn(string connectionstring, string procedureName, params SqlParameter[] parameters)
            {
                SqlCommand mycomm = CreateSPCommand(connectionstring, procedureName, parameters);
                try
                {
                    mycomm.Connection.Open();
                    mycomm.ExecuteNonQuery();
                    HasError = false;
                }
                catch (Exception exTrap)
                {
                    DBAccessMethods.LogError(exTrap);
                    HasError = true;
                    ErrorMessage = exTrap.Message;
                    //throw exTrap;
                }
                finally
                {
                    mycomm.Connection.Close();
                }
            }

            /// <summary>
            /// Executes a parameterized stored procedure and returns a single int 
            /// </summary>
            /// <param name="connectionstring"></param>
            /// <param name="procedureName"></param>
            /// <param name="parameters"></param>
            /// <returns></returns>
            public static Int32 ReturnInt(string connectionstring, string procedureName, params SqlParameter[] parameters)
            {
                Int32 returnvalue;
                SqlCommand mycomm = CreateSPCommand(connectionstring, procedureName, parameters);
                try
                {
                    mycomm.Connection.Open();
                    returnvalue = Convert.ToInt32(mycomm.ExecuteScalar());
                    return returnvalue;
                }
                catch (Exception exTrap)
                {
                    DBAccessMethods.LogError(exTrap);
                    //returnvalue = exTrap.Message;
                    //return returnvalue;
                    return -1;
                }
                finally
                {
                    mycomm.Connection.Close();
                }
            }

            /// <summary>
            /// Executes parameterized stored procedure and returns single string 
            /// </summary>
            /// <param name="connectionstring"></param>
            /// <param name="procedureName"></param>
            /// <param name="parameters"></param>
            /// <returns></returns>
            public static string ReturnString(string connectionstring, string procedureName, params SqlParameter[] parameters)
            {
                string returnvalue = "";
                SqlCommand mycomm = CreateSPCommand(connectionstring, procedureName, parameters, parameters);
                try
                {
                    mycomm.Connection.Open();
                    returnvalue = (string)mycomm.ExecuteScalar();
                    return returnvalue;
                }
                catch (Exception exTrap)
                {
                    DBAccessMethods.LogError(exTrap);
                    returnvalue = "Error|" + exTrap.Message;
                    return returnvalue;// = "";
                }
                finally
                {
                    mycomm.Connection.Close();
                }
            }

            //public static byte ReturnByte(string connectionstring, string procedureName, params SqlParameter[] parameters)
            //{
            //    //var returnvalue = new System.Byte();
            //    //byte[] returnvalue;
            //    byte[] returnvalue = new byte;

            //    SqlCommand mycomm = CreateSPCommand(connectionstring, procedureName, parameters);
            //    try
            //    {
            //        mycomm.Connection.Open();
            //        returnvalue = (byte[])mycomm.ExecuteScalar();
            //        return returnvalue;
            //    }
            //    catch (Exception exTrap)
            //    {
            //        DBAccessMethods.LogError(exTrap);
            //        //returnvalue = "Error|" + exTrap.Message;
            //        return returnvalue;// = "";
            //    }
            //    finally
            //    {
            //        mycomm.Connection.Close();
            //    }
            //}


            /// <summary>
            ///  Executes parameterized stored procedure and returns boolean value 
            /// </summary>
            /// <param name="connectionstring"></param>
            /// <param name="procedureName"></param>
            /// <param name="parameters"></param>
            /// <returns></returns>
            public static Boolean ReturnBool(string connectionstring, string procedureName, params SqlParameter[] parameters)
            {
                //SqlConnection conn = new SqlConnection(connectionstring);
                //SqlCommand comm = new SqlCommand();
                //comm.Connection = conn;
                //comm.CommandType = CommandType.StoredProcedure;
                //comm.CommandText = procedureName;
                //foreach (SqlParameter parameter in parameters)
                //{
                //    comm.Parameters.Add(parameter);
                //}
                ////return comm;


                SqlCommand mycomm = CreateSPCommand ( connectionstring, procedureName, parameters);
                try
                {
                    mycomm.Connection.Open();
                    if (mycomm.ExecuteScalar() != null)
                    {
                        return true;
                    }
                    else
                        return false;
                }
                catch (Exception exTrap)
                {
                    DBAccessMethods.LogError(exTrap);
                    return false;
                }   
                finally
                {
                    mycomm.Connection.Close();
                }
            }

            /// <summary>
            /// Executes parameterized stored procedure and returns a data table object
            /// </summary>
            /// <param name="connectionstring"></param>
            /// <param name="procedurename"></param>
            /// <param name="parameters"></param>
            /// <returns></returns>
            public static DataTable ReturnTable(string connectionstring, string procedurename, params SqlParameter[] parameters)
            {
                DataTable returnvalue = new DataTable();
                SqlCommand mycomm = CreateSPCommand(connectionstring, procedurename, parameters);

                try
                {
                    mycomm.Connection.Open();
                    SqlDataReader reader = mycomm.ExecuteReader();
                    returnvalue.Load(reader);
                    return returnvalue;
                }
                catch (Exception exTrap)
                {
                    DBAccessMethods.LogError(exTrap);
                    return returnvalue;
                }
                finally
                {
                    mycomm.Connection.Close();
                }
            }

            internal static bool RetrunBoolOutput(string p1, string p2, ParameterDirection parameterDirection)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Executes parameterized stored procedure and returns a dataset object
            /// </summary>
            /// <param name="connectionstring"></param>
            /// <param name="procedurename"></param>
            /// <param name="parameters"></param>
            /// <returns></returns>
            public static DataSet ReturnDataSet(string connectionstring, string procedurename, params SqlParameter[] parameters)
            {
                DataSet dsResult = new DataSet();
                SqlCommand mycomm = CreateSPCommand(connectionstring, procedurename, parameters);

                try
                {
                    mycomm.Connection.Open();
                    SqlDataAdapter da = new SqlDataAdapter(mycomm);
                    da.Fill(dsResult, "ResultDataSet");
                    return dsResult;
                }
                catch (Exception exTrap)
                {
                    DBAccessMethods.LogError(exTrap);
                    return dsResult;
                }
                finally
                {
                    mycomm.Connection.Close();
                }
            }
        }
        #endregion

        #region Non Parameterized Stored Procedure
        //public static class ExecNonParamStoredProc
        //{

        //    internal static bool RetrunBoolOutput(string connectionstring, string procedurename, string outputparam)
        //    {
        //        bool returnvalue;
        //        SqlCommand mycomm = CreateSPCommandWithOutput(connectionstring, procedurename, outputparam);
        //        try
        //        {
        //            mycomm.Connection.Open();
        //            mycomm.ExecuteScalar();
        //            returnvalue = Convert.ToBoolean(mycomm.Parameters[outputparam].Value);
        //            return returnvalue;
        //        }
        //        catch (Exception exTrap)
        //        {
        //            throw exTrap;
        //            //DBAccessMethods.LogError(exTrap);
        //            //returnvalue = exTrap.Message;
        //            //return returnvalue = "";
        //        }
        //        finally
        //        {
        //            mycomm.Connection.Close();
        //        }
        //    }


        //    /// <summary>
        //    /// Executes a non parameterized stored procedure without returning a value
        //    /// </summary>
        //    /// <param name="connectionstring"></param>
        //    /// <param name="procedureName"></param>
        //    /// <param name="parameters"></param>
        //    public static void noReturn(string connectionstring, string procedureName)
        //    {
        //        SqlCommand mycomm = CreateCommand(connectionstring, procedureName);

        //        try
        //        {
        //            mycomm.Connection.Open();
        //            mycomm.ExecuteNonQuery();
        //        }
        //        catch (Exception exTrap)
        //        {
        //            DBAccessMethods.LogError(exTrap);
        //            throw exTrap;
        //        }
        //        finally
        //        {
        //            mycomm.Connection.Close();
        //        }
        //    }

        //    /// <summary>
        //    /// Executes a non parameterized stored procedure and returns a single string 
        //    /// </summary>
        //    /// <param name="connectionstring"></param>
        //    /// <param name="procedureName"></param>
        //    /// <param name="parameters"></param>
        //    /// <returns></returns>
        //    public static String ReturnString(string connectionstring, string procedureName)
        //    {
        //        string returnvalue;
        //        SqlCommand mycomm = CreateCommand(connectionstring, procedureName);
        //        try
        //        {
        //            mycomm.Connection.Open();
        //            returnvalue = (string)mycomm.ExecuteScalar();
        //            return returnvalue;
        //        }
        //        catch (Exception exTrap)
        //        {
        //            DBAccessMethods.LogError(exTrap);
        //            returnvalue = exTrap.Message;
        //            return returnvalue;
        //        }
        //        finally
        //        {
        //            mycomm.Connection.Close();
        //        }
        //    }

        //    /// <summary>
        //    /// Executes a non parameterized stored procedure and returns a single string 
        //    /// </summary>
        //    /// <param name="connectionstring"></param>
        //    /// <param name="procedureName"></param>
        //    /// <param name="parameters"></param>
        //    /// <returns></returns>
        //    public static DateTime ReturnDateTime(string connectionstring, string procedureName)
        //    {
        //        DateTime returnvalue = DateTime.MinValue;
        //        SqlCommand mycomm = CreateCommand(connectionstring, procedureName);
        //        try
        //        {
        //            mycomm.Connection.Open();
        //            returnvalue = (DateTime)mycomm.ExecuteScalar();
        //            return returnvalue;
        //        }
        //        catch (Exception exTrap)
        //        {
        //            DBAccessMethods.LogError(exTrap);
        //            //returnvalue = exTrap.Message;
        //            return returnvalue;
        //        }
        //        finally
        //        {
        //            mycomm.Connection.Close();
        //        }
        //    }

        //    /// <summary>
        //    /// Executes a non parameterized stored procedure and returns int 
        //    /// </summary>
        //    /// <param name="connectionstring"></param>
        //    /// <param name="procedureName"></param>
        //    /// <param name="parameters"></param>
        //    /// <returns></returns>
        //    public static Int32 ReturnInt(string connectionstring, string procedureName)
        //    {
        //        Int32 returnvalue;
        //        SqlCommand mycomm = CreateCommand(connectionstring, procedureName);
        //        try
        //        {
        //            mycomm.Connection.Open();
        //            returnvalue = Convert.ToInt32(mycomm.ExecuteScalar());
        //            return returnvalue;
        //        }
        //        catch (Exception exTrap)
        //        {
        //            DBAccessMethods.LogError(exTrap);
        //            //returnvalue = exTrap.Message;
        //            //return returnvalue;
        //            return -1;
        //        }
        //        finally
        //        {
        //            mycomm.Connection.Close();
        //        }
        //    }

        //    /// <summary>
        //    /// Executes a non parameterized stored procedure and returns a data table object
        //    /// </summary>
        //    /// <param name="connectionstring"></param>
        //    /// <param name="procedurename"></param>
        //    /// <param name="parameters"></param>
        //    /// <returns></returns>
        //    public static DataTable ReturnSet(string connectionstring, string procedurename)
        //    {
        //        DataTable returnvalue = new DataTable();
        //        SqlCommand mycomm = CreateCommand(connectionstring, procedurename);

        //        try
        //        {
        //            mycomm.Connection.Open();
        //            SqlDataReader reader = mycomm.ExecuteReader();
        //            returnvalue.Load(reader);
        //            return returnvalue;
        //        }
        //        catch (Exception exTrap)
        //        {
        //            DBAccessMethods.LogError(exTrap);
        //            HasError = true;
        //            ErrorMessage = exTrap.ToString();
        //            return returnvalue;
        //        }
        //        finally
        //        {
        //            mycomm.Connection.Close();
        //        }
        //    }
        //}
        #endregion

    }

}
