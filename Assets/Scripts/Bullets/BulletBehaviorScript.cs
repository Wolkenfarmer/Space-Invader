using UnityEngine;

public class BulletBehaviorScript : MonoBehaviour, Assets.Scripts.IDamageableObject
{
	// if fired by player, move into the other direction!
	[System.NonSerialized]
	public bool FiredByPlayer;
	[System.NonSerialized]
	public int Team;

	public float Speed;

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

	void Update()
	{
		// Check if dead and update of damage (bullet health = its damage)
		if (pHealth <= 0)
			Destroy(gameObject);
		else
			setDamage(pHealth);

		// Movement
		var position = transform.position;
		var speed = -Speed;

		if (FiredByPlayer)
			speed = Speed;

		position.y += speed;

		transform.position = position;
	}

	public void OnCollisionEnter2D(Collision2D collision)
	{
		// The other collision object is a bullet
		var bBullet = collision.gameObject.TryGetComponent<BulletBehaviorScript>(out var bullet);
		if (bBullet && bullet.Team != Team)
        {
			InflictDamage(bullet);
		}

		// The other collision object is a space ship
		var bSpaceShip = collision.gameObject.TryGetComponent<SpaceShipBehaviorScript>(out var spaceShip);
		if (bSpaceShip && spaceShip.Team != Team)
		{
			InflictDamage(spaceShip);
		}
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

	public void setShield(int newShield) { pShield = newShield; }
	public void setHealth(int newHealth) { pHealth = newHealth; }
	public void setDamage(int newDamage) { pDamage = newDamage; }
}
