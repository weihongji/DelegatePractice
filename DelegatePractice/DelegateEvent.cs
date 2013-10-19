using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace DelegatePractice
{
	public class TimeInfoEventArgs : EventArgs
	{
		public readonly int hour, minute, second;

		public TimeInfoEventArgs(int hour, int minute, int second) {
			this.hour = hour;
			this.minute = minute;
			this.second = second;
		}
	}

	public class Clock
	{
		private int hour, minute, second;
		private int lifeCounter;

		public delegate void OnSecondChangeHandler(object clock, TimeInfoEventArgs e);

		public event OnSecondChangeHandler OnSecondChange;

		public void Run() {
			for (; ; ) {
				Thread.Sleep(10);

				DateTime dt = DateTime.Now;
				if (dt.Second != second) {
					if (OnSecondChange != null) {
						OnSecondChange(this, new TimeInfoEventArgs(dt.Hour, dt.Minute, dt.Second));
					}
					this.hour = dt.Hour;
					this.minute = dt.Minute;
					this.second = dt.Second;
					if (lifeCounter++ >= 10) {
						break;
					}
				}
			}
		}
	}
}
