using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ResumeButton : Button
{
	PauseController controller;

	protected override void Start()
	{
		base.Start();

		controller = GameObject.Find("PauseController").GetComponent<PauseController>();
	}

	public override void OnPointerUp(PointerEventData eventData)
	{
		base.OnPointerClick(eventData);

		controller.Pause(false);
	}
}
