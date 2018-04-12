using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowboardApp.Domain
{
    public class AthleteHomeResort

    {
        public int AthleteId { get; set; }
        public int HomeResortId { get; set; }

        public Athlete Athlete { get; set; }
        public HomeResort HomeResort { get; set; }
    }
}
