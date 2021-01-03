using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PauseButton : Button
{
	PauseController pauseController;

	void Start()
	{
		pauseController = GameObject.Find("PauseController").GetComponent<PauseController>();
	}

	public override void OnPointerClick(PointerEventData eventData)
	{
		base.OnPointerClick(eventData);

		pauseController.Pause(true);
	}
}
