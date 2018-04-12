using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowboardApp.Domain
{
    public class Snowboard

    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }
        public int Length { get; set; }
        public int AthelteId { get; set; }
        public Athlete Athlete { get; set; }
    }
}
