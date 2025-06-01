using System;


//defining class
public class Job

//setting properties to store details- allowing reading and writing values
{
   public string _jobTitle;
   public string _company;
   public int _startYear;
   public int _endYear;

    
//display method
        public void Display()
    {
        Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
    }

}
