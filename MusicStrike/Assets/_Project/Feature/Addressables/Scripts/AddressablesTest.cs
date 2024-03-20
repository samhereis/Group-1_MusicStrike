using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace AddressablesCourse
{
    public class AddressablesTest : MonoBehaviour
    {
        public GameObject UI;
        public string uiResourcePath = "UI";
        public string uiAddressableKey = "UI";
        public AssetReferenceGameObject uiAddressableReference;

        private void Awake()
        {
            LoadAddressable_Reference();
        }

        [ContextMenu(nameof(LoadStandard))]
        public void LoadStandard()
        {
            Instantiate(UI);
        }

        [ContextMenu(nameof(LoadResource))]
        public async void LoadResource()
        {
            var operation = Resources.LoadAsync<GameObject>(uiResourcePath);
            while (operation.isDone == false) { await Task.Yield(); }

            Instantiate(operation.asset);
        }

        [ContextMenu(nameof(LoadAddressable_Key))]
        public async void LoadAddressable_Key()
        {
            var operation = Addressables.LoadAssetAsync<GameObject>(uiAddressableKey);
            while (operation.IsDone == false) { await Task.Yield(); }

            Instantiate(operation.Result);
        }

        public async void LoadAddressable_Reference()
        {
            var operation = Addressables.LoadAssetAsync<GameObject>(uiAddressableReference);
            while (operation.IsDone == false) { await Task.Yield(); }

            Instantiate(operation.Result);
        }
    }
}