public class LaserBulletBehaviorScript : BulletBehaviorScript
{
	public float StartSpeed = 0.1f;

	public int StartDamage = 1;

	void Start()
	{
		Speed = StartSpeed;
		Damage = StartDamage;
	}
}
