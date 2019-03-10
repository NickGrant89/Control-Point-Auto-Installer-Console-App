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

            if (!File.Exists(@"C:\ProgramData\Onec\Config\id.txt"))
            {
                //Create Folder stucture, Config file and post info.

                FunctionsV2.createFolder(@"C:\ProgramData\Onec\Logs");
                FunctionsV2.createFolder(@"C:\ProgramData\Onec\Config");
                FunctionsV2.createTxtFile(@"C:\ProgramData\Onec\Config\id.txt");
                API.findID();
    


            }
            fileTransfer.runFt();
               MonitorFunctionsV2.checkIfActive();


        }

        
    }

}

