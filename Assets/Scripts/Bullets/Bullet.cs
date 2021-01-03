using UnityEngine;

public abstract class Bullet : MonoBehaviour, Assets.Scripts.IDamageableObject
{
	// if fired by player, move into the other direction!
	[System.NonSerialized]
	public bool FiredByPlayer;
	[System.NonSerialized]
	public int Team;

	public int Health { get; private set; }
	public int Shield { get; private set; }
	public int Damage { get; private set; }

	public float Speed { get; private set; }

	void Update()
	{
		// Check if dead and update of damage (bullet health = its damage)
		if (Health <= 0)
			Destroy(gameObject);
		else
			setDamage(Health);

		// Movement
		var position = transform.position;
		var speed = -Speed;

		if (FiredByPlayer)
			speed = Speed;

		position.y += speed * Time.deltaTime;

		transform.position = position;
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
		Debug.Log($"Collision! Bullet -> {otherObject} | Damage inflicted: {Damage}");

		otherObject.setShield(otherObject.Shield - Damage);

		// Shield has taken all the damage
		if (otherObject.Shield >= 0)
			return;

		// Substract left damage from health and set shield to 0.
		otherObject.setHealth(otherObject.Health + otherObject.Shield);
		otherObject.setShield(0);
	}

	public void setShield(int newShield) { Shield = newShield; }
	public void setHealth(int newHealth) { Health = newHealth; }
	public void setDamage(int newDamage) { Damage = newDamage; }

	public void setSpeed(float newSpeed) { Speed = newSpeed; }
}
