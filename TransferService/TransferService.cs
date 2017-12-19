using System;
using System.Configuration;
using System.IO;
using System.ServiceModel;
using System.Xml;
using TransferService.DecryptServiceReference;

namespace TransferService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“TransferService”。
    public class TransferService : ITransferService
    {
        private readonly string _tempDir;

        public TransferService()
        {
            _tempDir = ConfigurationManager.AppSettings["ServerTempDir"];

            if (!string.IsNullOrEmpty(_tempDir) && IsValidPath(_tempDir)) return;
            _tempDir = "C:\\temp";
            if (Directory.Exists(_tempDir))
            {
                Directory.CreateDirectory(_tempDir);
            }
        }

        public string TransferMessage(string msg)
        {
            Console.WriteLine("TransferService Host recived message: {0}.", msg);
            Console.WriteLine("Send message to DecrytService...");
            using (var client = new DecryptServiceClient())
            {
                var str = client.ManageMessage(string.Format("\"{0}\" modified by TransferService", msg));
                return str;
            }
        }

        public Stream UploadFile(Stream stream)
        {
            var fileName = Path.Combine(_tempDir, Guid.NewGuid().ToString("D"));
            //Console.WriteLine("New filename: {0}", fileName);

            using (var output = new FileStream(fileName, FileMode.Create))
            {
                stream.CopyTo(output);
                Console.WriteLine("TransferService saves the file to {0}", fileName);
            }
            Stream returnStream;


            var baseAddress = new Uri(ConfigurationManager.AppSettings["DecryptUri"]);

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

            using (var client = new DecryptServiceClient(myNetTcpBinding, new EndpointAddress(baseAddress)))
            {
                returnStream = client.GetFileStream(fileName);
            }
            return returnStream;
        }

        //路径是否合法
        private bool IsValidPath(string path)
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



