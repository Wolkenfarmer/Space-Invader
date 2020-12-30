using UnityEngine;

public class PlayerBehaviorScript : SpaceShipBehaviorScript
{
	void Start()
	{
		Team = PlayerTeam;
		setHealth(2000);
		setDamage(150);
	}

	protected override void Update()
	{
		base.Update();

		// Check if dead
		if (Health <= 0)
		{
			Kill();
		}

		// Basic key input
		var h = Input.GetAxis("Horizontal");
		var v = Input.GetAxis("Vertical");

		Move(h, v);

		if (Input.GetKey(KeyCode.Space))
			Fire(true);
	}

	protected override void Kill()
	{
		Debug.Log("Sad noises");
		Destroy(gameObject);
		GameObject.Find("GameController").GetComponent<GameBehaviorScript>().PlayerDead();
	}
}
