using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using daemon_console.DataHandler;
using System.Data;
using System.Net.Mail;
using System.Security.Cryptography;
using System.IO;


namespace daemon_console.DataHandler
{
    public class LocalGetController
    {
        //internal bool CheckIsMaintanance()
        //{
        //    return LocalDBGet.CheckIsMaintanance();
        //}

        //internal DataTable GetAllGroups()
        //{
        //    return LocalDBGet.GetAllGroups();
        //}

        //internal DataTable GetAllPageNames()
        //{
        //    return LocalDBGet.GetAllPageNames();
        //}

        //internal DataTable GetAccessToPagePerGroup(string GroupName)
        //{
        //    return LocalDBGet.GetAccessToPagesPerGroup(GroupName);
        //}

        //internal DataTable CheckAccessToPagePerGroup(string PageName, string GroupName)
        //{
        //    return LocalDBGet.CheckAccessToPagePerGroup(PageName, GroupName);
        //}

        //internal bool InsertAccessToPagesPerGroup(string GroupName, List<string> Pages, List<bool> PageAccess)
        //{
        //    return LocalDBGet.InsertAccessToPagesPerGroup(GroupName, Pages, PageAccess);
        //}

        //internal bool AddUserToGroup(List<string> DisplayName, string GroupName)
        //{
        //    return LocalDBGet.AddUserToGroup(DisplayName, GroupName);
        //}

        //internal int ValidationBookingRequest(string servicecentre, string bookingdate, string bay, string requestnumber)
        //{
        //    return LocalDBGet.ValidationBookingRequest(servicecentre, bookingdate, bay, requestnumber);
        //}
        //internal bool AddGroupToApp(string GroupName)
        //{
        //    return LocalDBGet.AddGroupToApp(GroupName);
        //}

        //internal bool CheckUserGroup(string sAMAccount)
        //{
        //    return LocalDBGet.CheckUserGroup(sAMAccount);
        //}

        //internal bool InValidDataTable(string ColumnName, DataTable dtTest, int dtIndex)
        //{
        //    return DBAccessMethods.InValidDataTable(ColumnName, dtTest, dtIndex);
        //}

        //internal DataTable SearchUser(string SearchText)
        //{
        //    return LocalDBGet.SearchUser(SearchText);
        //}

        //internal DataTable getUserDetails(string SamAccount)
        //{
        //    return LocalDBGet.getUserDetails(SamAccount);
        //}

        //internal DataTable getUserRole(string SamAccount)
        //{
        //    return LocalDBGet.getUserRole(SamAccount);
        //}

        //internal DataTable getBUDetails(string BUCODE)
        //{
        //    return LocalDBGet.getBUDetails(BUCODE);
        //}

        //internal void MailClient(MailMessage message)
        //{
        //    SmtpClient _smtpClient;

        //    string OutgoingServer = "jdgexchhub.jdg.co.za";

        //    int SMTPPort = 25;

        //    message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess;
        //    message.IsBodyHtml = true;
        //    message.Priority = MailPriority.Normal;

        //    _smtpClient = new SmtpClient(OutgoingServer)
        //    {
        //        DeliveryMethod = SmtpDeliveryMethod.Network,
        //        Port = SMTPPort
        //    };

        //    _smtpClient.Send(message);
        //}

        //internal void Send_Mail_New(string to, string name, string subject, string From, string Systems)//, string body)
        //{
        //    MailMessage mailMessage = new MailMessage()
        //    {
        //        From = new MailAddress("noreply@jdg.co.za"),
        //        Subject = subject,
        //        Body = "Dear " + name + "<p/> " + From + " created an authorisation request for the following system (s)," + "<p/>" + Systems + "<p/>" + "Please click the link below to Authorise all your outstanding Requests" + "<p/>" + "http://jdgitservices:8088/PL/SignIn.aspx"//+ body + ""
        //    };

        //    mailMessage.To.Add(to.ToString());
        //    mailMessage.IsBodyHtml = true;
        //    MailClient(mailMessage);

        //}

        ////internal DataTable getUserMaintenance(int pageIndex)
        ////{
        ////    return LocalDBGet.getUserMaintenance(pageIndex);
        ////}

        ////internal DataTable getGroupMaintenance(int pageIndex)
        ////{
        ////    return LocalDBGet.getGroupMaintenance(pageIndex);
        ////}

        ////internal bool deleteUserMaintenance(string id)
        ////{
        ////    return LocalDBGet.deleteUserMaintenance(id);
        ////}

        ////internal bool deleteGroupMaintenance(string id)
        ////{
        ////    return LocalDBGet.deleteGroupMaintenance(id);
        ////}

        ////internal bool insertUserMaintenance(string sAMAccountName, string DisplayName, string Access)
        ////{
        ////    return LocalDBGet.insertUserMaintenance(sAMAccountName, DisplayName, Access);
        ////}

        //internal DataTable getSearchUser(string Search)
        //{
        //    return LocalDBGet.getSearchUser(Search);
        //}

        ////internal DataTable getGroups()
        ////{
        ////    return LocalDBGet.getGroups();
        ////}
        //internal DataTable ChartData_12Months(string Vendor, string ServiceCentre, string Period, string bookingstatus, string VendorNumberCrypted)
        //{
        //    return LocalDBGet.ChartData_12Months(Vendor, ServiceCentre, Period, bookingstatus, VendorNumberCrypted);
        //}

        ////}
        //internal DataTable getVendorUsers(string UserEncrypted)
        //{
        //    return LocalDBGet.getVendorUsers(UserEncrypted);
        //}

        //internal DataTable getVendorUsersComments(DataTable dtf)
        //{
        //    return LocalDBGet.getVendorUsersComments(dtf);
        //}


        //internal DataTable getMyBookingsTotals(string Vendor, string ServiceCentre, string Period)
        //{
        //    return LocalDBGet.getMyBookingsTotals(Vendor, ServiceCentre, Period);
        //}

        //internal DataTable getMyBookingsSites(string Vendor, string Status, string ServiceCentre, string VendorNumberCrypted)
        //{
        //    return LocalDBGet.getMyBookingsSites(Vendor, Status, ServiceCentre, VendorNumberCrypted);
        //}

        //internal DataTable getMyBookingsSites1(string Vendor, string ServCentre, string Status)
        //{
        //    return LocalDBGet.getMyBookingsSites1(Vendor, ServCentre, Status);
        //}

        //internal DataTable getMyBookingsSiteStatus(string Vendor, string Status, string Site, string VendorNumberCrypted)
        //{
        //    return LocalDBGet.getMyBookingsSiteStatus(Vendor, Status, Site, VendorNumberCrypted);
        //}

        //internal DataTable getVendorBookings(string Vendor, string Status, string Period)
        //{
        //    return LocalDBGet.getVendorBookings(Vendor, Status, Period);
        //}

        //internal DataTable getVendorDetails(string UserName, string Password)
        //{
        //    return LocalDBGet.getVendorDetails(UserName, Password);
        //}

        //public string OpenEC(string clearText)
        //{
        //    string EncryptionKey = "abc123";
        //    byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
        //    using (Aes encryptor = Aes.Create())
        //    {
        //        Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
        //        encryptor.Key = pdb.GetBytes(32);
        //        encryptor.IV = pdb.GetBytes(16);
        //        using (MemoryStream ms = new MemoryStream())
        //        {
        //            using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
        //            {
        //                cs.Write(clearBytes, 0, clearBytes.Length);
        //                cs.Close();
        //            }
        //            clearText = Convert.ToBase64String(ms.ToArray());
        //        }
        //    }
        //    return clearText;
        //}

        //public string CloseDC(string cipherText)
        //{
        //    string EncryptionKey = "abc123";
        //    cipherText = cipherText.Replace(" ", "+");
        //    byte[] cipherBytes = Convert.FromBase64String(cipherText);
        //    using (Aes encryptor = Aes.Create())
        //    {
        //        Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
        //        encryptor.Key = pdb.GetBytes(32);
        //        encryptor.IV = pdb.GetBytes(16);
        //        using (MemoryStream ms = new MemoryStream())
        //        {
        //            using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
        //            {
        //                cs.Write(cipherBytes, 0, cipherBytes.Length);
        //                cs.Close();
        //            }
        //            cipherText = Encoding.Unicode.GetString(ms.ToArray());
        //        }
        //    }
        //    return cipherText;
        //}

        //internal DataTable getInternalUsers()
        //{
        //    return LocalDBGet.getInternalUsers();
        //}

        //internal DataTable getExternalUsers(string selectedvendor)
        //{
        //    return LocalDBGet.getExternalUsers(selectedvendor);
        //}
        //internal DataTable searchExternalUsers(string searchcriteria)
        //{
        //    return LocalDBGet.searchExternalUsers(searchcriteria);
        //}

        //internal DataTable get_ddl_data(string Query)
        //{
        //    return LocalDBGet.get_ddl_data(Query);
        //}

        //internal DataTable getEditData(string ID)
        //{
        //    return LocalDBGet.getEditData(ID);
        //}
        //internal DataTable getBookingData(string ID)
        //{
        //    return LocalDBGet.getBookingData(ID);
        //}

        //internal DataTable getEditDataPO(string ID)
        //{
        //    return LocalDBGet.getEditDataPO(ID);
        //}

        //internal DataTable getBookingRFC(string ID)
        //{
        //    return LocalDBGet.getBookingRFC(ID);
        //}
        //internal DataTable GetRFCCode(string VendorNumber, string Site)
        //{
        //    return LocalDBGet.GetRFCCode(VendorNumber, Site);
        //}


        //internal string DeclineBookingRequest(string ID, string vuser, string vemail, string comments)
        //{
        //    return LocalDBGet.DeclineBookingRequest(ID, vuser, vemail, comments);
        //}

        //internal string Addnewuser(string NewUser, int UserRole)
        //{
        //    return LocalDBGet.Addnewuser(NewUser, UserRole);
        //}
        //internal DataTable toPringNominationBooking(string startdate, string enddate, int trainingprocess, string trainingcentre)
        //{
        //    return LocalDBGet.toPringNominationBooking(startdate, enddate, trainingprocess, trainingcentre);
        //}

        //internal DataTable GetData(string userName)
        //{
        //    return LocalDBGet.GetData(userName);
        //}
        //internal string GetAPIInfo(string applicationname)
        //{
        //    return LocalDBGet.GetAPIInfo(applicationname);
        //}
        //internal string Insert_NewBookingRequest(DataTable dt, string date, string bcomments, string bay, string email, string vendor, string trucksize, string ServiceCentre, string rfc_IDs)
        //{

        //    return LocalDBGet.Insert_NewBookingRequest(dt, date, bcomments, bay, email, vendor, trucksize, ServiceCentre, rfc_IDs);
        //}
        internal string insert_CalendarResults(DataTable dt)
        {

            return LocalDBGet.insert_CalendarResults(dt);
        }
        //internal string ApproveRequest(DataTable inbdel, string bid, string BookingStatus, string Requestdate, string vemail, string vuser, string trucks, string bcomments, string bay)
        //{
        //    return LocalDBGet.ApproveRequest(inbdel, bid, BookingStatus, Requestdate, vemail, vuser, trucks, bcomments, bay);
        //}

        //internal string UpdateInbound(string inbdelivery, string bid)
        //{
        //    return LocalDBGet.UpdateInbound(inbdelivery, bid);
        //}
        //internal string update_VendorsBookingHeader(string ID, string status, string RequestNumber, string vemail, string vendor, string trucks, string bcomments)
        //{
        //    return LocalDBGet.update_VendorsBookingHeader(ID, status, RequestNumber, vemail, vendor, trucks, bcomments);
        //}

        //internal string insert_comment(string reqID, string tcomment, string UserID, string fullDate)
        //{
        //    return LocalDBGet.insert_comment(reqID, tcomment, UserID, fullDate);
        //}

        //internal DataTable getEditDataLabels(string ID)
        //{
        //    return LocalDBGet.getEditDataLabels(ID);
        //}
        //internal DataTable validateSitePOQty(string Site, string PO)
        //{
        //    return LocalDBGet.validateSitePOQty(Site, PO);
        //}

        //public string insert_Save_BayAndSlot(string date, string bay, string email, string vendor, string trucksize, string ServiceCentre, string SlotKey, String reqNum)
        //{
        //    return LocalDBGet.insert_Save_BayAndSlot(date, bay, email, vendor, trucksize, ServiceCentre, SlotKey, reqNum);
        //}

        //public string p_insert_NewUser(string bclicked, string EmployeeNumber, string Permission, string ServiceCentre)
        //{
        //    return LocalDBGet.p_insert_NewUser(bclicked, EmployeeNumber, Permission, ServiceCentre);
        //}

        //internal void logVBSexception(string log, string username)
        //{
        //    LocalDBGet.logVBSexception(log, username);
        //}


        //public string p_insert_NewVendor(string bclicked, string EmployeeNumber, string UserName, string SupplierName, string FriendlyName, string vPassword, string vrowid)
        //{
        //    return LocalDBGet.p_insert_NewVendor(bclicked, EmployeeNumber, UserName, SupplierName, FriendlyName, vPassword, vrowid);
        //}


        //public string insert_LockBayAndSlot(string date, string bay, string email, string vendor, string trucksize, string ServiceCentre, string SlotKey, string ReqNumber)
        //{
        //    return LocalDBGet.insert_LockBayAndSlot(date, bay, email, vendor, trucksize, ServiceCentre, SlotKey, ReqNumber);
        //}

        //public string insert_replaceBayAndSlot(string date, string bay, string email, string vendor, string trucksize, string ServiceCentre, string SlotKey)
        //{
        //    return LocalDBGet.insert_replaceBayAndSlot(date, bay, email, vendor, trucksize, ServiceCentre, SlotKey);
        //}

        //public string delete_bayslotReplaceTruckCancel(/*string date, string bay, string email, string vendor, string trucksize, string ServiceCentre, */string SlotKey, string ReqNumber)
        //{
        //    return LocalDBGet.delete_bayslotReplaceTruckCancel(/*date, bay, email, vendor, trucksize, ServiceCentre, */SlotKey, ReqNumber);
        //}
        //public string Insert_New_Cource(string query)
        //{
        //    return LocalDBGet.saveData(query).Rows[0][0].ToString();
        //}

        //public void SaveOnly(string query)
        //{
        //    LocalDBGet.saveonly(query);
        //}
        //public string Save_newRequest(string query)
        //{
        //    return LocalDBGet.Save_newRequest(query);
        //}
        //public string saveEditBooking(DataTable inbdel)
        //{
        //    return LocalDBGet.saveEditBooking(inbdel);
        //}

        //public string reset_Vendor_Password(string UserName, string SecurityQuestion)
        //{
        //    return LocalDBGet.reset_Vendor_Password(UserName, SecurityQuestion).Rows[0][0].ToString();
        //}

        //public string change_Vendor_Password(string UserName, string SecurityQuestion, string Password)
        //{
        //    return LocalDBGet.change_Vendor_Password(UserName, SecurityQuestion, Password).Rows[0][0].ToString();
        //}

        //internal DataTable getStatus()
        //{
        //    return LocalDBGet.getStatus();
        //}

        //internal DataTable getUploadData(string File)
        //{
        //    return LocalDBGet.getUploadData(File);
        //}

        //internal DataSet getBookings(string ServiceCentre, string TruckSize, string Date)
        //{
        //    return LocalDBGet.getBookings(ServiceCentre, TruckSize, Date);
        //}

        //internal void SaveExternal(string UserName, string DisplayName, string VendorCodes, string FriendlyName)
        //{
        //    LocalDBGet.SaveExternal(UserName, DisplayName, VendorCodes, FriendlyName);
        //}

        //internal DataSet LoadSiteMaintenance(string Site)
        //{
        //    return LocalDBGet.LoadSiteMaintenance(Site);
        //}

        //internal void AddSiteMaintenance(string Site, string Date, string StartTime, string EndTime, string Bays)
        //{
        //    LocalDBGet.AddSiteMaintenance(Site, Date, StartTime, EndTime, Bays);
        //}

        //internal void SavePOInvoice(int ID, string RequestNumber, string PO, byte[] filename)
        //{
        //    LocalDBGet.SavePOInvoice(ID, RequestNumber, PO, filename);
        //}

        //internal void saveInvoiceNumber(int ID, string ReqID, string ponumber, string invoicenumber)
        //{
        //    LocalDBGet.saveInvoiceNumber(ID, ReqID, ponumber, invoicenumber);
        //}

        //internal void DeletePORequest(int ID, string ReqID, string ponumber)
        //{
        //    LocalDBGet.DeletePORequest(ID, ReqID, ponumber);
        //}
        //internal DataTable GetInvoiceDocument(string ID)
        //{
        //    return LocalDBGet.GetInvoiceDocument(ID);
        //}

        //internal string UpdateSiteMaintenance(string Site, string Startdate, string Enddate, string Timeslots, string Bays, string Action)
        //{
        //    return LocalDBGet.UpdateSiteMaintenance(Site, Startdate, Enddate, Timeslots, Bays, Action);
        //}

        //public DataTable GetSiteCode(string Site)
        //{
        //    return LocalDBGet.GetSiteCode(Site);//.Rows[0][0].ToString();
        //}

        //public string GetReleaseTrat(string RelStrat, string RelStat)
        //{
        //    return LocalDBGet.GetReleaseTrat(RelStrat, RelStat).Rows[0][0].ToString();
        //}

        //internal DataTable getPOInvoice(string ID, string PO)
        //{
        //    return LocalDBGet.getPOInvoice(ID, PO);
        //}

        //internal void UpdateInbDelivery(string ID, string PONumber, string Delivery)
        //{
        //    LocalDBGet.UpdateInbDelivery(ID, PONumber, Delivery);
        //}

    }
}
