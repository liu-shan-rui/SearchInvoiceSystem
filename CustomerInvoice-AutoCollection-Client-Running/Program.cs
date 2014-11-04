using System;
using System.Collections.Generic;

using System.Text;
using System.IO;
using log4net;

namespace CustomerInvoice_AutoCollection_Client_Running
{
    public class Program
    {

        private readonly static ILog Log = LogManager.GetLogger("RollingTxt");

        static void Main(string[] args)
        {
            //String DirectoryPath = System.Configuration.ConfigurationManager.AppSettings["FTP.DirectoryPath"];
            String DirectoryPath = @"E:\lsrlsr";
            Reading(DirectoryPath);
        }


        private static void Reading(String DirectoryPath)
        {
            DirectoryInfo DirectoryInfo = new DirectoryInfo(DirectoryPath);
            FileInfo[] FileInfos = DirectoryInfo.GetFiles();


            foreach (FileInfo FileInfo in FileInfos)
            {
                StreamReader StreamReader = null;
                try
                {
                    StreamReader = new StreamReader(FileInfo.FullName, System.Text.Encoding.UTF8);
                }

                catch
                {
                }

                String Line;
                String Content = "";

                while ((Line = StreamReader.ReadLine()) != null)
                {
                    Content = Content + Line;
                }

                if (StreamReader != null)
                {
                    StreamReader.Close();
                    StreamReader.Dispose();
                }

                try
                {
                    CollectionInvoiceWS.CustomerInvoiceCollectionWS WS = new CollectionInvoiceWS.CustomerInvoiceCollectionWS();
                    //Content = "<Content>" + "<![CDATA[" + Content + "]]>" + "</Content>";

                    Content = Content.Replace("", "");
                    String Status = WS.CollectionInvoice(Content);
                    if (Status == "OK")
                    {
                        String BackupPath = System.Configuration.ConfigurationManager.AppSettings["FTP.Backup"];
                        FileInfo.CopyTo(BackupPath + DateTime.Now.ToString("yyyy-MM-dd", System.Globalization.DateTimeFormatInfo.InvariantInfo) + FileInfo.Name);
                        FileInfo.Delete();
                    }
                    else
                    {
                        Log.Info("WS:Status=" + Status);
                    }
                   
                }
                catch(Exception Ex)
                {
                    Log.Info(Ex.Message);
                }
                
            }

        }
    }
}
