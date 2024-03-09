using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobDescription = "Warehouse Worker";
        job1._companyName = "Amazon";
        job1._startDate = "2022";
        job1._endDate = "2023";

        Job job2 = new Job();
        job2._jobDescription = "Intern";
        job2._companyName = "Curriculum Square";
        job2._startDate = "2020";
        job2._endDate = "2022";

        Resume myresume = new Resume();
        myresume._name = "JeanAlbert Arnold";

        myresume._jobs.Add(job1);
        myresume._jobs.Add(job2);

        myresume.Display();
    }
}
