using System.IO;
using System.ServiceModel;

namespace TransferService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“ITransferService”。
    [ServiceContract]
    public interface ITransferService
    {
        [OperationContract]
        string TransferMessage(string msg);

        [OperationContract]
        Stream UploadFile(Stream stream);
    }
}
