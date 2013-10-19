using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace DelegatePractice
{
	class AppMain
	{
		static void Main(string[] args) {
			int flag = 4;
			switch (flag) {
				case 1: // DelegateSingle
					Pair<Human> humanPair = new Pair<Human>(new Human("Jesse"), new Human("Maik"));
					Console.WriteLine("Original content:\t{0}", humanPair.ToString());
					humanPair.Sort(Human.WhichIsFirstHuman);
					Console.WriteLine("After sort:\t\t{0}", humanPair.ToString());
					break;
				case 2: // DelegateMultiple
					MyDelegateClass.StringDelegate Writer, Logger, Transmitter;
					MyDelegateClass.StringDelegate MulticastDelegate;

					Writer = new MyDelegateClass.StringDelegate(MyImplementingClass.WriteString);
					Logger = new MyDelegateClass.StringDelegate(MyImplementingClass.LogString);
					Transmitter = new MyDelegateClass.StringDelegate(MyImplementingClass.TransmitString);

					Writer("The Writer");
					Logger("The Logger");
					Transmitter("The Transmitter");

					MulticastDelegate = Writer + Logger;
					Console.WriteLine("Writer + Logger");
					MulticastDelegate("Multicaster 1");

					MulticastDelegate += Transmitter;
					Console.WriteLine("+= Transmitter");
					MulticastDelegate("Multicaster 2");

					MulticastDelegate -= Logger;
					Console.WriteLine("-= Logger");
					MulticastDelegate("Multicaster 3");
					break;
				case 3: // DelegateEvent
					Clock theClock = new Clock();
					theClock.OnSecondChange += delegate(object clock, TimeInfoEventArgs e) {
						Console.WriteLine("Time: {0}:{1}:{2}", e.hour, e.minute, e.second);
					};
					theClock.OnSecondChange += delegate(object clock, TimeInfoEventArgs e) {
						Console.WriteLine("=============");
					};
					theClock.Run();
					break;
				case 4:
					DelegateAsync del = new DelegateAsync();
					int counter1 =0, counter2 = 0;
					del.theDelegate += delegate() {
						Console.WriteLine("{0} Busy in first delegate ...", DateTime.Now);
						Thread.Sleep(2000);
						Console.WriteLine("{0} Done with work first delegate ({1})", DateTime.Now, counter1);
						return counter1++;
					};
					del.theDelegate += delegate() {
						Console.WriteLine("{0} ========================: {1}", DateTime.Now, counter2);
						return counter2+=2;
					};
					del.Run();
					break;
			}

			if (flag != 4) {
				Console.WriteLine("Press any key to exit ...");
			}
			Console.ReadKey();
		}
	}
}
