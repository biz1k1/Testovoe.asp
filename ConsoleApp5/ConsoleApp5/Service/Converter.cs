using ConsoleApp5.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5.Service
{
    public class Converter
    {
        public static List<ConverterEntity> ToList(DiseasesTherapist diseases)
        {
            var list = diseases.GetType().GetProperties()
            .Select(p => new ConverterEntity { Name = p.Name, Value = p.GetValue(diseases) })
            .ToList();
            return list;
        }
        public static List<ConverterEntity> ToList(DiseasesPsychiatrist diseases)
        {
            var list = diseases.GetType().GetProperties()
            .Select(p => new ConverterEntity { Name = p.Name, Value = p.GetValue(diseases) })
            .ToList();

            return list;
        }
        public static List<ConverterEntity> ToListForTest(InspectionResult diseases)
        {
            var list = diseases.GetType().GetProperties()
            .Select(p => new ConverterEntity { Name = p.Name, Value = p.GetValue(diseases) })
            .Take(7)
            .ToList();

            return list;
        }
        public static List<ConverterEntity> ToList(InspectionResult diseases)
        {
            var list = diseases.GetType().GetProperties()
            .Select(p => new ConverterEntity { Name = p.Name, Value = p.GetValue(diseases) })
            .ToList();

            return list;
        }
    }
}
