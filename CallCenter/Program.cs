using System;
using System.Collections.Generic;
using System.Linq;

namespace CallCenter
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            
            //Console.WriteLine(CallCenterTimeMgt.checkTimeValidity("Mar 4, 2021 1pm"));
        }       
    }


    public static class CallCenterTimeMgt
    {
        private static Dictionary<string,string> OpeningTimes = new Dictionary<string, string>{
                {"Monday","9am-6pm"}, {"Tuesday","9am-6pm"}, {"Wednesday","9am-6pm"},
                {"Thursday","9am-8pm"},{"Friday","9am-10pm"},{"Saturday","9am-12:30pm"},
                {"Sunday","-"}
        };

        public static string checkTimeValidity(string timeofDay)
        {
            //inistialize operating time of the day
            var operatingTime = String.Empty;
            //parse timeofday into a proper DAtetime object
            var dateToCheck = DateTime.Parse(timeofDay);
            //Get day of the week from dateToCheck and use to get operating hours fro the dictionary used as store
            string day = dateToCheck.DayOfWeek.ToString();
            _ = OpeningTimes.TryGetValue(day, out operatingTime);

            //split the operating hours so as to get both opening and closing times
            var spliTime = operatingTime.Split("-");


            if (CheckIfDateIsSunday(dateToCheck))
            {
                return "Invalid Time Given";
            }
            if(!TimeisWithinOperatingHour(dateToCheck, spliTime[0], spliTime[1]))
            {
                return "Invalid Time Given";
            }
            if (!CheckTimeisMoreThan2Hours(dateToCheck))
            {
                return "Invalid Time Given";
            }

            if (!CheckTimeIsLessThan6Days(dateToCheck))
            {
                return "Invalid Time Given";
            }

            return "Valid Time Given";
        }


        public static bool CheckIfDateIsSunday(DateTime dateToCheck)
        {
            return dateToCheck.DayOfWeek.ToString() == "Sunday";
        }

        public static bool TimeisWithinOperatingHour(DateTime dateToCheck, string start, string end)
        {
            //Combine opening hours with the required callback date to reflect the true call back day and time 
            var startTime = DateTime.Parse(dateToCheck.ToShortDateString() + " " + start);
            var closeTime = DateTime.Parse(dateToCheck.ToShortDateString() + " " + end);
            //checkif the time give is within working hours
            return dateToCheck >= startTime && dateToCheck <= closeTime;
        }

        public static bool CheckTimeIsLessThan6Days(DateTime dateToCheck)
        {
            //get 5 days from now
            var _5daysFromNow = DateTime.Now.AddDays(6);
            return dateToCheck < _5daysFromNow;
        }

        public static bool CheckTimeisMoreThan2Hours(DateTime dateToCheck)
        {
            //get 2 hours from now
            var _2hoursFromNow = DateTime.Now.AddHours(2);
            return dateToCheck >= _2hoursFromNow;
        }


    }

}
 