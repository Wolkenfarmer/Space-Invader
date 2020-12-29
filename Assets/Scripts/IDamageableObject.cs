using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

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
