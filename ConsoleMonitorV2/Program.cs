using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Timers;
using Newtonsoft.Json;
using System.Xml.Linq;
using System.Configuration;
using System.IO;

namespace ConsoleMonitorV2
{
    class Program
    {

        static void Main(string[] args)
        {

            if (!File.Exists(DarkTools.OCCXMLPostID))
            {
                //Create Folder stucture, Config file and post info.
                DarkTools.createLogFolder();
                DarkTools.CreateFolderXMLConfig();
                DarkTools.CreateXMLPostID();
                DarkTools.PostInfo();


            }
            if (!File.Exists(DarkTools.OCCXMLConfig))
            {

                //Creates GetConfig File.
                DarkTools.GetConfig();


            }
            if (File.Exists(DarkTools.OCCXMLConfig) && File.Exists(DarkTools.OCCXMLPostID))
            {

                MonitorQSR.RunMonitorQSR();
              
                
            }
            DarkTools.ReadPostIDXml();
            LogFile.postRequest("register.onec.systems", DarkTools.ReadXMLID);
            DarkTools.ReadConfigToXml();
            LogFile.postRequest(DarkTools.ReadSiteEndpoint, MonitorV1.getPostIDV1());



        }

        
    }

}

