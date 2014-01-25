using System;
using System.Collections.Generic;
using UnityEngine;

namespace Library
{
	public delegate void EventFunction(object data);
	public class EventBus
	{
		protected static Dictionary<int, List<EventFunction>> EventListener { get; set; }

		static EventBus()
		{
			EventListener = new Dictionary<int, List<EventFunction>>();
		}

		public static void Push(int eventId, object data)
		{
			List<EventFunction> listeners;
			EventListener.TryGetValue(eventId, out listeners);
			if (listeners != null)
			{
				foreach (EventFunction eventListener in listeners)
				{
					eventListener.Invoke(data);
				}
			}
			else
			{
				Debug.Log("Can't find Event ID: " + eventId);
			}
		}

		public static void Register(int eventId, EventFunction function)
		{
			List<EventFunction> listeners;
			EventListener.TryGetValue(eventId, out listeners);
			if (listeners == null)
			{
				listeners = new List<EventFunction>();
				EventListener.Add(eventId, listeners);
			}
			listeners.Add(function);
		}

		public static void Unregister(int eventId, EventFunction function)
		{
			List<EventFunction> listeners;
			EventListener.TryGetValue(eventId, out listeners);
			if (listeners != null)
			{
				listeners.Remove(function);
			}
		}
	}
}

