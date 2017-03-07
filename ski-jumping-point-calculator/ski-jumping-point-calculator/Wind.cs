using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ski_jumping_point_calculator
{
    class Wind
    {
        private List<float> windList;

        public float CountWind(float w1, float w2, float w3, float w4, float w5, int kPoint, float kPointMultiplier)
        {
            windList = new List<float>();
            float sum;
            windList.Add(w1);
            windList.Add(w2);
            windList.Add(w3);
            windList.Add(w4);
            windList.Add(w5);
            sum = windList.Sum() / windList.Count;
            sum = sum * (kPoint - 36) / 20;
            float sumR = Convert.ToSingle(Math.Round((sum * 2), MidpointRounding.AwayFromZero));
            sum = sumR / 2;
            sum = kPointMultiplier * sum;
            return sum;
        }
    }
}
