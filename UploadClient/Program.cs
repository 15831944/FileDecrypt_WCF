using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Windows.Forms;
using System.Xml;

namespace UploadClient
{
    internal class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            System.AppDomain.CurrentDomain.SetData("APP_CONFIG_FILE", @"Config.config");


            List<string> files;
            if (args.Length > 0)
            {
                files = new List<string>(args);
            }
            else
            {
                var dlg = new OpenFileDialog
                {
                    Multiselect = true,
                    Filter = "All files (*.*)|*.*"
                };
                if (dlg.ShowDialog() == DialogResult.Cancel) return;
                files = new List<string>(dlg.FileNames);
            }

            string str = "\t";
            files.ForEach(f => str += (f.ToString() + "\n\t"));
            Console.WriteLine("Selected File(s):\n{0}", str);

            var baseAddress = new Uri("net.Tcp://" + ConfigurationManager.AppSettings["ServerIP"] + "/TranferService");

            var myNetTcpBinding = new NetTcpBinding()
            {
                TransferMode = TransferMode.Streamed,
                MaxReceivedMessageSize = 2147483647,
                Security = new NetTcpSecurity() {Mode = SecurityMode.None},
                ReaderQuotas = new XmlDictionaryReaderQuotas()
                {
                    MaxBytesPerRead = 2147483647,
                    MaxArrayLength = 2147483647,
                    MaxStringContentLength = 2147483647,
                }
            };

            var savePath = ConfigurationManager.AppSettings["LocalSaveDir"];
            
            foreach (var fileName in files)
            {
                #region UploadFileTest

                using (var inputStream = new FileStream(fileName, FileMode.Open))
                {
                    var path = (string.IsNullOrEmpty(savePath)||!IsValidPath(savePath)) ? Path.GetDirectoryName(fileName) : savePath;
                    
                    var outputName = Path.Combine(path, "[new]" + Path.GetFileName(fileName));
                    using (var outputStream = new FileStream(outputName, FileMode.Create))
                    {
                        Stream stream;
                        using (var client = new TranferServiceReference.TransferServiceClient(
                            myNetTcpBinding,new EndpointAddress(baseAddress)))
                        {
                            stream = client.UploadFile(inputStream);
                        }

                        stream.CopyTo(outputStream);
                    }

                    Console.WriteLine("Recived file: {0}", outputName);
                }

                #endregion
            }
            Console.WriteLine("Press any key to exit!");
            Console.ReadKey();
        }

        //路径是否合法
        private static bool IsValidPath(string path)
        {
            if (Directory.Exists(path))
                return true;
            else
            {
                try
                {
                    Directory.CreateDirectory(path);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}