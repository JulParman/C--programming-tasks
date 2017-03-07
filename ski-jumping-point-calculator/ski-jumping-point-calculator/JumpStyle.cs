using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ski_jumping_point_calculator
{
    class JumpStyle
    {
        private List<float> Reviews;

        public float CountReview(float result1, float result2, float result3, float result4, float result5)
        {
            Reviews = new List<float>();
            float sum;
            float min = 0;
            float max = 0;
            Reviews.Add(result1);
            Reviews.Add(result2);
            Reviews.Add(result3);
            Reviews.Add(result4);
            Reviews.Add(result5);
            min = Reviews.Min();
            max = Reviews.Max();
            Reviews.Remove(min);
            Reviews.Remove(max);
            sum = Reviews.Sum();
            return sum;
        }
    }
}
