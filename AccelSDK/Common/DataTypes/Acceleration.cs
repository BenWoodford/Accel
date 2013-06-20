using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccelSDK.Common.DataTypes
{
    [Serializable]
    public class Acceleration
    {
        public double x = 0, y = 0, z = 0;

        public static int SizeOf()
        {
            return sizeof(double) * 3;
        }
    }
}
