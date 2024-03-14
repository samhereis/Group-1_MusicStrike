using Unity.Services.Analytics;
using UnityEngine;

namespace Analytics
{
    public class EventsTest : MonoBehaviour
    {
        public EventsManager eventsManager;

        [ContextMenu(nameof(Send_PlayButtonClickedEvent))]
        private void Send_PlayButtonClickedEvent()
        {
            CustomEvent playButtonClickedEvent = new CustomEvent("OnPlayButtonClick");
            playButtonClickedEvent.Add("TimeSpentInGame", Time.time.ToString());

            eventsManager.SendEvent(playButtonClickedEvent);
        }
    }
}