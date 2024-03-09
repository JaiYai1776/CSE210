using System;

public class Job
{
    public string _jobDescription;
    public string _companyName;
    public string _startDate;
    public string _endDate;

    public void Display()
    {
        Console.WriteLine($"{_jobDescription} at {_companyName} from {_startDate} to {_endDate}");
    }
}