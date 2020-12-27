using UnityEngine;

public class DefaultEnemyBehaviorScript : SpaceShipBehaviorScript
{
	public GameObject StartBulletPrefab;

	public int StartHealth = 100;
	public int StartShield = 0;

	public float StartSpeed = 0.02f;

	public int StartReload = 240;

	bool moveRight;

	void Start()
	{
		BulletPrefab = StartBulletPrefab;

		Health = StartHealth;
		Shield = StartShield;

		Speed = StartSpeed;
		Reload = StartReload;

		Team = SpaceShipBehaviorScript.EnemyTeam;
	}

	protected override void Update()
	{
		base.Update();

		// Dummy movement
		if (transform.position.x > 8f)
			moveRight = false;
		else if (transform.position.x < -8f)
			moveRight = true;

		var movement = 1f;
		if (!moveRight)
			movement = -1f;

		Move(movement, -0.01f);

		// Always try to shoot
		Fire();
	}
}
