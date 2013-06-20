using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccelSDK.Common.DataTypes
{
    [Serializable]
    public class Rotation
    {
        public double yaw = 0, pitch = 0, roll = 0;

        public static int SizeOf()
        {
            return sizeof(double) * 3;
        }
    }
}
