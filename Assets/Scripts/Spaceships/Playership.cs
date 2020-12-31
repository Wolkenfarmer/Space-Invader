using UnityEngine;

public class Playership : Spaceship
{
	public bool Up;
	public bool Down;
	public bool Left;
	public bool Right;

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
			Kill();

		// Basic key input
		var h = Input.GetAxis("Horizontal");
		var v = Input.GetAxis("Vertical");
		Move(h, v);
		if (Input.GetKey(KeyCode.Space))
			Fire(true);

		// Button Input
		if (Up)
			Move(0, 1);
		if (Down)
			Move(0, -1);
		if (Left)
			Move(-1, 0);
		if (Right)
			Move(1, 0);
	}

	protected override void Kill()
	{
		Destroy(gameObject);
		GameController.Defeat();
	}
}
