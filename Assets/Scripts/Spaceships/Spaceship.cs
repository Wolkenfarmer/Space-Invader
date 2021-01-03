using UnityEngine;

public abstract class Spaceship : MonoBehaviour, Assets.Scripts.IDamageableObject
{
	public const int PlayerTeam = 1;
	public const int EnemyTeam = 2;

	public GameObject BulletPrefab;

	[System.NonSerialized]
	public int Team;

	public int Health { get; private set; }
	public int Shield { get; private set; }
	public int Damage { get; private set; }

	public float Speed { get; private set; }

	public int Reload;
	int currentReload;

	protected virtual void Update()
	{
		currentReload--;
	}

	public void Move(float h, float v)
	{
		gameObject.transform.position += new Vector3(h * Speed * Time.deltaTime, v * Speed * Time.deltaTime);
	}

	public void Fire(bool isPlayer = false)
	{
		// Check whether game is paused
		if (PauseController.Paused)
			return;

		// Weapon is not reloaded
		if (currentReload > 0)
			return;

		// Reset weapon reload
		currentReload = Reload;

		// Create bullet and set position
		var obj = Instantiate(BulletPrefab);
		obj.transform.position = gameObject.transform.position;

		// Set parameters in script
		var bullet = obj.GetComponent<Bullet>();
		bullet.FiredByPlayer = isPlayer;
		bullet.Team = Team;

		// Ignore physics collision between spaceship and bullet
		Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), obj.GetComponent<Collider2D>());
	}

	public void OnCollisionEnter2D(Collision2D collision)
	{
		// The other collision object is a bullet
		var bBullet = collision.gameObject.TryGetComponent<Bullet>(out var bullet);
		if (bBullet && bullet.Team != Team)
			InflictDamage(bullet);

		// The other collision object is a space ship
		var bSpaceShip = collision.gameObject.TryGetComponent<Spaceship>(out var spaceShip);
		if (bSpaceShip && spaceShip.Team != Team)
			InflictDamage(spaceShip);
	}

	public void InflictDamage(Assets.Scripts.IDamageableObject otherObject)
	{
		Debug.Log($"Collision! SpaceShip -> {otherObject} | Damage inflicted: {Damage}");

		otherObject.setShield(otherObject.Shield - Damage);

		// Shield has taken all the damage
		if (otherObject.Shield >= 0)
			return;

		// Substract left damage from health and set shield to 0.
		otherObject.setHealth(otherObject.Health + otherObject.Shield);
		otherObject.setShield(0);
	}

	// Method that can be overriden by PlayerBehavior to end game
	protected virtual void Kill()
	{
		Debug.Log("Spaceship killed.");
		Destroy(gameObject);
	}

	public void setShield(int newShield) { Shield = newShield; }
	public void setHealth(int newHealth) { Health = newHealth; }
	public void setDamage(int newDamage) { Damage = newDamage; }

	public void setSpeed(float newSpeed) { Speed = newSpeed; }
}
