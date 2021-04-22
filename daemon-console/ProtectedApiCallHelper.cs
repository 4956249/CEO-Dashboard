// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using daemon_console.Model;
using System.Collections.Generic;
using daemon_console.DataHandler;
using System.Text;

namespace daemon_console
{
    /// <summary>
    /// Helper class to call a protected API and process its result
    /// </summary>
    public class ProtectedApiCallHelper
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="httpClient">HttpClient used to call the protected API</param>
        public ProtectedApiCallHelper(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        protected HttpClient HttpClient { get; private set; }

        private List<CalendarItem> calendarItem = new List<CalendarItem>();

        string Startdate="";
        string Enddate="";
        string vLocation = "";
        string vAttendees = "";
        string vOrganiser = "";
        string vSubject = "";
        string emailbody = "";
        string isCancelled = "";

        /// <summary>
        /// Calls the protected web API and processes the result
        /// </summary>
        /// <param name="webApiUrl">URL of the web API to call (supposed to return Json)</param>
        /// <param name="accessToken">Access token used as a bearer security token to call the web API</param>
        /// <param name="processResult">Callback used to process the result of the call to the web API</param>
        public async Task CallWebApiAndProcessResultASync(string webApiUrl, string accessToken, Action<JObject> processResult)
        {
            try
            {
                var totaldays = 365;
                var cntdays = 0;
                var start_datetime = DateTime.Now;

                if (!string.IsNullOrEmpty(accessToken))
                {

                    while (cntdays < totaldays)
                    {

                        var end_datetime = start_datetime.AddDays(31);
                        //var start_datetime = "2021-12-01";
                        //var end_datetime = "2021-12-31";


                        //var Jsonvar = "{\"schedules\":[\"Corporate@implats.co.za\"],\"startTime\":{\"dateTime\":\"2021-12-01T00:00:00\",\"timeZone\":\"Pacific Standard Time\"},\"endTime\":{\"dateTime\":\"2021-12-31T23:59:00\",\"timeZone\":\"Pacific Standard Time\"},\"availabilityViewInterval\":60}";
                        var Jsonvar = "{\"schedules\":[\"Corporate@implats.co.za\"],\"startTime\":{\"dateTime\":\"" + start_datetime + "\",\"timeZone\":\"Pacific Standard Time\"},\"endTime\":{\"dateTime\":\"" + end_datetime + "\",\"timeZone\":\"Pacific Standard Time\"},\"availabilityViewInterval\":60}";
                        HttpContent schedules = new StringContent(Jsonvar, Encoding.UTF8, "application/json");

                        //HttpRequestMessage requestMessage = new HttpRequestMessage
                        //{
                        //    Content = new StringContent(Jsonvar),
                        //    Method = HttpMethod.Post,

                        //};

                        var defaultRequestHeaders = HttpClient.DefaultRequestHeaders;
                        //requestbody.Content = new StringContent("some json", Encoding.UTF8, ContentType.Json);
                        if (defaultRequestHeaders.Accept == null || !defaultRequestHeaders.Accept.Any(m => m.MediaType == "application/json"))
                        {
                            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        }
                        defaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                        //HttpResponseMessage response = await HttpClient.GetAsync(webApiUrl);
                        HttpResponseMessage response = await HttpClient.PostAsync(webApiUrl, schedules);
                        if (response.IsSuccessStatusCode)
                        {
                            string json = await response.Content.ReadAsStringAsync();

                            json = JsonConvert.DeserializeObject(json).ToString().ToString();
                            JObject resultObj = JObject.Parse(json);
                            /*
                            JObject result = JsonConvert.DeserializeObject(json) as JObject;
                            loadBookingResult(result);
                            */

                            loadBookingResultSchedules(resultObj);

                            Console.ForegroundColor = ConsoleColor.Gray;

                            //processResult(result);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Failed to call the web API: {response.StatusCode}");
                            string content = await response.Content.ReadAsStringAsync();

                            // Note that if you got reponse.Code == 403 and reponse.content.code == "Authorization_RequestDenied"
                            // this is because the tenant admin as not granted consent for the application to call the Web API
                            Console.WriteLine($"Content: {content}");
                        }
                        Console.ResetColor();
                        cntdays += 31;
                        start_datetime = end_datetime.AddDays(1);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private string loadBookingResultSchedules(JObject resultObj)
        {
            DataTable dt = new DataTable();
            //dt.Columns.Add("Employee Number");
            dt.Columns.Add("emailbody");
            dt.Columns.Add("Start_date");
            dt.Columns.Add("End_date");
            dt.Columns.Add("Location");
            dt.Columns.Add("Attendees");
            dt.Columns.Add("Organiser");
            dt.Columns.Add("Subject");
            dt.Columns.Add("isCancelled");
            //string dformat = "MMM ddd d HH:mm yyyy";
            foreach (var x in resultObj["value"])
            {
                Startdate = "";
                Enddate = "";
                vLocation = "";
                vAttendees = "";
                vSubject = "";
                vOrganiser = "";
                emailbody = "";
                isCancelled = "";
                //    //if (x.Key == "employeesResults")
                //    //{
                //if (x["bodyPreview"] != null) { emailbody = x["bodyPreview"].ToString(); }
                foreach (var meeting in x["scheduleItems"])
                {
                    if (meeting["subject"] != null) { vSubject = meeting["subject"].ToString(); }
                    if (meeting["start"]["dateTime"] != null)
                    {
                        //DateTime selecteddate = Convert.ToDateTime(x["start"]["dateTime"]); 
                        DateTime selecteddate = Convert.ToDateTime(meeting["start"]["dateTime"]).ToLocalTime();
                        Startdate = selecteddate.ToString("yyyy-MM-dd HH:mm:sss");
                    }

                    if (meeting["end"]["dateTime"] != null)
                    //if (x["end"]["dateTime"] != null) 
                    {
                        //DateTime selecteddate = Convert.ToDateTime(x["end"]["dateTime"]);
                        DateTime selecteddate = Convert.ToDateTime(meeting["end"]["dateTime"]).ToLocalTime();
                        Enddate = selecteddate.ToString("yyyy-MM-dd HH:mm:sss");
                    }
                    //if (x["location"]["displayName"] != null) { vLocation = x["location"]["displayName"].ToString(); }
                    if (meeting["location"] != null) { vLocation = meeting["location"].ToString(); }
                    dt.Rows.Add(emailbody, Startdate, Enddate, vLocation, vOrganiser, vAttendees, vSubject, isCancelled);

                }
                //if (x["scheduleItems"][0]["start"]["dateTime"] != null)
                //{
                //    //DateTime selecteddate = Convert.ToDateTime(x["start"]["dateTime"]); 
                //    DateTime selecteddate = Convert.ToDateTime(x["scheduleItems"][0]["start"]["dateTime"]);
                //    Startdate = selecteddate.ToString("yyyy-MM-dd HH:mm:sss");
                //}

                //if (x["scheduleItems"][0]["end"]["dateTime"] != null)
                ////if (x["end"]["dateTime"] != null) 
                //{
                //    //DateTime selecteddate = Convert.ToDateTime(x["end"]["dateTime"]);
                //    DateTime selecteddate = Convert.ToDateTime(x["scheduleItems"][0]["end"]["dateTime"]);
                //    Enddate = selecteddate.ToString("yyyy-MM-dd HH:mm:sss");
                //}
                ////if (x["location"]["displayName"] != null) { vLocation = x["location"]["displayName"].ToString(); }
                //if (x["scheduleItems"][0]["location"] != null) { vLocation = x["scheduleItems"][0]["location"].ToString(); }

                //if (x["organizer"]["emailAddress"]["name"] != null) { vOrganiser = x["organizer"]["emailAddress"]["name"].ToString(); }
                //if (x["attendees"].Count() > 0)
                //{
                //    foreach (var y in x["attendees"])
                //    {
                //        vAttendees = "";
                //        //if (x["attendees"][0]["emailAddress"]["name"] != null) { Attendees = x["attendees"][0]["emailAddress"]["name"].ToString(); }
                //        if (y["emailAddress"]["name"] != null)
                //        {
                //            vAttendees = y["emailAddress"]["name"].ToString();
                //            dt.Rows.Add(emailbody, Startdate, Enddate, vLocation, vOrganiser, vAttendees, vSubject, isCancelled);
                //            //SaveCalendarItem(emailbody, Startdate, Enddate, vLocation, vAttendees, vSubject);

                //        }


                //    }
                //}
                //else
                //{
                //    //SaveCalendarItem(emailbody, Startdate, Enddate, vLocation, vAttendees, vSubject);


                //}

            }

            //_context.Client.Add(calendarItem);
            //await _context.SaveChangesAsync();
            LocalGetController rl = new LocalGetController();
            string result = rl.insert_CalendarResults(dt);






            //if (result.StartsWith("Error:"))
            //{
            return result;
            //}
            //else
            //{
            //    JsonSerializerSettings jss = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
            //    return JsonConvert.SerializeObject(dt, Formatting.Indented, jss);
            //}

        }

        private string loadBookingResult(JObject resultObj)
        {
            DataTable dt = new DataTable();
            //dt.Columns.Add("Employee Number");
            dt.Columns.Add("emailbody");
            dt.Columns.Add("Start_date");
            dt.Columns.Add("End_date");
            dt.Columns.Add("Location");
            dt.Columns.Add("Attendees");
            dt.Columns.Add("Organiser");
            dt.Columns.Add("Subject");
            dt.Columns.Add("isCancelled");
            //string dformat = "MMM ddd d HH:mm yyyy";
            foreach (var x in resultObj["value"])
            {
                Startdate = "";
                Enddate = "";
                vLocation = "";
                vAttendees = "";
                vSubject = "";
                vOrganiser = "";
                emailbody = "";
                isCancelled = "";
                //    //if (x.Key == "employeesResults")
                //    //{
                if (x["bodyPreview"] != null) { emailbody = x["bodyPreview"].ToString(); }
                if (x["subject"] != null) { vSubject = x["subject"].ToString(); }
                if (x["isCancelled"] != null) { isCancelled = x["isCancelled"].ToString(); }
                if (x["start"]["dateTime"] != null) 
                {
                    DateTime selecteddate = Convert.ToDateTime(x["start"]["dateTime"]); 
                    Startdate = selecteddate.ToString("yyyy-MM-dd HH:mm:sss"); 
                }

                if (x["end"]["dateTime"] != null) 
                {
                    DateTime selecteddate = Convert.ToDateTime(x["end"]["dateTime"]);
                    Enddate = selecteddate.ToString("yyyy-MM-dd HH:mm:sss");
                }
                if (x["location"]["displayName"] != null) { vLocation = x["location"]["displayName"].ToString(); }
                //if (x["attendees"][0]["emailAddress"]["name"] != null) { Attendees = x["attendees"][0]["emailAddress"]["name"].ToString(); }
                if (x["organizer"]["emailAddress"]["name"] != null) { vOrganiser = x["organizer"]["emailAddress"]["name"].ToString(); }
                if (x["attendees"].Count() > 0)
                {
                    foreach (var y in x["attendees"])
                    {
                        vAttendees = "";
                        //if (x["attendees"][0]["emailAddress"]["name"] != null) { Attendees = x["attendees"][0]["emailAddress"]["name"].ToString(); }
                        if (y["emailAddress"]["name"] != null)
                        {
                            vAttendees = y["emailAddress"]["name"].ToString();
                            dt.Rows.Add(emailbody, Startdate, Enddate, vLocation, vOrganiser, vAttendees, vSubject, isCancelled);
                            //SaveCalendarItem(emailbody, Startdate, Enddate, vLocation, vAttendees, vSubject);

                        }


                    }
                }
                else
                {
                    //SaveCalendarItem(emailbody, Startdate, Enddate, vLocation, vAttendees, vSubject);

                    dt.Rows.Add(emailbody, Startdate, Enddate, vLocation, vOrganiser, vAttendees, vSubject, isCancelled);

                }

            }

            //_context.Client.Add(calendarItem);
            //await _context.SaveChangesAsync();
            LocalGetController rl = new LocalGetController();
            string result = rl.insert_CalendarResults(dt);






            //if (result.StartsWith("Error:"))
            //{
            return result;
            //}
            //else
            //{
            //    JsonSerializerSettings jss = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
            //    return JsonConvert.SerializeObject(dt, Formatting.Indented, jss);
            //}

        }


        public void SaveCalendarItem(string sbody, DateTime sstartdate, DateTime senddate, string slocation, string sattendees, string ssubject)
        {
            CalendarItem newcalendaritem = new CalendarItem()
            {
                body = emailbody,
                Start_date = Convert.ToDateTime(Startdate),
                End_date = Convert.ToDateTime(Enddate),
                Location = slocation,
                Attendees = sattendees,
                Subject = ssubject
            };
            calendarItem.Add(newcalendaritem);
        }
    }
}
