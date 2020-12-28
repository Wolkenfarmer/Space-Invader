using UnityEngine;

public class DefaultEnemyBehaviorScript : SpaceShipBehaviorScript
{
	bool moveRight;

	void Start()
	{
		Team = EnemyTeam;
		setHealth(200);
		setDamage(50);
	}

	protected override void Update()
	{
		base.Update();

		// Check if dead
		if (Health <= 0)
        {
			GameBehaviorScript.enemies.Remove(this.gameObject);
			Kill();
        }

		// Dummy movement
		if (transform.position.x > 8f)
			moveRight = false;
		else if (transform.position.x < -8f)
			moveRight = true;

		var movement = 1f;
		if (!moveRight)
			movement = -1f;

		Move(movement, -Speed * 0.5f);

		// Always try to shoot
		Fire();
	}
}
