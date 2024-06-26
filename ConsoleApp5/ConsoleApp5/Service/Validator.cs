using ConsoleApp5.Entity;
using ConsoleApp5.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5.Service
{
    public  class Validator
    {
        public Score  IsValidWeight(int weight)
        {
            if (weight >= 75 && weight <= 90)
            {
                return Score.Good;
            }
            if ( (weight >= 70 && weight <= 74) & (weight >=90 && weight<=100) )
            {
                return Score.Satisfactory;
            }
            return Score.Unsatisfactory;
        }

        public Score IsValidHeight(int height)
        {
            if (height >= 170 && height <= 185)
            {
                return Score.Good;
            }
            if ((height >= 160 && height <= 169) & (height >= 186 && height <= 190))
            {
                return Score.Satisfactory;
            }
            return Score.Unsatisfactory;
        }
        public Score IsValidAge(int age)
        {
            if (age >= 25 && age <= 35)
            {
                return Score.Good;
            }
            if ((age >= 23 && age <= 24) & (age >= 36 && age <= 37))
            {
                return Score.Satisfactory;
            }
            return Score.Unsatisfactory;
        }
        public Score IsValidSmoke(bool smoke)
        {
            if (smoke == false)
            {
                return Score.Good;
            }

            return Score.Unsatisfactory;
        }
        public Score IsValidVision(double vision)
        {
            if (vision == 1)
            {
                return Score.Good;
            }
            return Score.Unsatisfactory;

        }
        public Score IsValidTherapist(DiseasesTherapist diseases)
        {
            var obj = Converter.ToList(diseases);

            int diseasTrue = 0;
            foreach (var item in obj)
            {
                if (item.Value.Equals(true))
                {
                    diseasTrue++;
                }
            }


            if (diseasTrue < 2)
            {
                return Score.Good;
            }
            if (diseasTrue == 3)
            {
                return Score.Satisfactory;
            }

            return Score.Unsatisfactory;
        }
        public Score IsValidPsychiatrist(DiseasesPsychiatrist diseases)
        {
            var obj = Converter.ToList(diseases);

            int diseasTrue = 0;
            foreach (var item in obj)
            {
                if (item.Value.Equals(true))
                {
                    diseasTrue++;
                }
            }


            if (diseasTrue < 2)
            {
                return Score.Good;
            }
            if (diseasTrue == 3)
            {
                return Score.Satisfactory;
            }

            return Score.Unsatisfactory;
        }
        public Score IsValidTestWeightAndBadHabits(InspectionResult result,CandidateInfo candidateInfo)
        {
            var obj = Converter.ToListForTest(result);

            int scoreSatisfactory = 0;
            int scoreUnSatisfactory = 0;
            int scoreGood= 0;
            foreach (var item in obj)
            {
                if (item.Value.Equals(Score.Satisfactory))
                {
                    scoreSatisfactory++;
                }
                if (item.Value.Equals(Score.Good))
                {
                    scoreGood++;
                }
                else
                {
                scoreUnSatisfactory++;
                }
            }
            if (scoreGood == obj.Count)
            {
                return Score.Good;
            }

            if (scoreUnSatisfactory<0 && candidateInfo.Weight>110 && candidateInfo.DiseasesTherapists.virus==true )
            {
                return Score.Satisfactory;
            }

            
            return Score.Unsatisfactory;
        }
        public Score IsValidTestWeird(InspectionResult result, CandidateInfo candidateInfo)
        {
            var obj = Converter.ToListForTest(result);

            if (candidateInfo.Name.StartsWith("П"))
            {
                return Score.Good;
            }
            if(!candidateInfo.Name.StartsWith("П") && candidateInfo.Age > 68)
            {
                return Score.Satisfactory;
            }
            return Score.Unsatisfactory;

        }
        public Score IsValidTestTestMath(InspectionResult result, CandidateInfo candidateInfo)
        {
            var obj = Converter.ToListForTest(result);

            int scoreUnSatisfactory = 0;
            int scoreGood = 0;
            foreach (var item in obj)
            {
                if (item.Value.Equals(Score.Unsatisfactory))
                {
                    scoreUnSatisfactory++;
                }
                if (item.Value.Equals(Score.Good))
                {
                    scoreGood++;
                }

            }


            if (scoreGood <obj.Count && scoreUnSatisfactory<obj.Count && candidateInfo.Height/2==0)
            {
                return Score.Unsatisfactory;
            }
            return Score.Unsatisfactory;
        }

    }
}
