using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using AccelSDK.Common.DataTypes;
namespace AccelServer
{
    class Device
    {
        public byte[] buffer;
        public Socket clientSocket;
        public MagneticField MagneticField = new MagneticField();
        public Acceleration Acceleration = new Acceleration();
        public Rotation Rotation = new Rotation();
        public RotationRate RotationRate = new RotationRate();
    }
}
