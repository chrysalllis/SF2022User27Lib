using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF2022User27Lib
{
    /// <summary>
    /// Класс который делает магию
    /// </summary>
    public class Carculations
    {
        public string[] AvailablePeriods
            (TimeSpan[] startTimes, int[] durations,TimeSpan beginWorkingTime,
            TimeSpan endWorkingTime,int consultationTime)
        {

            #region валидация
            if (startTimes.Length != durations.Length)
            {
                throw new ArgumentException("Массивы разной  длинны");
            }

            if (beginWorkingTime > endWorkingTime)
            {
                throw new ArgumentException("начало  работы больше  окончания");
            }

            if (consultationTime <= 0)
            {
                throw new ArgumentException("некорректный интервал  операции");
            }

            #endregion


            TimeSpan interval = new TimeSpan(0, consultationTime, 0);
            List<TimeSpan> startedIterator = NewMetSearchForStartPointhod(startTimes, durations, beginWorkingTime, endWorkingTime, interval);
            List<TimeSpan> tryTime = TryTimeintervals(startTimes, startedIterator, endWorkingTime, interval);
            string[] resultat = TimeSpanToStringArrya(interval, tryTime);

            return resultat;
            
        }

        

        private List<TimeSpan> TryTimeintervals(TimeSpan[] startTimes, List<TimeSpan> startedIterator, TimeSpan endWorkingTime, TimeSpan interval)
        {
            List<TimeSpan> tryTime = new List<TimeSpan>(); 
            foreach (var st in startedIterator) 
            {
                TimeSpan stop = st; 
                foreach (var t in startTimes) 
                {
                    if (st <= t) 
                    {
                        stop = t; 
                        break;
                    }

                    if (t == startTimes.Last())
                    {
                        stop = endWorkingTime; 
                    }
                }
                tryTime.AddRange(GenereticDate(st, stop, interval)); 
            }
            return tryTime;
        }

        private string[] TimeSpanToStringArrya(TimeSpan interval, List<TimeSpan> tryTime)
        {
            string[] resultat = new string[tryTime.Count]; 

            for (int i = 0; i < tryTime.Count; i++)
            {
                var next = tryTime[i] + interval; 

                resultat[i] = $"{MyPars(tryTime[i].Hours.ToString())}" +
                $":{MyPars(tryTime[i].Minutes.ToString())}-{MyPars(next.Hours.ToString())}" +
                $":{MyPars(next.Minutes.ToString())}"; 
            }

            return resultat;
        }

       

        private static List<TimeSpan> NewMetSearchForStartPointhod(TimeSpan[] startTimes, int[] durations, TimeSpan beginWorkingTime, TimeSpan endWorkingTime, TimeSpan interval)
        {
            List<TimeSpan> startedIterator = new List<TimeSpan>(); 
            
            if (beginWorkingTime + interval <= startTimes.First()) 
                startedIterator.Add(beginWorkingTime);

            for (int i = 0; i < startTimes.Length - 1; i++) 
            {
                var tim = startTimes[i] + new TimeSpan(0, durations[i], 0); 
                if (tim + interval <= startTimes[i + 1]) 
                {
                    startedIterator.Add(tim); 
                }
            }

            var last = startTimes.Last() + new TimeSpan(0, durations.Last(), 0); 
            if (last + interval <= endWorkingTime) 
                startedIterator.Add(last); 
            return startedIterator;
        }

        private List<TimeSpan> TryTimeintervals(TimeSpan[] startTimes, TimeSpan endWorkingTime, TimeSpan interval, List<TimeSpan> startedIterator)
        {
            List<TimeSpan> tryTime = new List<TimeSpan>(); 
            foreach (var st in startedIterator) 
            {
                TimeSpan stop = st; 
                foreach (var t in startTimes) 
                {
                    if (st <= t) 
                    {
                        stop = t; 
                        break;
                    }

                    if (t == startTimes.Last())
                    {
                        stop = endWorkingTime; 
                    }
                }
                tryTime.AddRange(GenereticDate(st, stop, interval)); 
            }
            return tryTime;
        }

        
        private string MyPars(string sumbol)
        {
            if (sumbol.Length == 1)
                return "0" + sumbol;
            else
                return sumbol;
        }

        private List<TimeSpan> GenereticDate(TimeSpan start, TimeSpan stop, TimeSpan interval)
        {
            List<TimeSpan> result = new List<TimeSpan>(); 
            var s = start;

            while (s + interval <= stop)
            {
                result.Add(s); 
                s += interval;
            }
            return result;
        }
    }
}
