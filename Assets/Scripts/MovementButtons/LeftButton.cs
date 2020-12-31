using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LeftButton : Button
{
	Playership player;

	protected override void Start()
	{
		base.Start();
		player = GameObject.Find("Player").GetComponent<Playership>();
	}

	public override void OnPointerDown(PointerEventData eventData)
	{
		base.OnPointerDown(eventData);
		player.Left = true;
	}

	public override void OnPointerUp(PointerEventData eventData)
	{
		base.OnPointerUp(eventData);
		player.Left = false;
	}
}