using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using ZooEmulator.Repo;

namespace ZooEmulator.Menues
{
    class GodOfDeath
    {
        private Timer _timer;

        public int Period { get; set; }
        public ZooRepo Zoo { get; set; }

        public GodOfDeath()
        {
            _timer = new Timer();
        }

        public GodOfDeath(ZooRepo zoo, int period)
        {
            Period = period;
            Zoo = zoo;
            SetWatchPeriod(Period);
            WatchFor(Zoo);
            WakeUp();
        }

        public void SetWatchPeriod(int period)
        {
            Period = period;
            _timer = new Timer(Period);
        }

        public void WatchFor(ZooRepo zoo)
        {
            Zoo = zoo;
            _timer.Elapsed += (sender, e) => TouchSomebody(sender, e, Zoo);
        }

        public void WakeUp()
        {
            _timer.Enabled = true;
        }

        public void Asleep()
        {
            _timer.Enabled = false;
        }

        private void TouchSomebody(object source, ElapsedEventArgs e, ZooRepo zoo)
        {
            var victim = zoo.GetRandomAnimal();
            if (victim != null)
            {
                victim.ChangeStatus();
            }
        }
    }
}
