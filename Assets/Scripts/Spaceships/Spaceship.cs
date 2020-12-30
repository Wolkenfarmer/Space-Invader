using UnityEngine;

public class Spaceship : MonoBehaviour, Assets.Scripts.IDamageableObject
{
	public const int PlayerTeam = 1;
	public const int EnemyTeam = 2;

	public GameObject BulletPrefab;

	[System.NonSerialized]
	public int Team;

	int pHealth;
	int pShield;
	int pDamage;

	public int Health
	{
		get { return pHealth; }
	}
	public int Shield
	{
		get { return pShield; }
	}
	public int Damage
	{
		get { return pDamage; }
	}

	public float Speed;

	public int Reload;
	int currentReload;

	protected virtual void Update()
	{
		currentReload--;
	}

	public void Move(float h, float v)
	{
		gameObject.transform.position += new Vector3(h * Speed, v * Speed);
	}

	public void Fire(bool isPlayer = false)
	{
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

	public void setShield(int newShield) { pShield = newShield; }
	public void setHealth(int newHealth) { pHealth = newHealth; }
	public void setDamage(int newDamage) { pDamage = newDamage; }
}
