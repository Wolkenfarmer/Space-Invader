using UnityEngine;
using UnityEngine.UI;

public class SettingsButton : MonoBehaviour
{
	void Start()
	{
		var button = gameObject.GetComponent<Button>();

		button.onClick.AddListener(new UnityEngine.Events.UnityAction(onClicked));
	}

	void onClicked()
	{
		// TODO implement
	}
}
