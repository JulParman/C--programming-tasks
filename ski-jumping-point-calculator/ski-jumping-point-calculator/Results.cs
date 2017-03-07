using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ski_jumping_point_calculator
{
    class Results
    {
        public float CountResult(float jump, float jumpStyle, float wind, float platform)
        {
            float result = jump + jumpStyle + wind - (platform);
            result = Convert.ToSingle(Math.Round(result, 1, MidpointRounding.AwayFromZero));
            return result;
        }
    }
}
