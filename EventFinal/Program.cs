using System;
using System.Collections.Generic;

namespace EventFinal
{
	class Program
	{
		static void Main(string[] args)
		{
			//Step 5 - Associate the event with the handler


			//Step 6 - Causing the event to occur
			CommonStack<int> item = new CommonStack<int>();
			item.Push(10);
			item.Push(20);
			item.Push(30);

		}
	}

	public class CommonStack<T>
	{

		private List<T> StackList;
		private Notify notify;
		private StackListener listen;

		public CommonStack()
		{
			StackList = new List<T>();
			notify = new Notify();
			listen = new StackListener();
			notify.PushEvent += listen.HandlePush;

		}


		public void Push(T t)
		{
			notify.PushNotify("push");
			Console.WriteLine("{0}", t);
			StackList.Add(t);

		}
	}

	// Step 4 - Creating code that should occur when the event happens
	public class StackListener
	{

		public void HandlePush(object sender, StackEventArgs e)
		{
			Console.WriteLine("{0} item", e.str);
		}


	}

	// Step 3 - Declaring the code for the event

	public class Notify
	{
		public event PushEventHandeler PushEvent;

		public void PushNotify(string msg)
		{
			if (PushEvent != null)
			{
				PushEvent(this, new StackEventArgs(msg));

			}
		}


	}

	// Step 2 - Setting up the delegate for the event
	public delegate void PushEventHandeler(object source, StackEventArgs e);
	
	// Step 1 - Creating a class to pass arguments for the event handlers 	
	public class StackEventArgs : EventArgs
	{
		public string str { get; set; }
		public StackEventArgs(string str)
		{
			this.str = str;

		}
	}
}
