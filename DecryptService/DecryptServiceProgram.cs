using System;
using System.Configuration;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Threading;
using System.Xml;
using UtilityLib;

namespace DecryptService
{
    public class DecryptServiceProgram
    {
        static void Main()
        {
            AppDomain.CurrentDomain.SetData("APP_CONFIG_FILE", @"Config.config");

            var baseAddress = new Uri("net.tcp://localhost:4096/DecryptService");
            using (var host = new ServiceHost(typeof (DecryptService), baseAddress))
            {
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
                var myServiceEndpoint = new ServiceEndpoint(
                    ContractDescription.GetContract(typeof (IDecryptService)),
                    myNetTcpBinding, 
                    new EndpointAddress(baseAddress));
　　          host.Description.Endpoints.Add(myServiceEndpoint);

                ServiceMetadataBehavior smb = host.Description.Behaviors.Find<ServiceMetadataBehavior>();
                if (smb == null)
                    host.Description.Behaviors.Add(new ServiceMetadataBehavior());

                //暴露出元数据,以便能够让SvcUtil.exe自动生成配置文件
                host.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexTcpBinding(), "mex");
                host.Opened += delegate
                {
                    Console.WriteLine("DecryptService host started at {0}...", baseAddress);
                };
                host.Open( );

                Console.Title = ConfigurationManager.AppSettings["DecryptServiceTittle"];
                
                Console.WriteLine("The window will be hidden in 3 seconds. ");
                Thread.Sleep(3000);
                Win32Helper.HideWindow("ConsoleWindowClass", Console.Title);


                Console.ReadLine();
            }
        }
    }
}
