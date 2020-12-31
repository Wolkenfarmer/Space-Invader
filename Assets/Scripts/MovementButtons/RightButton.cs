using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class RightButton : Button
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
		player.Right = true;
	}

	public override void OnPointerUp(PointerEventData eventData)
	{
		base.OnPointerUp(eventData);
		player.Right = false;
	}
}