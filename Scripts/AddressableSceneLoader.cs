/*******************************************************************************
The content of this file includes portions of the proprietary AUDIOKINETIC Wwise
Technology released in source code form as part of the game integration package.
The content of this file may not be used without valid licenses to the
AUDIOKINETIC Wwise Technology.
Note that the use of the game engine is subject to the Unity(R) Terms of
Service at https://unity3d.com/legal/terms-of-service
 
License Usage
 
Licensees holding valid licenses to the AUDIOKINETIC Wwise Technology may use
this file in accordance with the end user license agreement provided with the
software or, alternatively, in accordance with the terms contained
in a written agreement between you and Audiokinetic Inc.
Copyright (c) 2025 Audiokinetic Inc.
*******************************************************************************/

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