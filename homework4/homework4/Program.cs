using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace homework4
{
    class Program
    {
        public delegate void AlarmEventHandler(object sender, AlarmEventArgs e);
        public class AlarmEventArgs : EventArgs
        {
            public int hour;
            public int minute;
            public int second;
        }
        public class AlarmClock
        {
            public event AlarmEventHandler anAlarmEvent;

            private int hour;
            private int minute;
            private int second;
            private bool alarmEnable;
            private AlarmEventArgs alarm;
            private Timer aTimer;
            public AlarmClock()
            {
                this.hour = DateTime.Now.Hour;
                this.minute = DateTime.Now.Minute;
                this.second = DateTime.Now.Second;

                aTimer = new Timer(1000);
                aTimer.Elapsed += new ElapsedEventHandler(Update);
                aTimer.AutoReset = true;
                aTimer.Enabled = true;
                alarm = new AlarmEventArgs();
                anAlarmEvent += Alarm;
                alarmEnable = false;
            }
            private void Update(object source, ElapsedEventArgs e)
            {
                this.second += 1;
                if (this.second >= 60)
                {
                    this.second -= 60;
                    this.minute += 1;
                    if (this.minute >= 60)
                    {
                        this.minute -= 60;
                        this.hour += 1;
                        if (hour >= 24)
                        {
                            this.hour -= 24;
                        }
                    }
                }
                if (alarm.hour == this.hour &&alarm.minute == this.minute &&alarm.second == this.second &&alarmEnable == true)
                {
                    anAlarmEvent(this, alarm);
                }
            }
            public void Closealarmclock()
            {
                alarmEnable = false;
            }
            public void Openalarmclock()
            {
                alarmEnable = true;
            }
            public void Setalarmclock()
            {
                int hour = 0;
                int minute = 0;
                int second = 0;
                try
                {
                    Console.Write("set the hour of your alarmclock：");
                    hour = int.Parse(Console.ReadLine());
                    if (hour >= 24)
                    {
                        throw new Exception();
                    }
                    Console.Write("set the minute of your alarmclock：");
                    minute = int.Parse(Console.ReadLine());
                    if (minute >= 60)
                    {
                        throw new Exception();
                    }
                    Console.Write("set the second of your alarmclock：");
                    second = int.Parse(Console.ReadLine());
                    if (second >= 60)
                    {
                        throw new Exception();
                    }
                }
                catch
                {
                    Console.WriteLine("Error!Please try again!");
                    Setalarmclock();
                }
                this.alarm.hour = hour;
                this.alarm.minute = minute;
                this.alarm.second = second;
            }
            private void Alarm(object sender, AlarmEventArgs e)
            {
                Console.WriteLine("Ding...！The current time is：" + this.hour + ":" + this.minute + ":" + this.second);
            }
        }
        static void Main(string[] args)
        {
            AlarmClock anAlarmClock = new AlarmClock();
            anAlarmClock.Setalarmclock();
            anAlarmClock.Openalarmclock();
            Console.WriteLine("The alarm have been set"+"\n");
            Console.WriteLine("Press any key to exit!");
            Console.ReadKey();
        }
    }
}
