using SF2022User27Lib;

Carculations carculations = new Carculations();

TimeSpan[] timeSpans = new TimeSpan[]
{
    new TimeSpan(10,0,0) , //60
    new TimeSpan(11,0,0) , //30
    new TimeSpan(15,0,0) , //10
    new TimeSpan(15,30,0) , //10
    new TimeSpan(16,50,0) , //40
};

int[] ints = new int[]
{
    60,
    30,
    10,
    10,
    40
};

TimeSpan start = new TimeSpan(8, 0, 0);
TimeSpan end = new TimeSpan(18, 0, 0);

int interval = 30;

string[] otvet = carculations.AvailablePeriods(timeSpans, ints, start, end, interval);

foreach (string v in otvet)
{
    Console.WriteLine(v);
}
