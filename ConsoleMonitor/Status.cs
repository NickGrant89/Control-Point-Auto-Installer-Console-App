using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMonitor
{
    class Status
    {
            //--- App.config ---//
            public static string SiteName = ConfigurationManager.AppSettings["SiteName"];
            public static string SiteID = ConfigurationManager.AppSettings["SiteID"];
            public static string EmailAdd = ConfigurationManager.AppSettings["EmailAddress"];
            public static string Site_n = ConfigurationManager.AppSettings["Site_n"];
            public static string qsrPriIP = ConfigurationManager.AppSettings["PrimaryIP"];
            public static string PriPcName = ConfigurationManager.AppSettings["PriPcName"];
            public static string BackupIP = ConfigurationManager.AppSettings["BackupIP"];
            public static string ServicesTest = ConfigurationManager.AppSettings["ServiceTest"];
            public static string time2 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            public static string site_n = ConfigurationManager.AppSettings["Site_n"];
            public static string Cate = ConfigurationManager.AppSettings["Cate"];
            public static string DomainName = ConfigurationManager.AppSettings["DomainName"];

            public static string Status1Pri { get; set; }
            public static string Status1Bak { get; set; }
            public static string Service1 { get; set; }
            public static string Service2 { get; set; }
            public static string categories { get; set; }
            public static string acf { get; set; }
            public static int value { get; set; }
            public static string version { get; set; }


        }
    }

