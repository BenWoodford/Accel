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
        public PipePacket[] Packets;
        internal ReceivedAccelServDataArgs(byte[] data, long length)
        {
            Packets = PipePacket.FromByteArray(data);
        }
    }
}
