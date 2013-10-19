using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace DelegatePractice
{
	class DelegateAsync
	{
		private int lifeCounter;
		private DelegateThatReturnsInt firstDelegate;

		public delegate int DelegateThatReturnsInt();

		public event DelegateThatReturnsInt theDelegate;

		public void Run() {
			for (; ; ) {
				Thread.Sleep(4000);

				if (theDelegate != null) {
					foreach (DelegateThatReturnsInt del in theDelegate.GetInvocationList()) {
						if (firstDelegate == null) {
							firstDelegate = del;
						}
						del.BeginInvoke(new AsyncCallback(CallBack), del);
					}
				}
				if (++lifeCounter >= 4) {
					break;
				}
			}
		}

		private void CallBack(IAsyncResult result) {
			DelegateThatReturnsInt del = (DelegateThatReturnsInt)result.AsyncState;
			//int value = del();
			//Console.WriteLine("{0} Delegate returned value: {1}", DateTime.Now, value);

			if (lifeCounter >= 4 && del == firstDelegate) {
				Console.WriteLine("Press any key to exit ...");
			}
		}
	}
}
