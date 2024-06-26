using ConsoleApp5.Enum;
namespace ConsoleApp5.Entity
{
    public class InspectionResult
    {
        public Score Weight { get; set; }
        public Score Height { get; set; }
        public Score Age { get; set; }
        public Score Vision { get; set; }
        public Score Smoke { get; set; }
        public Score Therapist { get; set; }
        public Score Psychiatrist { get; set; }
        public Score TestWeightAndBadHabits { get; set; }
        public Score TestWeird { get; set; }
        public Score TestMath { get; set; }
    }
}
