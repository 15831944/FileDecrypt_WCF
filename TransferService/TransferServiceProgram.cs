using System;
using System.Configuration;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Threading;
using System.Xml;
using UtilityLib;

namespace TransferService
{
    public class TransferServiceProgram
    {
        private static void Main(string[] args)
        {
            AppDomain.CurrentDomain.SetData("APP_CONFIG_FILE", @"Config.config");

            CleanTempDir();

            var baseAddress = new Uri("net.Tcp://" + ConfigurationManager.AppSettings["ServerIP"] + "/TranferService");
            //var baseAddress = new Uri("net.tcp://localhost:4096/DecryptService");
            using (var host = new ServiceHost(typeof (global::TransferService.TransferService), baseAddress))
            {
                var myNetTcpBinding = new NetTcpBinding()
                {
                    TransferMode = TransferMode.Streamed,
                    MaxReceivedMessageSize = 2147483647,
                    Security = new NetTcpSecurity() { Mode = SecurityMode.None },
                    ReaderQuotas = new XmlDictionaryReaderQuotas()
                    {
                        MaxBytesPerRead = 2147483647,
                        MaxArrayLength = 2147483647,
                        MaxStringContentLength = 2147483647,
                    }
                };
                var myServiceEndpoint = new ServiceEndpoint(
                    ContractDescription.GetContract(typeof(ITransferService)),
                    myNetTcpBinding,
                    new EndpointAddress(baseAddress));
                host.Description.Endpoints.Add(myServiceEndpoint);
                ServiceMetadataBehavior smb = host.Description.Behaviors.Find<ServiceMetadataBehavior>();
                if (smb == null)
                    host.Description.Behaviors.Add(new ServiceMetadataBehavior());

                //暴露出元数据，以便能够让SvcUtil.exe自动生成配置文件
                host.AddServiceEndpoint(typeof (IMetadataExchange), MetadataExchangeBindings.CreateMexTcpBinding(),
                    "mex");
                host.Opened += delegate
                {
                    Console.WriteLine("TranferService host started at {0}...", baseAddress);
                };
                host.Open();

                Console.Title = ConfigurationManager.AppSettings["TranferServiceTittle"];

                Console.WriteLine("The window will be hidden in 3 seconds. ");
                Thread.Sleep(3000);
                Win32Helper.HideWindow("ConsoleWindowClass", Console.Title);

                Console.ReadLine();
            }
        }

        private static void CleanTempDir()
        {
            if (bool.Parse( ConfigHelper.GetConfig("CleanTempOnStart")))
            {
                var tempDir = new DirectoryInfo(ConfigHelper.GetConfig("ServerTempDir"));
                foreach (var fileInfo in tempDir.GetFiles())
                {
                    try
                    {
                        fileInfo.Delete();

                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
            }
            
        }
    }
}
