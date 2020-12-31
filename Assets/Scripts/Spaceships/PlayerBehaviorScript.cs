using UnityEngine;

public class PlayerBehaviorScript : SpaceShipBehaviorScript
{
	void Start()
	{
		Team = PlayerTeam;
	}

	protected override void Update()
	{
		base.Update();

		// Basic key input
		var h = Input.GetAxis("Horizontal");
		var v = Input.GetAxis("Vertical");

		Move(h, v);

		if (Input.GetKey(KeyCode.Space))
			Fire(true);
	}
}
