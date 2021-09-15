# Passing Unity Events of type with Scriptable Objects

Scriptable Objects in Unity have a multitude of uses from flat data containers to creating enumerated population and even observer pattern style event systems. Unity offers up <a rel="noreferrer noopener" href="https://unity.com/how-to/architect-game-code-scriptable-objects#architect-events" target="_blank">a great example of the last on their website</a>, courtesy of <a rel="noreferrer noopener" href="https://twitter.com/roboryantron" target="_blank">Ryan Hipple (@roboryantron)</a> from Schell Games. I wanted to take that example and expand on it to be able to pass GameObjects, booleans and other types so I worked out this method.

The first part is creating a Scriptable Object as the 'subject' that will register and unregister 'observers' to a List and then iterate through it to fire off a method as defined in the second part. In my example below, we start off creating the SOEventSubject and setting it up with a List as well as Register, Trigger and Unregister methods.

The second part is to create the EventObserver script for registering them to the subject. This sets up the TriggerEvent() method for executing a Unity Event after being called from the subject.

Once these are all setup, you can start to implement them in your scripts by adding the SOEventSubject you created and calling Trigger(). In the example below, I have created a simple script that prints out the name of the object every time the SOEventSubject.Trigger() method runs.

I created a capsule and gave it a custom name, then attached the EventObserver and CameraBehavior scripts to the Main Camera and filled in the objects, setting the EventObserver Unity Event to fire off CameraBehavior.CameraAction.

Now we can take this foundation and set it up so that you can pass parameters by <a rel="noreferrer noopener" href="https://docs.unity3d.com/ScriptReference/Events.UnityEvent_1.html" target="_blank">using a Unity Event of specific types</a>.  By modifying the existing code with the following, you can pass the GameObject through the Event trigger.

In SOEventSubject, add a new method that takes a GameObject. In EventObserver, create a new field for a Unity Event of type GameObject and create a new method that will Invoke that Unity Event and pass it the GameObject. And in CameraBehavior, add (or change if you want) a new method that takes a GameObject that will be called every time the event is triggered, then set your code up to call the new method.

Attach everything up and when we press Play, it should pass our dynamic GameObject through to CameraBehavior.CameraObjectAction. You can apply this same method to any (or multiple) type(s) by using UnityEvent<T1, T2, etc.. >. You can also choose to set it as a Static Parameter and populate your object from the Editor instead of dynamically through code.