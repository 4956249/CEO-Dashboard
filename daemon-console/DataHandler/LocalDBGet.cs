using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using daemon_console.DataHandler;
using System.Data.SqlClient;
using System.Configuration;

namespace daemon_console.DataHandler
{
    public class LocalDBGet
    {
        //internal static DataTable GetUserMemebershipDetails()
        //{
        //    return DBAccessMethods.ExecNonParamStoredProc.ReturnSet(DBConnectionStrings.ServerDB
        //                                                                   , "usp_R_User_Membership_Details");
        //}
        static AuthenticationConfig config = AuthenticationConfig.ReadFromJsonFile("appsettings.json");

        public static string serverdb = config.serverdb;

        internal static string insert_CalendarResults(DataTable dt)
        {
            string qresult = "";
            try
            {
                qresult = DBAccessMethods.ExecParamStoredProc.ReturnString(serverdb
                                                                        , "dbo.p_insert_AzureCalendarEvents"
                                                                        , new SqlParameter("@MicrosoftGraphCalendar", dt)
                                                                        );
            }
            catch (Exception ex)
            {
                qresult = "Error:" + ex.Message;
            }
            return qresult;
        }


        //internal static DataTable GetUserDetail(string sAMAccount)
        //{
        //    return DBAccessMethods.ExecParamStoredProc.ReturnTable(DBConnectionStrings.ServerDB
        //                                                          , "usp_R_UserDetails_Per_sAMAccount"
        //                                                          , new SqlParameter("@sAMAccountName", sAMAccount));
        //}

        //internal static bool CheckIsMaintanance()
        //{
        //    string IsMaintanance;

        //    DataTable dt = DBAccessMethods.ExecNonParamStoredProc.ReturnSet(DBConnectionStrings.ServerDB
        //                                                                       , "usp_R_Check_IsMaintenance");

        //    IsMaintanance = dt.Rows[0]["IsMaintenance"].ToString();

        //    return Convert.ToBoolean(IsMaintanance);
        //}

        //internal static DataTable GetAllGroups()
        //{
        //    return DBAccessMethods.ExecNonParamStoredProc.ReturnSet(DBConnectionStrings.ServerDB
        //                                                           , "usp_R_GetAllGroups");
        //}

        //internal static DataTable GetAllPageNames()
        //{
        //    return DBAccessMethods.ExecNonParamStoredProc.ReturnSet(DBConnectionStrings.ServerDB
        //                                                           , "usp_R_GetAllPageNames");
        //}

        //internal static DataTable GetAccessToPagesPerGroup(string GroupName)
        //{
        //    return DBAccessMethods.ExecParamStoredProc.ReturnTable(DBConnectionStrings.ServerDB
        //                                                          , "usp_R_GetAccess_To_Pages_Per_Group"
        //                                                          , new SqlParameter("@GroupName", GroupName));
        //}

        //internal static DataTable CheckAccessToPagePerGroup(string PageName, string GroupName)
        //{
        //    return DBAccessMethods.ExecParamStoredProc.ReturnTable(DBConnectionStrings.ServerDB
        //                                                          , "usp_R_CheckAccessToPagePerGroup"
        //                                                          , new SqlParameter("@PageName", PageName)
        //                                                          , new SqlParameter("@GroupName", GroupName));
        //}

        //internal static bool InsertAccessToPagesPerGroup(string GroupName, List<string> Pages, List<bool> PageAccess)
        //{
        //    bool InsertCheck = false;

        //    for (int i = 0; i < Pages.Count; i++)
        //    {
        //        InsertCheck = DBAccessMethods.ExecParamStoredProc.ReturnBool(DBConnectionStrings.ServerDB
        //                                                                    , "usp_I_PageAccess_Per_Group"
        //                                                                    , new SqlParameter("@GroupName", GroupName)
        //                                                                    , new SqlParameter("@Page", Pages[i])
        //                                                                    , new SqlParameter("@PageAccess", PageAccess[i]));
        //    }

        //    return InsertCheck;
        //}

        //internal static bool AddUserToGroup(List<string> DisplayName, string GroupName)
        //{
        //    bool InsertUsers = false;

        //    foreach (string user in DisplayName)
        //    {
        //        InsertUsers = DBAccessMethods.ExecParamStoredProc.ReturnBool(DBConnectionStrings.ServerDB
        //                                                         , "usp_I_AddUserToGroup"
        //                                                         , new SqlParameter("@DisplayName", user)
        //                                                         , new SqlParameter("@GroupName", GroupName));
        //    }

        //    return InsertUsers;
        //}
        //internal static int ValidationBookingRequest(string servicecentre, string bookingdate, string bay, string requestnumber)
        //{
        //    int bookingopened = DBAccessMethods.ExecParamStoredProc.ReturnInt(DBConnectionStrings.ServerDB
        //                                             , "JDG_VBS.dbo.p_select_ValidationBookingRequest"
        //                                             , new SqlParameter("@servicecentre", servicecentre)
        //                                             , new SqlParameter("@bookingdate", bookingdate)
        //                                             , new SqlParameter("@bay", bay)
        //                                             , new SqlParameter("@requestnumber", requestnumber));
        //    return bookingopened;
        //}


        //internal static bool AddGroupToApp(string GroupName)
        //{
        //    return DBAccessMethods.ExecParamStoredProc.ReturnBool(DBConnectionStrings.ServerDB
        //                                                         , "usp_I_New_Group"
        //                                                         , new SqlParameter("@GroupName", GroupName));
        //}

        ////internal static bool existpo(string PONumber)
        ////{
        ////    string AccessGroup = DBAccessMethods.ExecParamStoredProc.ReturnString(DBConnectionStrings.ServerDB
        ////                                                                         , "p_exist_po"
        ////                                                                         , new SqlParameter("@sAMAccount", sAMAccount));

        ////    if (String.IsNullOrEmpty(AccessGroup))
        ////    {
        ////        return false;
        ////    }
        ////    else
        ////    {
        ////        return true;
        ////    }
        ////}


        //internal static bool CheckUserGroup(string sAMAccount)
        //{
        //    string AccessGroup = DBAccessMethods.ExecParamStoredProc.ReturnString(DBConnectionStrings.ServerDB
        //                                                                         , "usp_R_CheckUserRole"
        //                                                                         , new SqlParameter("@sAMAccount", sAMAccount));

        //    if (String.IsNullOrEmpty(AccessGroup))
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}

        //internal static DataTable SearchUser(string SearchText)
        //{
        //    return DBAccessMethods.ExecParamStoredProc.ReturnTable(DBConnectionStrings.ServerDB
        //                                                          , "usp_R_SearchUser"
        //                                                          , new SqlParameter("@SearchText", SearchText));
        //}

        //internal static DataTable getUserDetails(string SamAccount)
        //{
        //    return DBAccessMethods.ExecParamStoredProc.ReturnTable(DBConnectionStrings.ServerDB
        //                                                            , "sp_R_GetUserDetailsallApps"
        //                                                            , new SqlParameter("@Samaccount", SamAccount));
        //}

        //internal static DataTable getUserRole(string SamAccount)
        //{
        //    return DBAccessMethods.ExecParamStoredProc.ReturnTable(DBConnectionStrings.ServerDB
        //                                                            , "[JDG_VBS].[dbo].[sp_R_Get_User_Role]"
        //                                                            , new SqlParameter("@User", SamAccount));
        //}

        //internal static DataTable getSearchUser(string Search)
        //{
        //    return DBAccessMethods.ExecParamStoredProc.ReturnTable(DBConnectionStrings.ServerDB
        //                                                            , "sp_R_GetSearchUser"
        //                                                            , new SqlParameter("@Search", Search));
        //}

        //internal static DataTable getBUDetails(string BUCODE)
        //{
        //    return DBAccessMethods.ExecParamStoredProc.ReturnTable(DBConnectionStrings.ServerDB
        //                                                            , "sp_R_GetBUDetails"
        //                                                            , new SqlParameter("@BUCode", BUCODE));
        //}
        //internal static DataTable ChartData_12Months(string Vendor, string ServiceCentre, string Period, string bookingstatus, string VendorNumberCrypted)
        //{
        //    return DBAccessMethods.ExecParamStoredProc.ReturnTable(DBConnectionStrings.ServerDB
        //                                                            , "[JDG_VBS].[dbo].[p_select_chartData_12Months]"
        //                                                            , new SqlParameter("@Vendor", Vendor)
        //                                                            , new SqlParameter("@ServiceCentre", ServiceCentre)
        //                                                            , new SqlParameter("@Period", Period)
        //                                                            , new SqlParameter("@bookingStatus", bookingstatus)
        //                                                            , new SqlParameter("@VendorNumberCrypted", VendorNumberCrypted)
        //                                                            );
        //}

        //internal static DataTable getVendorUsers(string UserEncrypted)
        //{
        //    return DBAccessMethods.ExecParamStoredProc.ReturnTable(DBConnectionStrings.ServerDB
        //                                                            , "[JDG_VBS].[dbo].[p_select_getVendorUsers]"
        //                                                            , new SqlParameter("@encryptedstring", UserEncrypted)
        //                                                            );
        //}

        //internal static DataTable getVendorUsersComments(DataTable dtf)
        //{
        //    return DBAccessMethods.ExecParamStoredProc.ReturnTable(DBConnectionStrings.ServerDB
        //                                                            , "[JDG_VBS].[dbo].[p_select_getVendorUsersComments]"
        //                                                            , new SqlParameter("@encryptedstring", dtf)
        //                                                            );
        //}
        //internal static DataTable getMyBookingsTotals(string Vendor, string ServiceCentre, string Period)
        //{
        //    return DBAccessMethods.ExecParamStoredProc.ReturnTable(DBConnectionStrings.ServerDB
        //                                                            , "[JDG_VBS].[dbo].[sp_R_BookStatus_Stats]"
        //                                                            , new SqlParameter("@Vendor", Vendor)
        //                                                            , new SqlParameter("@ServiceCentre", ServiceCentre)
        //                                                            , new SqlParameter("@Period", Period)
        //                                                            );
        //}

        //internal static DataTable getMyBookingsSites(string Vendor, string Status, string ServiceCentre, string VendorNumberCrypted)
        //{
        //    return DBAccessMethods.ExecParamStoredProc.ReturnTable(DBConnectionStrings.ServerDB
        //                                                    , "[JDG_VBS].[dbo].[sp_R_get_Status_Sites]"
        //                                                    , new SqlParameter("@Vendor", Vendor)
        //                                                    , new SqlParameter("@Status", Status)
        //                                                    , new SqlParameter("@ServCentre", ServiceCentre)
        //                                                    , new SqlParameter("@VendorNumberCrypted", VendorNumberCrypted)
        //                                                    );
        //}

        //internal static DataTable getMyBookingsSites1(string Vendor, string ServCentre, string Status)
        //{
        //    return DBAccessMethods.ExecParamStoredProc.ReturnTable(DBConnectionStrings.ServerDB
        //                                                            , "[JDG_VBS].[dbo].[sp_R_get_Status_Sites1]"
        //                                                            , new SqlParameter("@Vendor", Vendor)
        //                                                            , new SqlParameter("@Status", Status)
        //                                                            , new SqlParameter("@ServCentre", ServCentre)
        //                                                            );
        //}

        //internal static DataTable validateSitePOQty(string Site, string PO)
        //{
        //    return DBAccessMethods.ExecParamStoredProc.ReturnTable(DBConnectionStrings.ServerDB
        //                                                            , "[JDG_VBS].[dbo].p_select_validateSitePOQty"
        //                                                            , new SqlParameter("@Site", Site)
        //                                                            , new SqlParameter("@PO", PO)
        //                                                            );
        //}

        //internal static DataTable getMyBookingsSiteStatus(string Vendor, string Status, string Site, string VendorNumberCrypted)
        //{
        //    return DBAccessMethods.ExecParamStoredProc.ReturnTable(DBConnectionStrings.ServerDB
        //                                                            , "[JDG_VBS].[dbo].[sp_R_get_Status_Sites_Requests]"
        //                                                            , new SqlParameter("@Vendor", Vendor)
        //                                                            , new SqlParameter("@Status", Status)
        //                                                            , new SqlParameter("@Site", Site)
        //                                                            , new SqlParameter("@VendorNumberCrypted", VendorNumberCrypted)
        //                                                            );
        //}

        //internal static DataTable getVendorDetails(string UserName, string Password)
        //{
        //    return DBAccessMethods.ExecParamStoredProc.ReturnTable(DBConnectionStrings.ServerDB
        //                                                            , "[JDG_VBS].[dbo].[sp_getVendorDetails]"
        //                                                            , new SqlParameter("@Username", UserName)
        //                                                            , new SqlParameter("@Password", Password)
        //                                                            );
        //}

        //internal static DataTable getInternalUsers()
        //{
        //    return DBAccessMethods.ExecParamStoredProc.ReturnTable(DBConnectionStrings.ServerDB
        //                                                            , "[JDG_VBS].[dbo].[sp_R_Internal_Users]"
        //                                                            );
        //}

        //internal static DataTable getExternalUsers(string selectedvendor)
        //{
        //    return DBAccessMethods.ExecParamStoredProc.ReturnTable(DBConnectionStrings.ServerDB
        //                                                            , "[JDG_VBS].[dbo].[sp_R_External_Users]"
        //                                                             , new SqlParameter("@selectedvendor", selectedvendor)
        //                                                           );
        //}
        //internal static DataTable searchExternalUsers(string searchcriteria)
        //{
        //    return DBAccessMethods.ExecParamStoredProc.ReturnTable(DBConnectionStrings.ServerDB
        //                                                            , "[JDG_VBS].[dbo].[p_select_searchExternalUsers]"
        //                                                            , new SqlParameter("@searchcriteria", searchcriteria)
        //                                                            );
        //}

        //internal static DataTable get_ddl_data(string Query)
        //{
        //    return DBAccessMethods.ExecNonParamStoredProc.ReturnSet(DBConnectionStrings.ServerDB
        //                                                           , Query);
        //}

        //internal static DataTable getEditData(string ID)
        //{
        //    return DBAccessMethods.ExecParamStoredProc.ReturnTable(DBConnectionStrings.ServerDB
        //                                                            , "[JDG_VBS].[dbo].[sp_R_getReq]"
        //                                                            , new SqlParameter("@ID", ID)
        //                                                            );
        //}

        //internal static DataTable getBookingData(string ID)
        //{
        //    return DBAccessMethods.ExecParamStoredProc.ReturnTable(DBConnectionStrings.ServerDB
        //                                                            , "[JDG_VBS].[dbo].[sp_R_getBookingData]"
        //                                                            , new SqlParameter("@ID", ID)
        //                                                            );
        //}
        //internal static DataTable getEditDataPO(string ID)
        //{
        //    return DBAccessMethods.ExecParamStoredProc.ReturnTable(DBConnectionStrings.ServerDB
        //                                                            , "[JDG_VBS].[dbo].[sp_R_getReqPO]"
        //                                                            , new SqlParameter("@ID", ID)
        //                                                            );
        //}

        //internal static DataTable getBookingRFC(string ID)
        //{
        //    return DBAccessMethods.ExecParamStoredProc.ReturnTable(DBConnectionStrings.ServerDB
        //                                                            , "[JDG_VBS].[dbo].[p_select_Booking_RFC]"
        //                                                            , new SqlParameter("@ID", ID)
        //                                                            );
        //}
        //internal static string insert_Save_BayAndSlot(string date, string bay, string email, string vendor, string trucksize, string ServiceCentre, string SlotKey, String reqNum)
        //{
        //    return DBAccessMethods.ExecParamStoredProc.ReturnString(DBConnectionStrings.ServerDB
        //                                                            , "[JDG_VBS].[dbo].[p_insert_Save_BayAndSlot]"
        //                                                            , new SqlParameter("@RequestedBookingDate", date)
        //                                                            , new SqlParameter("@Bay", bay)
        //                                                            , new SqlParameter("@email", email)
        //                                                            , new SqlParameter("@Vendor", vendor)
        //                                                            , new SqlParameter("@TruckSize", trucksize)
        //                                                            , new SqlParameter("@ServiceCentre", ServiceCentre)
        //                                                            , new SqlParameter("@SlotKey", SlotKey)
        //                                                            , new SqlParameter("@reqNum", reqNum)

        //                                                            );
        //}

        //internal static string p_insert_NewUser(string bclicked, string EmployeeNumber, string Permission, string ServiceCentre)
        //{
        //    string result = "";
        //    result = DBAccessMethods.ExecParamStoredProc.ReturnString(DBConnectionStrings.ServerDB
        //                                                            , "[JDG_VBS].[dbo].[p_insert_NewUser]"
        //                                                            , new SqlParameter("@bclicked", bclicked)
        //                                                            , new SqlParameter("@EmployeeNumber", EmployeeNumber)
        //                                                            , new SqlParameter("@Permission", Permission)
        //                                                            , new SqlParameter("@ServiceCentre", ServiceCentre)

        //                                                            );
        //    return result;
        //}
        //internal static void logVBSexception(string log, string username)
        //{
        //    DBAccessMethods.ExecParamStoredProc.ReturnTable(DBConnectionStrings.ServerDB
        //                                                            , "[JDG_VBS].[dbo].[p_Insert_logVBSexception]"
        //                                                            , new SqlParameter("@log", log)
        //                                                            , new SqlParameter("@username", username)
        //                                                            );
        //}

        //internal static string p_insert_NewVendor(string bclicked, string EmployeeNumber, string UserName, string SupplierName, string FriendlyName, string vPassword, string vrowid)
        //{
        //    string result = "";
        //    result = DBAccessMethods.ExecParamStoredProc.ReturnString(DBConnectionStrings.ServerDB
        //                                                            , "[JDG_VBS].[dbo].[p_insert_NewVendor]"
        //                                                            , new SqlParameter("@bclicked", bclicked)
        //                                                            , new SqlParameter("@EmployeeNumber", EmployeeNumber)
        //                                                            , new SqlParameter("@UserName", UserName)
        //                                                            , new SqlParameter("@SupplierName", SupplierName)
        //                                                            , new SqlParameter("@FriendlyName", FriendlyName)
        //                                                            , new SqlParameter("@vPassword", vPassword)
        //                                                            , new SqlParameter("@vrowid", vrowid)

        //                                                            );
        //    return result;
        //}

        //internal static string insert_LockBayAndSlot(string date, string bay, string email, string vendor, string trucksize, string ServiceCentre, string SlotKey, string ReqNumber)
        //{
        //    return DBAccessMethods.ExecParamStoredProc.ReturnString(DBConnectionStrings.ServerDB
        //                                                            , "[JDG_VBS].[dbo].[p_insert_LockBayAndSlot]"
        //                                                            , new SqlParameter("@RequestedBookingDate", date)
        //                                                            , new SqlParameter("@Bay", bay)
        //                                                            , new SqlParameter("@email", email)
        //                                                            , new SqlParameter("@Vendor", vendor)
        //                                                            , new SqlParameter("@TruckSize", trucksize)
        //                                                            , new SqlParameter("@ServiceCentre", ServiceCentre)
        //                                                            , new SqlParameter("@SlotKey", SlotKey)
        //                                                            , new SqlParameter("@ReqNumber", ReqNumber)
        //                                                            );
        //}

        //internal static string insert_replaceBayAndSlot(string date, string bay, string email, string vendor, string trucksize, string ServiceCentre, string SlotKey)
        //{
        //    return DBAccessMethods.ExecParamStoredProc.ReturnString(DBConnectionStrings.ServerDB
        //                                                            , "[JDG_VBS].[dbo].[p_insert_replaceBayAndSlot]"
        //                                                            , new SqlParameter("@RequestedBookingDate", date)
        //                                                            , new SqlParameter("@Bay", bay)
        //                                                            , new SqlParameter("@email", email)
        //                                                            , new SqlParameter("@Vendor", vendor)
        //                                                            , new SqlParameter("@TruckSize", trucksize)
        //                                                            , new SqlParameter("@ServiceCentre", ServiceCentre)
        //                                                            , new SqlParameter("@SlotKey", SlotKey)
        //                                                            );
        //}
        //internal static string delete_bayslotReplaceTruckCancel(/*string date, string bay, string email, string vendor, string trucksize, string ServiceCentre, */string SlotKey, string ReqNumber)
        //{
        //    return DBAccessMethods.ExecParamStoredProc.ReturnString(DBConnectionStrings.ServerDB
        //                                                            , "[JDG_VBS].[dbo].[p_delete_bayslotReplaceTruckCancel]"
        //                                                            //, new SqlParameter("@RequestedBookingDate", date)
        //                                                            //, new SqlParameter("@Bay", bay)
        //                                                            //, new SqlParameter("@email", email)
        //                                                            //, new SqlParameter("@Vendor", vendor)
        //                                                            //, new SqlParameter("@TruckSize", trucksize)
        //                                                            //, new SqlParameter("@ServiceCentre", ServiceCentre)
        //                                                            , new SqlParameter("@SlotKey", SlotKey)
        //                                                            , new SqlParameter("@ReqNumber", ReqNumber)
        //                                                            );
        //}
        //internal static DataTable getEditDataLabels(string ID)
        //{
        //    return DBAccessMethods.ExecParamStoredProc.ReturnTable(DBConnectionStrings.ServerDB
        //                                                            , "[JDG_VBS].[dbo].[sp_R_getReqLabels]"
        //                                                            , new SqlParameter("@ID", ID)
        //                                                            );
        //}

        //internal static DataTable saveData(string Query)
        //{
        //    return DBAccessMethods.ExecNonParamStoredProc.ReturnSet(DBConnectionStrings.ServerDB
        //                                                           , Query);
        //}

        //internal static void saveonly(string Query)
        //{
        //    DBAccessMethods.ExecNonParamStoredProc.ReturnSet(DBConnectionStrings.ServerDB
        //                                                           , Query);
        //}
        //internal static string Save_newRequest(string Query)
        //{
        //    return DBAccessMethods.ExecNonParamStoredProc.ReturnString(DBConnectionStrings.ServerDB
        //                                                           , Query);
        //}
        //internal static string saveEditBooking(DataTable inbdel)
        //{
        //    string qresult = "";
        //    try
        //    {
        //        qresult = DBAccessMethods.ExecParamStoredProc.ReturnString(DBConnectionStrings.ServerDB
        //                                                            , "[JDG_VBS].[dbo].[p_update_saveEditBooking]"
        //                                                            , new SqlParameter("@requestTable", inbdel)
        //                                                            );
        //    }
        //    catch (Exception ex)
        //    {
        //        qresult = "Error|" + ex.Message;
        //    }
        //    return qresult;
        //}

        //internal static DataTable reset_Vendor_Password(string UserName, string SecurityQuestion)
        //{
        //    return DBAccessMethods.ExecParamStoredProc.ReturnTable(DBConnectionStrings.ServerDB
        //                                                            , "[JDG_VBS].[dbo].[sp_Reset_Vendor_Password]"
        //                                                            , new SqlParameter("@UserName", UserName)
        //                                                            , new SqlParameter("@SecurityQuestion", SecurityQuestion)
        //                                                            );
        //}

        //internal static DataTable change_Vendor_Password(string UserName, string SecurityQuestion, string Password)
        //{
        //    return DBAccessMethods.ExecParamStoredProc.ReturnTable(DBConnectionStrings.ServerDB
        //                                                            , "[JDG_VBS].[dbo].[sp_Change_Vendor_Password]"
        //                                                            , new SqlParameter("@UserName", UserName)
        //                                                            , new SqlParameter("@SecurityQuestion", SecurityQuestion)
        //                                                            , new SqlParameter("@Password", Password)
        //                                                            );
        //}

        //internal static DataTable getVendorBookings(string Vendor, string Status, string Period)
        //{
        //    return DBAccessMethods.ExecParamStoredProc.ReturnTable(DBConnectionStrings.ServerDB
        //                                                            , "[JDG_VBS].[dbo].[sp_R_get_Vendor_Requests]"
        //                                                            , new SqlParameter("@Vendor", Vendor)
        //                                                            , new SqlParameter("@Status", Status)
        //                                                            , new SqlParameter("@Period", Period)
        //                                                            );
        //}

        //internal static DataTable getStatus()
        //{
        //    return DBAccessMethods.ExecNonParamStoredProc.ReturnSet(DBConnectionStrings.ServerDB
        //                                                           , "[JDG_VBS].[dbo].[sp_R_get_status]"
        //                                                           );
        //}

        //internal static DataTable getUploadData(string File)
        //{
        //    return DBAccessMethods.ExecParamStoredProc.ReturnTable(DBConnectionStrings.ServerDB
        //                                                            , "[JDG_VBS].[dbo].[sp_Get_Upload_Data]"
        //                                                            , new SqlParameter("@file", File)
        //                                                            );
        //}

        //internal static DataSet getBookings(string ServiceCentre, string TruckSize, string Date)
        //{
        //    return DBAccessMethods.ExecParamStoredProc.ReturnDataSet(DBConnectionStrings.ServerDB
        //                                                           , "[JDG_VBS].[dbo].[sp_Booking_details]"
        //                                                           , new SqlParameter("@ServiceCentre", ServiceCentre)
        //                                                           , new SqlParameter("@TruckSize", TruckSize)
        //                                                           , new SqlParameter("@Date", Date));
        //}

        //internal static bool SaveExternal(string UserName, string DisplayName, string VendorCodes, string FriendlyName)
        //{
        //    return DBAccessMethods.ExecParamStoredProc.ReturnBool(DBConnectionStrings.ServerDB
        //                                                         , "[JDG_VBS].[dbo].[sp_I_ExternalUsers]"
        //                                                         , new SqlParameter("@UserName", UserName)
        //                                                         , new SqlParameter("@DisplayName", DisplayName)
        //                                                         , new SqlParameter("@VendorCodes", VendorCodes)
        //                                                         , new SqlParameter("@FriendlyName", FriendlyName)
        //                                                         );
        //}

        //internal static DataSet LoadSiteMaintenance(string Site)
        //{
        //    return DBAccessMethods.ExecParamStoredProc.ReturnDataSet(DBConnectionStrings.ServerDB
        //                                                           , "[JDG_VBS].[dbo].[sp_R_SiteData]"
        //                                                           , new SqlParameter("@ServiceCentre", Site));
        //}

        //internal static bool AddSiteMaintenance(string Site, string Date, string StartTime, string EndTime, string Bays)
        //{
        //    return DBAccessMethods.ExecParamStoredProc.ReturnBool(DBConnectionStrings.ServerDB
        //                                                         , "[JDG_VBS].[dbo].[sp_I_SiteMaintenance]"
        //                                                         , new SqlParameter("@Site", Site)
        //                                                         , new SqlParameter("@Date", Date)
        //                                                         , new SqlParameter("@StartTime", StartTime)
        //                                                         , new SqlParameter("@EndTime", EndTime)
        //                                                         , new SqlParameter("@Bays", Bays)
        //                                                         );
        //}

        //internal static bool SavePOInvoice(int ID, string RequestNumber, string PO, byte[] filename)
        //{
        //    return DBAccessMethods.ExecParamStoredProc.ReturnBool(DBConnectionStrings.ServerDB
        //                                                         , "[JDG_VBS].[dbo].[sp_I_PO_Images]"
        //                                                         , new SqlParameter("@ID", ID)
        //                                                         , new SqlParameter("@RequestNumber", RequestNumber)
        //                                                         , new SqlParameter("@PO", PO)
        //                                                         , new SqlParameter("@@POImage", filename)
        //                                                         );
        //}

        //internal static bool saveInvoiceNumber(int ID, string ReqID, string ponumber, string invoicenumber)
        //{
        //    //try
        //    //{
        //    return DBAccessMethods.ExecParamStoredProc.ReturnBool(DBConnectionStrings.ServerDB
        //                                                         , "[JDG_VBS].[dbo].[sp_I_PO_InvoiceNumber]"
        //                                                         , new SqlParameter("@ID", ID)
        //                                                         , new SqlParameter("@RequestNumber", ReqID)
        //                                                         , new SqlParameter("@PO", ponumber)
        //                                                         , new SqlParameter("@InvoiceNumber", invoicenumber)
        //                                                         );
        //    //}
        //    //catch (Exception elian)
        //    //{
        //    //    return false;

        //    //}
        //}

        //internal static bool DeletePORequest(int ID, string ReqID, string ponumber)
        //{
        //    return DBAccessMethods.ExecParamStoredProc.ReturnBool(DBConnectionStrings.ServerDB
        //                                                         , "[JDG_VBS].[dbo].[sp_U_Delete_PORequest]"
        //                                                         , new SqlParameter("@ID", ID)
        //                                                         , new SqlParameter("@RequestNumber", ReqID)
        //                                                         , new SqlParameter("@PO", ponumber)
        //                                                         );
        //}

        ////Site: sites, Startdate: startdate, Enddate: enddate, Timeslots: timeslots, Bays: bays, Action: action, Disablesites: disablesites, texttosuppliers: texttosuppliers, baytype: baytype, alldaysite: alldaysite, resetendtime: resetendtime

        //internal static string UpdateSiteMaintenance(string Site, string Startdate, string Enddate, string Timeslots, string Bays, string Action)
        //{
        //    string result = "";
        //    result = DBAccessMethods.ExecParamStoredProc.ReturnString(DBConnectionStrings.ServerDB
        //                                                         , "[JDG_VBS].[dbo].[p_insert_SiteMaintenance]"
        //                                                         , new SqlParameter("@Action", Action)
        //                                                         , new SqlParameter("@Site", Site)
        //                                                         , new SqlParameter("@StartDate", Startdate)
        //                                                         , new SqlParameter("@EndDate", Enddate)
        //                                                         , new SqlParameter("@Slots", Timeslots)
        //                                                          , new SqlParameter("@Bays", Bays)
        //                                                        );
        //    return result;
        //}

        //internal static DataTable GetInvoiceDocument(string ID)
        //{
        //    return DBAccessMethods.ExecParamStoredProc.ReturnTable(DBConnectionStrings.ServerDB
        //                                                         , "[JDG_VBS].[dbo].[p_select_GetInvoiceDocument]"
        //                                                         , new SqlParameter("@ID", ID)
        //                                                        );
        //}
        //internal static DataTable GetSiteCode(string Site)
        //{
        //    return DBAccessMethods.ExecParamStoredProc.ReturnTable(DBConnectionStrings.ServerDB
        //                                                            , "[JDG_VBS].[dbo].[sp_R_Get_Site_Code]"
        //                                                            , new SqlParameter("@Site", Site)
        //                                                            );
        //}

        //internal static DataTable GetReleaseTrat(string RelStrat, string RelStat)
        //{
        //    return DBAccessMethods.ExecParamStoredProc.ReturnTable(DBConnectionStrings.ServerDB
        //                                                            , "[JDG_VBS].[dbo].[sp_R_Release_Strategy]"
        //                                                            , new SqlParameter("@RelStrat", RelStrat)
        //                                                            , new SqlParameter("@RelStat", RelStat)
        //                                                            );
        //}

        //internal static DataTable getPOInvoice(string ID, string PO)
        //{
        //    return DBAccessMethods.ExecParamStoredProc.ReturnTable(DBConnectionStrings.ServerDB
        //                                                            , "[JDG_VBS].[dbo].[sp_R_getPOInvoice]"
        //                                                            , new SqlParameter("@ID", ID)
        //                                                            , new SqlParameter("@PO", PO)
        //                                                            );
        //}

        //internal static void UpdateInbDelivery(string ID, string PONumber, string Delivery)
        //{
        //    DBAccessMethods.ExecParamStoredProc.ReturnTable(DBConnectionStrings.ServerDB
        //                                                            , "[JDG_VBS].[dbo].[sp_U_PODel]"
        //                                                            , new SqlParameter("@ID", ID)
        //                                                            , new SqlParameter("@PO", PONumber)
        //                                                            , new SqlParameter("@Del", Delivery)
        //                                                            );
        //}
        //internal static string Addnewuser(string NewUser, int UserRole)
        //{
        //    return DBAccessMethods.ExecParamStoredProc.ReturnString(DBConnectionStrings.ServerDB
        //                                                            , "[Implats_MasterGroup].[dbo].[p_insert_NewUser]"
        //                                                            , new SqlParameter("@newuser", NewUser)
        //                                                            , new SqlParameter("@userrole", UserRole)
        //                                                            );

        //}
        //internal static DataTable toPringNominationBooking(string startdate, string enddate, int trainingprocess, string trainingcentre)
        //{
        //    return DBAccessMethods.ExecParamStoredProc.ReturnTable(DBConnectionStrings.ServerDB
        //                                                            , "[Implats_MasterGroup].[dbo].[p_select_Print_Booking]"
        //                                                            , new SqlParameter("@startdate", startdate)
        //                                                            , new SqlParameter("@enddate", enddate)
        //                                                            , new SqlParameter("@trainingprocess", trainingprocess)
        //                                                            , new SqlParameter("@trainingcentre", trainingcentre)
        //                                                            );

        //}
        //internal static DataTable GetData(string userName)
        //{
        //    return DBAccessMethods.ExecParamStoredProc.ReturnTable(DBConnectionStrings.ServerDB
        //                                                            , "[Implats_MasterGroup].[dbo].[p_select_Nomination_Getdata]"
        //                                                            , new SqlParameter("@userName", userName)
        //                                                            );

        //}
        //internal static string GetAPIInfo(string applicationname)
        //{
        //    return DBAccessMethods.ExecParamStoredProc.ReturnString(DBConnectionStrings.ServerDB
        //                                                            , "[Implats_MasterGroup].[dbo].[p_select_API_SysIntegrate]"
        //                                                            , new SqlParameter("@applicationname", applicationname)
        //                                                            );

        //}
        //internal static DataTable GetRFCCode(string VendorNumber, string Site)
        //{
        //    //string qresult = "|";
        //    //try
        //    //{
        //    return DBAccessMethods.ExecParamStoredProc.ReturnTable(DBConnectionStrings.ServerDB
        //                                                            , "[JDG_VBS].[dbo].[p_select_VBS_Vendor_RFC]"
        //                                                            , new SqlParameter("@VendorUserName", VendorNumber)
        //                                                            , new SqlParameter("@Site", Site)
        //                                                            );
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    qresult = "Error|" + ex.Message;
        //    //}
        //    //return qresult;
        //}

        //internal static string DeclineBookingRequest(string ID, string vuser, string vemail, string comments)
        //{
        //    string qresult = "|";
        //    try
        //    {
        //        qresult = DBAccessMethods.ExecParamStoredProc.ReturnString(DBConnectionStrings.ServerDB
        //                                                                , "[JDG_VBS].[dbo].[p_insert_DeclineBookingRequest]"
        //                                                                , new SqlParameter("@ID", ID)
        //                                                                , new SqlParameter("@vuser", vuser)
        //                                                                , new SqlParameter("@vemail", vemail)
        //                                                                , new SqlParameter("@comments", comments)
        //                                                                );
        //    }
        //    catch (Exception ex)
        //    {
        //        qresult = "Error|" + ex.Message;
        //    }
        //    return qresult;
        //}

        //internal static string Insert_NewBookingRequest(DataTable dt, string date, string bcomments, string bay, string email, string vendor, string trucksize, string ServiceCentre, string rfc_IDs)
        //{
        //    string qresult = "|";
        //    try
        //    {
        //        qresult = DBAccessMethods.ExecParamStoredProc.ReturnString(DBConnectionStrings.ServerDB
        //                                                                , "[JDG_VBS].[dbo].Insert_NewBookingRequest"
        //                                                                , new SqlParameter("@bdate", date)
        //                                                                , new SqlParameter("@bcomments", bcomments)
        //                                                                , new SqlParameter("bay", bay)
        //                                                                , new SqlParameter("@email", email)
        //                                                                , new SqlParameter("@vendor", vendor)
        //                                                                , new SqlParameter("@trucksize", trucksize)
        //                                                                , new SqlParameter("@servicecentre", ServiceCentre)
        //                                                                , new SqlParameter("@requestTable", dt)
        //                                                                , new SqlParameter("@rfc_IDs", rfc_IDs)
        //                                                                //, new SqlParameter("@createdby", ServiceCentre)
        //                                                                );
        //    }
        //    catch (Exception ex)
        //    {
        //        qresult = "Error|" + ex.Message;
        //    }
        //    return qresult;
        //}

        //internal static string UpdateInbound(string inbdelivery, string bid)
        //{
        //    string qresult = "|";
        //    try
        //    {
        //        qresult = DBAccessMethods.ExecParamStoredProc.ReturnString(DBConnectionStrings.ServerDB
        //                                                                , "[JDG_VBS].[dbo].[p_update_Inbound]"
        //                                                                , new SqlParameter("@inbdelivery", inbdelivery)
        //                                                                , new SqlParameter("@bid", bid)
        //                                                                );
        //    }
        //    catch (Exception ex)
        //    {
        //        qresult = "Error|" + ex.Message;
        //    }
        //    return qresult;
        //}

        //internal static string ApproveRequest(DataTable inbdel, string bid, string BookingStatus, string Requestdate, string vemail, string vuser, string trucks, string bcomments, string bay)
        //{
        //    string qresult = "|";
        //    try
        //    {
        //        qresult = DBAccessMethods.ExecParamStoredProc.ReturnString(DBConnectionStrings.ServerDB
        //                                                                , "[JDG_VBS].[dbo].[p_insert_newApproved_Request]"
        //                                                                , new SqlParameter("@requestTable", inbdel)
        //                                                                , new SqlParameter("@bid", bid)
        //                                                                , new SqlParameter("@BookingStatus", BookingStatus)
        //                                                                , new SqlParameter("@Requestdate", Requestdate)
        //                                                                , new SqlParameter("@vemail", vemail)
        //                                                                , new SqlParameter("@vuser", vuser)
        //                                                                , new SqlParameter("@trucks", trucks)
        //                                                                , new SqlParameter("@bcomments", bcomments)
        //                                                                , new SqlParameter("@bay", bay)
        //                                                                );
        //    }
        //    catch (Exception ex)
        //    {
        //        qresult = "Error|" + ex.Message;
        //    }
        //    return qresult;
        //}
        //internal static string update_VendorsBookingHeader(string ID, string status, string RequestNumber, string vemail, string vendor, string trucks, string bcomments)
        //{
        //    string qresult = "|";
        //    try
        //    {
        //        qresult = DBAccessMethods.ExecParamStoredProc.ReturnString(DBConnectionStrings.ServerDB
        //                                                                , "[JDG_VBS].[dbo].[update_VendorsBookingHeader]"
        //                                                                , new SqlParameter("@ID", ID)
        //                                                                , new SqlParameter("@status", status)
        //                                                                , new SqlParameter("@Req", RequestNumber)
        //                                                                , new SqlParameter("@vemail", vemail)
        //                                                                , new SqlParameter("@vendor", vendor)
        //                                                                , new SqlParameter("@trucks", trucks)
        //                                                                , new SqlParameter("@bcomments", bcomments)
        //                                                                );
        //    }
        //    catch (Exception ex)
        //    {
        //        qresult = "Error|" + ex.Message;
        //    }
        //    return qresult;
        //}

        //internal static string insert_comment(string reqID, string tcomment, string UserID, string fullDate)
        //{
        //    string qresult = "|";
        //    try
        //    {
        //        qresult = DBAccessMethods.ExecParamStoredProc.ReturnString(DBConnectionStrings.ServerDB
        //                                                                , "[JDG_VBS].[dbo].[p_insert_Vendor_Comments]"
        //                                                                , new SqlParameter("@reqID", reqID)
        //                                                                , new SqlParameter("@tcomment", tcomment)
        //                                                                , new SqlParameter("@UserID", UserID)
        //                                                                , new SqlParameter("@fullDate", fullDate)
        //                                                                );
        //    }
        //    catch (Exception ex)
        //    {
        //        qresult = "Error|" + ex.Message;
        //    }
        //    return qresult;

        //}


    }
}
