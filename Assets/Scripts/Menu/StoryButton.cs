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
		GameState.IsEndless = false;
		SceneManager.LoadScene("game");
	}
}
