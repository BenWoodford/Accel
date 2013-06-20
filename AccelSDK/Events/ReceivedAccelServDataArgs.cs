using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccelSDK.Common;

namespace AccelSDK.Events
{
    public class ReceivedAccelServDataArgs : EventArgs
    {
        public PipePacket Packet;
        internal ReceivedAccelServDataArgs(byte[] data, long length)
        {
            Packet = PipePacket.FromByteArray(data);
        }
    }
}
