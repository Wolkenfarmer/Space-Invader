using UnityEngine;

public class DefaultEnemyBehaviorScript : SpaceShipBehaviorScript
{
	Assets.Scripts.DefaultEnemyUnitScript parent;
	bool moveRight;
	bool partOfUnit;

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
			parent.ObjectDown(gameObject);
			Kill();
        }

		
		if (!partOfUnit)
			move();

		// Always try to shoot
		Fire();
	}

	// Dummy movement
	void move()
	{
		if (transform.position.x > 8f)
			moveRight = false;
		else if (transform.position.x < -8f)
			moveRight = true;

		var movement = 1f;
		if (!moveRight)
			movement = -1f;

		Move(movement, -Speed * 0.5f);
	}

	public void SetPartOfUnit(Assets.Scripts.DefaultEnemyUnitScript parent)
	{
		this.parent = parent;
		partOfUnit = true;
	}
}
