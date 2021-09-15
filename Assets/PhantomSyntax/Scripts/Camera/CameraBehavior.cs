using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    [Header("Camera Behavior Settings")]
    [SerializeField] private GameObject focusObject;
    [SerializeField] private SOEventSubject eventSubject;

    private void Start() {
        eventSubject.Trigger();
        eventSubject.TriggerObject(focusObject);
    }

    public void CameraAction() {
        print($"Hello, {focusObject.name}!");
    }

    public void CameraObjectAction(GameObject eventObject) {
        print($"Also, {eventObject.name}!");
    }
}