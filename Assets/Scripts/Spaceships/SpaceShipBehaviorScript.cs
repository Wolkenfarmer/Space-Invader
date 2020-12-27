using UnityEngine;

public class SpaceShipBehaviorScript : MonoBehaviour
{
	protected GameObject BulletPrefab;

	protected int Health;
	protected int Shield;

	protected float Speed;

	protected int Reload;
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

		// Set boolean in script
		obj.GetComponent<BulletBehaviorScript>().FiredByPlayer = isPlayer;

		// Ignore physics collision between spaceship and bullet
		Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), obj.GetComponent<Collider2D>());
	}
}
