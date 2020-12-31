using UnityEngine;

public class BulletBehaviorScript : MonoBehaviour
{
	// if fired by player, move into the other direction!
	[System.NonSerialized]
	public bool FiredByPlayer;
	[System.NonSerialized]
	public int Team;

	public float Speed;
	public int Damage;

	void Update()
	{
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
		var bullet = collision.gameObject.GetComponent<BulletBehaviorScript>();
		if (bullet != null)
		{
			CancelDamage(bullet.Damage);
			bullet.CancelDamage(Damage);
			Debug.Log("bullets collided.");
		}
	}

	public void CancelDamage(int damage)
	{
		Damage -= damage;

		// Bullet canceled out
		if (Damage <= 0)
			Destroy(gameObject);
	}
}
