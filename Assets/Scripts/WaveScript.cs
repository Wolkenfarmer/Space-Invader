using System.Collections.Generic;
using UnityEngine;

public class WaveScript : MonoBehaviour
{
	public GameObject EnemyPrefab;

	readonly List<Assets.Scripts.Unit> units = new List<Assets.Scripts.Unit>();
	List<GameObject> enemies;

	int currentWave;

	void Update()
	{
		foreach (var unit in units)
			unit.Update();
	}

	// NewWave. The type of wave and exact content of it can be specified here. Grouping in units is recommended.
	public void NewWave()
	{
		Debug.Log($"New Wave!");
		currentWave++;
		var half = (currentWave / 2) * -1;

		for (int i = 0; i < (currentWave / 2) + 1; i++)
		{
			Debug.Log($"New Unit");
			Assets.Scripts.Unit unit;
			enemies	= new List<GameObject>();

			for (int k = 0; k < currentWave; k++)
			{
				var obj = Instantiate(EnemyPrefab);
				obj.transform.position = new Vector2(half + k * 2, 17f + (i * 2));
				enemies.Add(obj);
			}

			unit = new Assets.Scripts.Unit(this, enemies, true);
			enemies = null;
			units.Add(unit);
		}
	}

	// Gets called if a unit of the current wave got killed. If all units are dead, NewWave wll be called
	public void UnitDown(Assets.Scripts.Unit deadUnit)
	{
		units.Remove(deadUnit);

		if (units.Count < 1)
			NewWave();
	}
}
