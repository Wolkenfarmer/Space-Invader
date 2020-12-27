using UnityEngine;

public class PlayerBehaviorScript : SpaceShipBehaviorScript
{
	public GameObject StartBulletPrefab;

	public int StartHealth = 200;
	public int StartShield = 100;

	public float StartSpeed = 0.1f;

	public int StartReload = 120;

	void Start()
	{
		BulletPrefab = StartBulletPrefab;

		Health = StartHealth;
		Shield = StartShield;

		Speed = StartSpeed;
		Reload = StartReload;
	}

	protected override void Update()
	{
		base.Update();

		// Basic key input
		var h = Input.GetAxis("Horizontal");
		var v = Input.GetAxis("Vertical");

		Move(h, v);

		if (Input.GetKey(KeyCode.Space))
			Fire(true);
	}
}
