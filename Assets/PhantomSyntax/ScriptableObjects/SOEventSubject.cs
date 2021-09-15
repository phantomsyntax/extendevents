using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEventSubject", menuName = "Event Object/Subject", order = 0)]
public class SOEventSubject : ScriptableObject
{
    [Header("Event Settings")]
                     public List<EventObserver> observers = new List<EventObserver>();

    public void Register(EventObserver observer) {
        // Adds the observer to the list of Observers
        observers.Add(observer);
    }

    public void Trigger() {
        foreach (EventObserver eventObserver in observers) {
            eventObserver.TriggerEvent();
        }
    }

    public void TriggerObject(GameObject eventObject) {
        foreach (EventObserver eventObserver in observers) {
            eventObserver.TriggerObjectEvent(eventObject);
        }
    }

    public void Unregister(EventObserver observer) {
        // Removes the observer from the List of Observers
        // TODO: check List first
        observers.Remove(observer);
    }
}