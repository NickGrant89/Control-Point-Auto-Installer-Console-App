using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMonitorV2
{
    class MonitorFunctionsV2
    {

        public static void checkIfActive()
        {
            var client = new RestClient(API.domainName() + "/api/v1/devices/" + FunctionsV2.readTxtFile(@"C:\ProgramData\Onec\Config\id.txt"));
            var request2 = new RestRequest(Method.GET);
            request2.AddHeader("content-type", "application/json");
            request2.AddHeader("Authorization", "bearer " + API.getAuth());
            IRestResponse response2 = client.Execute(request2);

            //Deserialize to object
            DeviceModel.RootObject device = JsonConvert.DeserializeObject<DeviceModel.RootObject>(response2.Content);

            if (device.status != "Active")
            {
                return;
            }
            else
            {
                runMonitor();
            }

            LogFile.LogMessageToFile(" ");
        }

        public static void runMonitor()
        {
            try
            {
                var device = new
                {

                    pcname = DarkTools.pcNameV1(),
                    ipaddress = DarkTools.GetLocalIPAddress(),
                    macaddress = DarkTools.GetMACAddress(),
                    status = "Active",
                    timestamp = DateTime.Now.ToString(),

                    deviceinfo = new
                    {
                        windowsversion = MyDevice.WindowsVer(),
                        cpu ="too",
                        availablememory = MyDevice.PhysicalMemory(),
                        exipaddress = DarkTools.getExternalIp(),
                        antivirus = MyDevice.AntiVirus(),
                        deviceuptime = "y",
                        lastupdated = "",

                    },
                    devicestatus = new
                    {
                        cpu = "100",
                        memory = "67",
                        network = "48",
                    },
                    harddrivespace = new
                    {
                        totalspace = "6",
                        freespace ="10",
                        usedspace = "490",
                    },
                     

                    ocslogfile = "n",

            };

                var client = new RestClient(API.domainName() + "/api/v1/devices/" + FunctionsV2.readTxtFile(@"C:\ProgramData\Onec\Config\id.txt"));
                var request2 = new RestRequest(Method.PUT);
                request2.AddHeader("content-type", "application/json");
                request2.AddHeader("Authorization", "bearer " + API.getAuth());
                request2.AddJsonBody(device); //<-- this will serialize and add the model as a JSON body.
                //request2.AddJsonBody(Devicestatus);
                IRestResponse response2 = client.Execute(request2);

                LogFile.LogMessageToFile(" ");


            }
            catch
            {

            }
        }
    }
}
