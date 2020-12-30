using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StoryButton : MonoBehaviour
{
	void Start()
	{
		var button = gameObject.GetComponent<Button>();

		button.onClick.AddListener(new UnityEngine.Events.UnityAction(onClicked));
	}

	void onClicked()
	{
		// TODO: enable boolean in settings.cs file that comes with PR #13
		SceneManager.LoadScene("game");
	}
}
