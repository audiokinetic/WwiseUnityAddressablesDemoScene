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
