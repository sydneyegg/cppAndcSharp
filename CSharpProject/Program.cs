// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


GC.Collect(2, GCCollectionMode.Optimized); // Noncompliant
// FIX ME
class UninvokedEventSample
{
    private event Action<object, EventArgs> Happened; //Noncompliant

    public void RegisterEventHandler(Action<object, EventArgs> handler)
    {
        Happened += handler; //we register some event handlers
    }

    public void RaiseEvent()
    {
        if (Happened != null)
        {
            // Happened(this, null); // the event is never triggered, because this line is commented out.
        }
    }
}