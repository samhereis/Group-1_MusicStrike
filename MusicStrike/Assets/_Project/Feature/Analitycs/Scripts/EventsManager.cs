using System.Threading.Tasks;
using Unity.Services.Analytics;
using Unity.Services.Core;
using UnityEngine;

namespace Analytics
{
    public class EventsManager : MonoBehaviour
    {
        private async void Awake()
        {
            await Initialize();
            SetEnabled(true);
        }

        private async Task Initialize()
        {
            await UnityServices.InitializeAsync();
        }

        public void SetEnabled(bool enabled)
        {
            if (enabled == true)
            {
                AnalyticsService.Instance.StartDataCollection();
            }
            else
            {
                AnalyticsService.Instance.StopDataCollection();
            }
        }

        public void SendEvent(string eventName)
        {
            AnalyticsService.Instance.RecordEvent(eventName);
            AnalyticsService.Instance.Flush();
        }

        public void SendEvent(Unity.Services.Analytics.Event newEvent)
        {
            AnalyticsService.Instance.RecordEvent(newEvent);
            AnalyticsService.Instance.Flush();
        }
    }
}