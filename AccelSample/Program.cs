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

            Console.WriteLine("Found {0} Devices", args.Packets.Length);
            Console.WriteLine();

            int i = 0;
            foreach(PipePacket packet in args.Packets) {
                Console.WriteLine("Device {0}", i);
                Console.WriteLine("Magnetic Field: {0} {1} {2}", packet.MagneticField.x, packet.MagneticField.y, packet.MagneticField.z);
                Console.WriteLine("Acceleration: {0} {1} {2}", packet.Acceleration.x, packet.Acceleration.y, packet.Acceleration.z);
                Console.WriteLine("Rotation: {0} {1} {2}", packet.Rotation.yaw, packet.Rotation.pitch, packet.Rotation.roll);
                Console.WriteLine("Rotation (Rate): {0} {1} {2}", packet.RotationRate.x, packet.RotationRate.y, packet.RotationRate.z);
                Console.WriteLine();
                i++;
            }
        }
    }
}
