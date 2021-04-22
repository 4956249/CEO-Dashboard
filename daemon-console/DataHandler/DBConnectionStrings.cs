using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.IdentityModel.Protocols;

namespace daemon_console.DataHandler
{
    public class DBConnectionStrings
    {
        private static string serverdb;
        //private static string serverNewsFeed;
        //private static string serverActionNoteFeed;
        //private static string serverCMS;
        //private static string serverJD;

        static DBConnectionStrings()
        {

            serverdb = ConfigurationManager.ConnectionStrings["ServerDB"].ConnectionString;
            //serverNewsFeed = ConfigurationManager.ConnectionStrings["ServerDBNewsFeed"].ConnectionString;
            //serverActionNoteFeed = ConfigurationManager.ConnectionStrings["ServerDBTableActionNoteFeed"].ConnectionString;
            //serverCMS = ConfigurationManager.ConnectionStrings["ServerDBCMS"].ConnectionString;
            //serverJD = ConfigurationManager.ConnectionStrings["ServerJD"].ConnectionString;
            //Testing
            //PROD
            //serverdb = @"Data Source=jdgitservices;Initial Catalog=JDG_MasterData_Group;uid=appdev;password=@ppd3v";
            //DEV
            //serverdb = @"Data Source=jdgitservicedev;Initial Catalog=JDG_MasterData_Group;User ID=devtest;Password=devtest;Integrated Security=True;";
        }

        /// <summary>
        /// A SQL Server database (RMS)
        /// </summary>
        public static string ServerDB
        {
            get
            {
                return serverdb;
            }
        }

        //public static string ServerCMS
        //{
        //    //get
        //    //{
        //    //    return serverCMS;
        //    //}
        //}

        //public static string ServerNewsFeed
        //{
        //    //get
        //    //{
        //    //    return serverNewsFeed;
        //    //}
        //}

        //public static string ServerActionNoteFeed
        //{
        //    //get
        //    //{
        //    //    return serverActionNoteFeed;
        //    //}
        //}

        //public static string ServerJD
        //{
        //    //get
        //    //{
        //    //    return serverJD;
        //    //}
        //}
    }
}
