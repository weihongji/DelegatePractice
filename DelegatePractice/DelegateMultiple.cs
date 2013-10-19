using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DelegatePractice
{
	public class MyDelegateClass
	{
		public delegate void StringDelegate(string s);
	}

	public class MyImplementingClass
	{
		public static void WriteString(string s) {
			Console.WriteLine("Writing string {0}", s);
		}

		public static void LogString(string s) {
			Console.WriteLine("Logging string {0}", s);
		}

		public static void TransmitString(string s) {
			Console.WriteLine("Transmitting string {0}", s);
		}
	}
}
