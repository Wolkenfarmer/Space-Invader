using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndlessButton : MonoBehaviour
{
	void Start()
	{
		var button = gameObject.GetComponent<Button>();

		button.onClick.AddListener(new UnityEngine.Events.UnityAction(onClicked));
	}

	void onClicked()
	{
		GameState.IsEndless = true;
		SceneManager.LoadScene("game");
	}
}
