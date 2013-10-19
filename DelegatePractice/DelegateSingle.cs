using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DelegatePractice
{
	public enum Comparison
	{
		TheFirstComesFirst = 1,
		TheSecondComesFirst = 2
	}

	public delegate Comparison WhichIsFirst<T>(T p1, T p2);

	public class Pair<T>
	{
		T[] thePair = new T[2];

		public Pair(T p1, T p2) {
			thePair[0] = p1;
			thePair[1] = p2;
		}

		public override string ToString() {
			return thePair[0].ToString() + ", " + thePair[1].ToString();
		}

		public void Sort(WhichIsFirst<T> theDelegatedFun) {
			if (theDelegatedFun(thePair[0], thePair[1]) == Comparison.TheSecondComesFirst) {
				T temp = thePair[0];
				thePair[0] = thePair[1];
				thePair[1] = temp;
			}
		}
	}

	public class Human
	{
		private string name;

		public Human(string name) {
			this.name = name;
		}

		public override string ToString() {
			return name;
		}

		public static Comparison WhichIsFirstHumanFunc(Human h1, Human h2) {
			return string.Compare(h1.name, h2.name) < 0 ? Comparison.TheFirstComesFirst : Comparison.TheSecondComesFirst;
		}

		public static WhichIsFirst<Human> WhichIsFirstHuman {
			get {
				return new WhichIsFirst<Human>(WhichIsFirstHumanFunc);
			}
		}
	}
}
