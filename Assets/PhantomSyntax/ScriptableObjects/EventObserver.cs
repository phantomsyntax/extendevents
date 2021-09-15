using UnityEngine;
using UnityEngine.Events;

public class EventObserver : MonoBehaviour
{
    [Header("Observer Settings")]
    [SerializeField] private SOEventSubject eventSubject;
    [SerializeField] private UnityEvent unityEvent;
    [SerializeField] private UnityEvent<GameObject> unityObjectEvent;

    private void OnEnable() {
        if (eventSubject != null) {
            eventSubject.Register(this);
        }
    }

    public void TriggerEvent() {
        unityEvent.Invoke();
    }

    public void TriggerObjectEvent(GameObject eventObject) {
        unityObjectEvent.Invoke(eventObject);
    }

    private void OnDisable() {
        if (eventSubject != null) {
            eventSubject.Unregister(this);
        }
    }
}