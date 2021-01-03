using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButton : Button
{
	public override void OnPointerClick(PointerEventData eventData)
	{
		base.OnPointerClick(eventData);

		SceneManager.LoadScene("menu");
	}
}
