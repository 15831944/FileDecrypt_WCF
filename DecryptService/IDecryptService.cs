using System.IO;
using System.ServiceModel;

namespace DecryptService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IDecryptService”。
    [ServiceContract]
    public interface IDecryptService
    {
        [OperationContract]
        string ManageMessage(string msg);

        [OperationContract]
        Stream GetFileStream(string fileName);
    }
}
