using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccelSDK.Common;
using AccelSDK;
using AccelSDK.Events;

namespace AccelSample
{
    class Program
    {
        static void Main(string[] args)
        {
            PipeManager pipe = new PipeManager();
            pipe.ReceivedAccelServDataEvent += DataReceived;
            pipe.Start();

            PrintInstruction();
            Console.ReadLine();
        }

        public static void PrintInstruction()
        {
            Console.WriteLine("Listening for Pipe Packets. Press Enter to quit.");
        }

        public static void DataReceived(object sender, ReceivedAccelServDataArgs args)
        {
            Console.Clear();
            PrintInstruction();

            Console.WriteLine("Magnetic Field: {0} {1} {2}", args.Packet.MagneticField.x, args.Packet.MagneticField.y, args.Packet.MagneticField.z);
        }
    }
}
