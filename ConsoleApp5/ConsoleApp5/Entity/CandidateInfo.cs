using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5.Entity
{
    public class CandidateInfo
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public int Age { get; set; }
        public double Vision { get; set; }
        public bool Smoke { get; set; }
        public DiseasesTherapist DiseasesTherapists { get; set; }
        public DiseasesPsychiatrist DiseasesPsychiatrists { get; set; }
    }
}
