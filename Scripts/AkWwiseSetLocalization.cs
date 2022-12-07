#if AK_WWISE_ADDRESSABLES && UNITY_ADDRESSABLES
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AkWwiseSetLocalization : MonoBehaviour
{
	public string LanguageString;

	public void SetLanguage()
	{
#if !UNITY_SERVER
		Debug.Log($"Setting language to {LanguageString}");
		AK.Wwise.Unity.WwiseAddressables.AkAddressableBankManager.Instance.SetLanguageAndReloadLocalizedBanks(LanguageString);
#endif
	}
}
#endif
