using System;

namespace Core.Services.EventBus
{
    /// <summary>
    ///  
    /// </summary>
    public static class EventBus<T> where T: Event
    {
        public static event Action<T, T> OnEvent;

        public static void Publish(T pEvent, T pPublisher)
        {
            OnEvent?.Invoke(pEvent,  pPublisher);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public abstract class Event
    {
    }
}