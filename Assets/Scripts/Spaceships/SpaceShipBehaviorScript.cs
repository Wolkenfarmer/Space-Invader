using UnityEngine;

public class SpaceShipBehaviorScript : MonoBehaviour
{
	public const int PlayerTeam = 1;
	public const int EnemyTeam = 2;

	public GameObject BulletPrefab;

	[System.NonSerialized]
	public int Team;

	public int Health;
	public int Shield;

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
		var bullet = obj.GetComponent<BulletBehaviorScript>();
		bullet.FiredByPlayer = isPlayer;
		bullet.Team = Team;

		// Ignore physics collision between spaceship and bullet
		Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), obj.GetComponent<Collider2D>());
	}

	public void OnCollisionEnter2D(Collision2D collision)
	{
		// The other collision object is a bullet
		var bullet = collision.gameObject.GetComponent<BulletBehaviorScript>();
		if (bullet != null && bullet.Team != Team)
		{
			InflictDamage(bullet.Damage);

			Destroy(bullet.gameObject);
		}
	}

	void InflictDamage(int damage)
	{
		Debug.Log($"Collision! Damage inflicted: {damage}");

		Shield -= damage;

		// Shield has taken all the damage
		if (Shield >= 0)
			return;

		// Substract left damage from health and set shield to 0.
		Health += Shield;
		Shield = 0;

		if (Health <= 0)
			Kill();
	}

	// Method that can be overriden by PlayerBehavior to end game
	protected virtual void Kill()
	{
		Debug.Log("Spaceship killed.");
		Destroy(gameObject);
	}
}
