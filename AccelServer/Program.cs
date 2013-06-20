using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccelSDK;
using AccelSDK.Common;
using AccelServer.InterProcess;
using System.Threading;

namespace AccelServer
{
    class Program
    {
        static void Main(string[] args)
        {
            PipePacket[] pipes = new PipePacket[2] { new PipePacket(), new PipePacket() };
            MappedDataFile manager = new MappedDataFile();

            while (true)
            {
                manager.Write(pipes);
                Thread.Sleep(5000);
            }
        }
    }
}
