using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccelSDK.Common.DataTypes;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace AccelSDK.Common
{
    [Serializable]
    public class PipePacket
    {
        public MagneticField MagneticField = new MagneticField();
        public Acceleration Acceleration = new Acceleration();
        public Rotation Rotation = new Rotation();
        public RotationRate RotationRate = new RotationRate();

        public static int SizeOf()
        {
            return MagneticField.SizeOf() + Acceleration.SizeOf() + Rotation.SizeOf() + RotationRate.SizeOf();
        }

        public static byte[] ToByteArray(PipePacket[] pipes)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream stream = new MemoryStream())
            {
                formatter.Serialize(stream, pipes);
                stream.Seek(0, SeekOrigin.Begin);
                return stream.ToArray();
            }
        }

        public static PipePacket[] FromByteArray(byte[] data)
        {
            PipePacket[] result;
            using (MemoryStream m = new MemoryStream(data))
            {
                m.Position = 0;
                BinaryFormatter formatter = new BinaryFormatter();
                result = (PipePacket[])formatter.Deserialize(m);
            }
            return result;
        }
    }
}
