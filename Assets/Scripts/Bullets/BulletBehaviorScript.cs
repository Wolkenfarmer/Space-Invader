using UnityEngine;

public class BulletBehaviorScript : MonoBehaviour
{
	// if fired by player, move into the other direction!
	public bool FiredByPlayer;

	protected float Speed;

	protected int Damage;

	void Start()
	{
		
	}

	void Update()
	{
		var position = transform.position;
		var speed = -Speed;

		if (FiredByPlayer)
			speed = Speed;

		position.y += speed;

		transform.position = position;
	}
}
