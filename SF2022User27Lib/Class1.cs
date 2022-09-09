using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF2022User27Lib
{
    public class Class1
    {
        private List<TimeSpan> tempTimeSpan;

        public string[] AvailablePeriods
            (TimeSpan[] startTimes, int[] durations, TimeSpan beginWorkingTime,
            TimeSpan endWorkingTime, int consultationTime)
        {
            List<TimeSpan> TempTimeSpan= new List<TimeSpan>();

            List<TimeSpan> StartedTimeSpan = GetStartedTimeSpan(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);

            foreach (var item in StartedTimeSpan)
            {
                TempTimeSpan.AddRange(BeginConsulationTimeOneClient(item, GetStoped(item, startTimes), consultationTime));
            }

            return TimeSpanPeriodsTostringArray(tempTimeSpan, consultationTime);

        }

        private TimeSpan GetStoped(TimeSpan item, TimeSpan[] startTimes)
        {
            throw new NotImplementedException();
        }

        private List<TimeSpan> GetStartedTimeSpan(TimeSpan[] startTimes, int[] durations, TimeSpan beginWorkingTime, TimeSpan endWorkingTime, int consultationTime)
        {
            throw new NotImplementedException();
        }

        private string[] TimeSpanPeriodsTostringArray(List<TimeSpan> tempTimeSpan, int consultationTime)
        {
            List<string> resuil = new List<string>();

            for (int i=0; i< tempTimeSpan.Count; i++)
            {
                string h =ParsOneSumbolInTwo( tempTimeSpan[i].Hours.ToString()); // "08"
                string m = ParsOneSumbolInTwo(tempTimeSpan[i].Hours.ToString()); // "00"
                
                TimeSpan endTime= tempTimeSpan[i] +new TimeSpan(0,consultationTime,0);
                string hEnd = ParsOneSumbolInTwo(endTime.Hours.ToString()); // "08"
                string mEnd= ParsOneSumbolInTwo (endTime.Minutes.ToString()); // "30"

                var st = $"{h}:{m}-{hEnd}:{mEnd}";
                resuil.Add(st);
            }
            return resuil.ToArray();
        }

        private string ParsOneSumbolInTwo(string h)
        {
            if (h.Length == 1)
                return "0" + h;
            else
                return h;
        }

        private List<TimeSpan> BeginConsulationTimeOneClient(TimeSpan beginWorkingTime, TimeSpan endWorkingTime, int consultationTime)
        {
            TimeSpan timeInterval = new TimeSpan(0, consultationTime, 0);
            List<TimeSpan> result = new List<TimeSpan>();

            var tempSum = beginWorkingTime;
            
            while (tempSum < endWorkingTime)
            {
                result.Add(tempSum);
                tempSum += timeInterval;

            }
            return result;
        }
    }
}
