using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMonitorV2
{
    class FunctionsV2
    {
        //Create Folder
        public static void createFolder(string path)
        {
            

            if (Directory.Exists(path))
            {

            }

            // Try to create the directory.
            DirectoryInfo di = Directory.CreateDirectory(path);
            Directory.GetCreationTime(path);
            LogFile.LogMessageToFile("");
        }
        //Creates post config / ID
        public static void createTxtFile(string path)
        {
            //string path = @"C:\ProgramData\Onec\Config\OCCID.xml";
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {


                }
     
            }
            LogFile.LogMessageToFile("");

        }
        //Writes PostID to config
        public static void writeTxtFile(string path, string text)
        {
     

            System.IO.File.WriteAllText(path, text);

        }
        //Reads Post ID
        public static void readTxtFile(string filePath)
        {
            //@"C:\ProgramData\Onec\Config\id.txt

            // Read the file as one string.
            string text = System.IO.File.ReadAllText(filePath);

            // Display the file contents to the console. Variable text is a string.
            System.Console.WriteLine("Contents of WriteText.txt = {0}", text);


        }
        //Creates Device
        public static void deviceCheckIn()
        {
            try
            {
                var device = new
                {
                    pcname = DarkTools.pcNameV1(),
                    ipaddress = DarkTools.GetLocalIPAddress(),
                    macaddress = DarkTools.GetMACAddress(),
                    status = "Test",
                    timestamp = DateTime.Now.ToString(),
                };

                var client = new RestClient(API.domainName() +"/api/v1/devices/checkin");
                var request2 = new RestRequest(Method.POST);
                request2.AddHeader("content-type", "application/json");
                request2.AddHeader("Authorization", "bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6Im5pY2tncmFudDE5ODlAbGl2ZS5jby51ayIsInVzZXJJZCI6IjViY2U0Y2EwODRiOWUyNWU5MDkzMmQ2ZCIsImlhdCI6MTU0NjA5NTkxMywiZXhwIjoxNTQ2MDk5NTEzfQ.j8zD0eTxVkg3sW2Z4F83quR65bCPnfL1y1K1oA4DyQE");
                request2.AddJsonBody(device); //<-- this will serialize and add the model as a JSON body.
                IRestResponse response2 = client.Execute(request2);

                //Response to Var 
                Console.WriteLine(response2.Content.ToString());
                //Deserialize to object
         
                
                LogFile.LogMessageToFile("Device registered add endpoint");


            }
            catch
            {

            }
        }

    }
}
