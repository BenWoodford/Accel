using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccelSDK.Common;
using MemoryMappedFileManager;
using AccelSDK.Events;

namespace AccelSDK
{
    public class PipeManager
    {
        private MemoryMappedFileCommunicator communicator;
        public delegate void ReceivedAccelServData(object sender, ReceivedAccelServDataArgs args);

        public event ReceivedAccelServData ReceivedAccelServDataEvent;

        public PipeManager()
        {
            communicator = new MemoryMappedFileCommunicator(Constants.PipeName, PipePacket.SizeOf());
            communicator.ReadPosition = 0;
            communicator.WritePosition = 0;
        }

        public void Start()
        {
            communicator.DataReceived += DataReceived;
            communicator.StartReader();
        }

        private void DataReceived(object sender, MemoryMappedDataReceivedEventArgs e)
        {
            ReceivedAccelServDataArgs args = new ReceivedAccelServDataArgs(e.Data, e.Data.LongLength);
            ReceivedAccelServDataEvent(this, args);
        }
    }
}
