public class Enemyship : Spaceship
{
	Assets.Scripts.WaveUnit parent;
	bool moveRight;
	bool partOfUnit;

	void Start()
	{
		Team = EnemyTeam;

		setHealth(200);
		setDamage(50);
		setSpeed(10);
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

		Move(movement, -0.5f);
	}

	public void SetPartOfUnit(Assets.Scripts.WaveUnit parent)
	{
		this.parent = parent;
		partOfUnit = true;
	}
}
