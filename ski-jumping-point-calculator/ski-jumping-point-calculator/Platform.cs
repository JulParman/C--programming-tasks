using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ski_jumping_point_calculator
{
    class Platform
    {
        public float CountPlatformChange(float p, float kPoint)
        {
            float platformChange;
            platformChange = p * 5;
            return (kPoint * platformChange);
        }
    }
}
