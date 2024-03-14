using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Core.Environments;
using Unity.Services.RemoteConfig;
using UnityEngine;

namespace RemoteConfingCourse
{
    public class RemoteConfig : MonoBehaviour, IConfigContainer
    {
        public struct UserAttributes { }
        public struct AppAttributes { }

        public bool isFetched = false;

        public string enviroment;

        public List<ConfigInitializable> configs = new List<ConfigInitializable>();

        private void Awake()
        {
            FetchData();
        }

        [ContextMenu(nameof(FetchData))]
        private async void FetchData()
        {
            isFetched = false;

            try
            {
                if (Utilities.CheckForInternetConnection())
                {
                    var options = new InitializationOptions();
                    options.SetEnvironmentName(enviroment);

                    await UnityServices.InitializeAsync(options);

                    if (AuthenticationService.Instance.IsSignedIn == false)
                    {
                        await AuthenticationService.Instance.SignInAnonymouslyAsync();
                    }
                }

                RemoteConfigService.Instance.FetchCompleted -= ApplyRemoteSettings;
                RemoteConfigService.Instance.FetchCompleted += ApplyRemoteSettings;

                await RemoteConfigService.Instance.FetchConfigsAsync(new UserAttributes(), new AppAttributes());
            }
            catch (Exception exception)
            {
                Debug.LogError(exception);
            }
        }

        private void ApplyRemoteSettings(ConfigResponse configResponse)
        {
            isFetched = true;

            foreach (var config in configs)
            {
                config.Initialize(this);
            }
        }

        private async Task Validate(int numberOfTries = 5)
        {
            while (isFetched == false && numberOfTries >= 0)
            {
                await Task.Delay(500);
                numberOfTries--;
            }
        }

        public async Task<string> GetString(string key, string defaultValue = "null", int numberOfTries = 5)
        {
            await Validate();
            return RemoteConfigService.Instance.appConfig.GetString(key, defaultValue);
        }

        public async Task<int> GetInt(string key, int defaultValue = 0, int numberOfTries = 5)
        {
            await Validate();
            return RemoteConfigService.Instance.appConfig.GetInt(key, defaultValue);
        }

        public async Task<float> GetFloat(string key, float defaultValue = 0, int numberOfTries = 5)
        {
            await Validate();
            return RemoteConfigService.Instance.appConfig.GetFloat(key, defaultValue);
        }
    }
}