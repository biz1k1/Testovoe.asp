using ConsoleApp5;
using ConsoleApp5.Entity;
using ConsoleApp5.Enum;
using ConsoleApp5.Service;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;

class Candidate
{
    public CandidateInfo CardInfo = new CandidateInfo();
    public InspectionResult InspectionResult;
    public Candidate(InspectionResult inspectionResult)
    {
        InspectionResult = inspectionResult;
    }

}
class Therapist
{
    private DiseasesTherapist diseases=new DiseasesTherapist();
    public DiseasesTherapist Examination()
    {
        Console.WriteLine("Сейчас начнется  осмотр Терапевта. Ответы зачитываются в форате 'Да/Нет')");

        Console.WriteLine("Есть ли у вас Насморк?");
        diseases.cold = Check.CheckWord(Console.ReadLine());

        Console.WriteLine("Есть ли у вас бронхит?");
        diseases.bronchitis= Check.CheckWord(Console.ReadLine());

        Console.WriteLine("Есть ли у вас вирусы?");
        diseases.virus = Check.CheckWord(Console.ReadLine());

        Console.WriteLine("Есть ли у вас аллергия?");
        diseases.allergy = Check.CheckWord(Console.ReadLine());

        Console.WriteLine("Есть ли у вас ангина?");
        diseases.quinsy = Check.CheckWord(Console.ReadLine());

        Console.WriteLine("Есть ли у вас бессоинца?");
        diseases.insomnia = Check.CheckWord(Console.ReadLine());

        return diseases;
    }
}
class Psychiatrist
{
    private DiseasesPsychiatrist diseases=new DiseasesPsychiatrist();
    public DiseasesPsychiatrist Examination()
    {
        Console.WriteLine("Сейчас начнется  осмотр Психиатора. Ответы зачитываются в форате 'Да/Нет')");

        Console.WriteLine("Есть ли у вас алкоголизм?");
        diseases.alcoholism= Check.CheckWord(Console.ReadLine());

        Console.WriteLine("Есть ли у вас бессоница?");
        diseases.insomnia= Check.CheckWord(Console.ReadLine());

        Console.WriteLine("Есть ли у вас наркомания?");
        diseases.narcomania= Check.CheckWord(Console.ReadLine());

        Console.WriteLine("Есть ли у вас травмы?");
        diseases.injury= Check.CheckWord(Console.ReadLine());

        return diseases;
    }
}
class Inspection
{
    public Candidate Candidate;
    public Validator Validator;
    public Therapist Therapist;
    public Psychiatrist Psychiatrist;
    public Inspection(Candidate candidate,Validator validator,Therapist therapist,Psychiatrist psychiatrist)
    {
        Psychiatrist = psychiatrist;
        Therapist = therapist;
        Candidate = candidate;
        Validator = validator;
    }
    public void InitialInspection()
    {
        Console.WriteLine("Сейчас начнется  первичный осмотр");

        Console.WriteLine("Введите имя:");
        Candidate.CardInfo.Name = Console.ReadLine();

        Console.WriteLine("Курите");
        Candidate.CardInfo.Smoke = Check.CheckWord(Console.ReadLine());

        Console.WriteLine("Введите Рост");
        Candidate.CardInfo.Height = Int32.Parse(Console.ReadLine());

        Console.WriteLine("Введите Вес");
        Candidate.CardInfo.Weight = Int32.Parse(Console.ReadLine());

        Console.WriteLine("Введите диоптрию");
        Candidate.CardInfo.Vision = Int32.Parse(Console.ReadLine());
        
        Console.WriteLine("Введите Ваш возраст");
        Candidate.CardInfo.Age = Int32.Parse(Console.ReadLine());

    }
    public void TherapistInspection()
    {
        Candidate.CardInfo.DiseasesTherapists=Therapist.Examination();
    }
    public void PsychiatristInspection()
    {
        Candidate.CardInfo.DiseasesPsychiatrists=Psychiatrist.Examination();
    }
    public void FillResult()
    {
        Candidate.InspectionResult.Weight = Validator.IsValidWeight(Candidate.CardInfo.Weight);

        Candidate.InspectionResult.Height = Validator.IsValidHeight(Candidate.CardInfo.Height);

        Candidate.InspectionResult.Age = Validator.IsValidAge(Candidate.CardInfo.Age);

        Candidate.InspectionResult.Vision = Validator.IsValidVision(Candidate.CardInfo.Vision);

        Candidate.InspectionResult.Therapist = Validator.IsValidTherapist(Candidate.CardInfo.DiseasesTherapists);

        Candidate.InspectionResult.Smoke = Validator.IsValidSmoke(Candidate.CardInfo.Smoke);

        Candidate.InspectionResult.Psychiatrist = Validator.IsValidPsychiatrist(Candidate.CardInfo.DiseasesPsychiatrists);

        Candidate.InspectionResult.TestWeightAndBadHabits = Validator.IsValidTestWeightAndBadHabits(Candidate.InspectionResult,Candidate.CardInfo);

        Candidate.InspectionResult.TestWeird = Validator.IsValidTestWeird(Candidate.InspectionResult, Candidate.CardInfo);

        Candidate.InspectionResult.TestMath = Validator.IsValidTestTestMath(Candidate.InspectionResult, Candidate.CardInfo);



    }
    public void PassCheckInspection()
    {
        var result=Converter.ToList(Candidate.InspectionResult);

        int scoreUnSatisfactory = 0;
        int scoreSatisfactory = 0;
        foreach (var item in result)
        {
            if (item.Value.Equals(Score.Satisfactory))
            {
                scoreSatisfactory++;
            }
            if (item.Value.Equals(Score.Unsatisfactory))
            {
                scoreUnSatisfactory++;
            }
        }


        if(scoreUnSatisfactory>0 && scoreSatisfactory <= 3)
        {
            Console.WriteLine($"{Candidate.CardInfo.Name} не подходит");
            foreach (var item in result)
            {
                if(item.Value.Equals(Score.Unsatisfactory) || item.Value.Equals(Score.Satisfactory))
                {
                Console.WriteLine($" Проблема кандидата: {item.Name}-{item.Value}");
                }
            }
        }
        else
        {
            Console.WriteLine($"{Candidate.CardInfo.Name} подходит");

        }
    }
}
class Program
{
    static void Main()
    {
        var services = new ServiceCollection();
        services.AddTransient<Candidate>();
        services.AddTransient<Psychiatrist>();
        services.AddTransient<Therapist>();
        services.AddTransient<Inspection>();
        services.AddTransient<InspectionResult>();
        services.AddTransient<Validator>();
        var provider = services.BuildServiceProvider();

        var inspection = provider.GetService<Inspection>();


        inspection.InitialInspection();
        inspection.TherapistInspection();
        inspection.PsychiatristInspection();
        inspection.FillResult();
        inspection.PassCheckInspection();


    }
}