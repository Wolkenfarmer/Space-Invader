using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{
	void Start()
	{
		var button = gameObject.GetComponent<Button>();

		button.onClick.AddListener(new UnityEngine.Events.UnityAction(onClicked));
	}

	void onClicked()
	{
		Debug.Log("Exit");
		Application.Quit();
	}
}
