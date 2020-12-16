#if AK_WWISE_ADDRESSABLES && UNITY_ADDRESSABLES

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

public class AddressableSceneLoader : MonoBehaviour
{

    public AssetReference scene;
    private AsyncOperationHandle<SceneInstance> sceneHandle;

    public void Awake()
    {
        var parentObject = transform.root;
        DontDestroyOnLoad(parentObject);
    }

    public void LoadScene()
    {
        if (!sceneHandle.IsValid() )
        {
            scene.LoadSceneAsync( LoadSceneMode.Additive).Completed += SceneLoadComplete;
        }
        else
        {
            UnloadScene();
        }
    }

    public void UnloadScene()
    {
        Addressables.UnloadSceneAsync(sceneHandle).Completed += op =>
        {
            if (op.Status == AsyncOperationStatus.Succeeded)
            {
                Debug.Log("Successfully unloaded scene");
            }
        };
    }

    private void SceneLoadComplete(AsyncOperationHandle<SceneInstance> obj)
    {
        sceneHandle = obj;
        if (obj.Status == AsyncOperationStatus.Succeeded)
        {
            Debug.Log(obj.Result.Scene.name + " successfully loaded");
        }
    }
}
#endif