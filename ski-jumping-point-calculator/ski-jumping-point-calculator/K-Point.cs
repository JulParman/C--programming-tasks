using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ski_jumping_point_calculator
{
    class K_Point
    {
        private int kPoint;
        private float kPointMultiplier;

        public float SetKpointMultiplier(int length)
        {
            kPoint = length;
            kPointMultiplier = 0f;
            if (kPoint >= 20 && kPoint <= 24)
            {
                kPointMultiplier = 4.8f;
            }
            else if (kPoint >= 25 && kPoint <= 29)
            {
                kPointMultiplier = 4.4f;
            }
            else if (kPoint >= 30 && kPoint <= 34)
            {
                kPointMultiplier = 4;
            }
            else if (kPoint >= 35 && kPoint <= 39)
            {
                kPointMultiplier = 3.6f;
            }
            else if (kPoint >= 40 && kPoint <= 49)
            {
                kPointMultiplier = 3.2f;
            }
            else if (kPoint >= 50 && kPoint <= 59)
            {
                kPointMultiplier = 2.8f;
            }
            else if (kPoint >= 60 && kPoint <= 69)
            {
                kPointMultiplier = 2.4f;
            }
            else if (kPoint >= 70 && kPoint <= 79)
            {
                kPointMultiplier = 2.2f;
            }
            else if (kPoint >= 80 && kPoint <= 99)
            {
                kPointMultiplier = 2.0f;
            }
            else if (kPoint >= 100 && kPoint <= 169)
            {
                kPointMultiplier = 1.8f;
            }
            else if (kPoint >= 170)
            {
                kPointMultiplier = 1.2f;
            }
            return kPointMultiplier;

        }
    }
}
