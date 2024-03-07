using DataClasses;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class LocalizationManager : MonoBehaviour
{
    public string playerName;
    public ObservableValue<string> timePassed = new ObservableValue<string>();
    public int localIndex;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        timePassed.ChangeValue(Time.time.ToString());
    }

    [ContextMenu(nameof(ChangeLanguage))]
    private async void ChangeLanguage()
    {
        var hangle = LocalizationSettings.InitializationOperation;
        await hangle.Task;

        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[localIndex];
    }
}