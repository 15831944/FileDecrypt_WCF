using System;
using System.IO;

namespace DecryptService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“DecryptService”。
    public class DecryptService : IDecryptService
    {
        public string ManageMessage(string msg)
        {
            Console.WriteLine("DecryptService Host recived message: {0}.", msg);
            return string.Format("\"{0}\" modified by DecryptService", msg);
        }

        public Stream GetFileStream(string fileName)
        {
            Console.WriteLine("DecryptService Host decrypted FileName: {0}", fileName);
            
            return new FileStream(fileName, FileMode.Open, FileAccess.Read);

        }
    }
}
