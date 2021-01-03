using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartButton : Button
{
	public override void OnPointerClick(PointerEventData eventData)
	{
		base.OnPointerClick(eventData);

		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
