using System.IO;
using System.ServiceModel;

namespace UtilityLib
{
    [MessageContract]
    public class FileMessage
    {
        [MessageHeader(MustUnderstand = true)]
        public string FullName { get; set; }

        [MessageBodyMember(Order = 1)]
        public Stream DataStream { get; set; }

        public override string ToString()
        {
            return "FileMessage:\t" + FullName + "\t" + DataStream.Length;
        }
    }
}
