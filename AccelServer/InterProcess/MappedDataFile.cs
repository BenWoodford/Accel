using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemoryMappedFileManager;
using AccelSDK.Common;

namespace AccelServer.InterProcess
{
    class MappedDataFile
    {
        MemoryMappedFileCommunicator communicator;

        public MappedDataFile()
        {
            communicator = new MemoryMappedFileCommunicator(AccelSDK.Common.Constants.PipeName, PipePacket.SizeOf());
            communicator.WritePosition = 0;
            communicator.ReadPosition = 0;
        }

        public void Write(PipePacket packet) {
            communicator.Write(packet.ToByteArray());
            Console.WriteLine("Wrote packet...");
        }
    }
}
