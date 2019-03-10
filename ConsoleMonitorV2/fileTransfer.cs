using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMonitorV2
{
    class fileTransfer
    {
        public static string checkFStatus()
        {
            var client = new RestClient(API.domainName() + "/api/v1/filetransfer/check/" + FunctionsV2.readTxtFile(@"C:\ProgramData\Onec\Config\id.txt"));
            var request2 = new RestRequest(Method.GET);
            request2.AddHeader("content-type", "application/json");
            request2.AddHeader("Authorization", "bearer " + API.getAuth());
            IRestResponse response2 = client.Execute(request2);

            DeviceModel.DeviceSettings device = JsonConvert.DeserializeObject<DeviceModel.DeviceSettings>(response2.Content);
            //Console.WriteLine(device.deviceSettings.fileTransfer.ftStatus + ","+ device.deviceSettings.fileTransfer.type.ToString());

            return device.fileTransfer.ftStatus + "," + device.fileTransfer.type.ToString();
        }
        public static void runFt()
        {
            if (checkFStatus() != "true")
            {
                //Console.WriteLine("Worked"); Write to log.
            }
            if (checkFStatus() == "true,server")
            {
                FunctionsV2.createFolder(@"C:\ProgramData\Onec\FileTransfer\Server");
                getCilentsFiles();
            }
            if (checkFStatus() == "true,client")
            {
                FunctionsV2.createFolder(@"C:\ProgramData\Onec\FileTransfer\Client");
            }

        }
        public static string getCilentsFiles()
        {

            var client = new RestClient(API.domainName() + "/api/v1/filetransfer/getFiles/" + FunctionsV2.readTxtFile(@"C:\ProgramData\Onec\Config\id.txt"));
            var request2 = new RestRequest(Method.GET);
            request2.AddHeader("content-type", "application/json");
            request2.AddHeader("Authorization", "bearer " + API.getAuth());
            IRestResponse response2 = client.Execute(request2);

            var obj = JsonConvert.DeserializeObject(response2.Content.ToString());

            dynamic result = JsonConvert.DeserializeObject(response2.Content);
            
            //List<dev> list = JsonConvert.DeserializeObject<List<DeviceModel.DeviceSettings>>(response2.Content);

            DeviceModel.RootObject device = JsonConvert.DeserializeObject<DeviceModel.RootObject>(response2.Content);

            return null;
        }
        
    }
  
}
