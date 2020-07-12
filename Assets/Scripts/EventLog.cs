using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventLog : MonoBehaviour
{
    [System.Serializable]
    public struct MyEvent
    {
        public int index;
        public string eventName;
        public string eventNarrative;
    }

    private List<MyEvent> myEvents;

    private void Awake()
    {
        myEvents = new List<MyEvent>();
        if (FindObjectsOfType<EventLog>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void LogEvent(string name, string narrative)
    {
        MyEvent e = new MyEvent();
        e.index = myEvents.Count;
        e.eventName = name;
        e.eventNarrative = narrative;
        myEvents.Add(e);
    }

}
