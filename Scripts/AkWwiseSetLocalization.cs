﻿/*******************************************************************************
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
Copyright (c) 2024 Audiokinetic Inc.
*******************************************************************************/

#if AK_WWISE_ADDRESSABLES && UNITY_ADDRESSABLES
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wwise.API.Runtime.WwiseTypes.WwiseObjectsManagers;

public class AkWwiseSetLocalization : MonoBehaviour
{
	public string LanguageString;

	public void SetLanguage()
	{
#if !UNITY_SERVER
		Debug.Log($"Setting language to {LanguageString}");
#if WWISE_ADDRESSABLES_24_1_OR_LATER
		WwiseEventReferencesManager.Instance.SetLanguageAndReloadLocalizedBanks(LanguageString);
#else
		AK.Wwise.Unity.WwiseAddressables.AkAddressableBankManager.Instance.SetLanguageAndReloadLocalizedBanks(LanguageString);
#endif
#endif
	}
}
#endif
