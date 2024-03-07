using UnityEngine;
using UnityEngine.Localization.Components;

public class LocalizationTextUpdator : MonoBehaviour
{
    public string timePassed;

    public LocalizationManager localizationManager;
    public LocalizeStringEvent localizationStringEvent;

    private void OnEnable()
    {
        localizationManager.timePassed.onValueChagned += Refresh;
    }

    private void OnDisable()
    {
        localizationManager.timePassed.onValueChagned -= Refresh;
    }

    [ContextMenu(nameof(Refresh))]
    private void Refresh(string newValue)
    {
        timePassed = newValue;
        localizationStringEvent.RefreshString();
    }
}