namespace Assets.Scripts
{
	public interface IDamageableObject
	{
		int Health { get; }
		int Shield { get; }
		int Damage { get; }

		void InflictDamage(IDamageableObject otherObject);
		void setShield(int newShield);
		void setHealth(int newHealth);
		void setDamage(int newDamage);
	}
}
