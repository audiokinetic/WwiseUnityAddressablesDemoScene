#if AK_WWISE_ADDRESSABLES && UNITY_ADDRESSABLES

using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AddressablePrefabLoader : MonoBehaviour
{
    public AssetReference reference;

    public void Load()
    {
        Addressables.LoadAssetAsync<GameObject>(reference).Completed += asyncOp =>
        {
            if (asyncOp.Status == AsyncOperationStatus.Succeeded)
            {
                Instantiate(asyncOp.Result,this.transform);
            }
        };
    }
}
#endif