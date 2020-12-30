using System.Collections.Generic;
using UnityEngine;

public class GameBehaviorScript : MonoBehaviour
{
	public GameObject EnemyPrefab;

	readonly List<GameObject> enemies = new List<GameObject>();
	int currentWave;

	void Start()
	{
		NewWave();
	}

	void Update()
	{
		var allAlive = false;
		foreach (var enemy in enemies)
		{
			if (enemy != null)
			{
				allAlive = true;
				break;
			}
		}

		if (!allAlive)
			NewWave();
	}

	void NewWave()
	{
		currentWave++;

		enemies.Clear();

		var half = (currentWave / 2) * -1;
		for (int i = 0; i < currentWave; i++)
		{
			var obj = Instantiate(EnemyPrefab);
			obj.transform.position = new Vector2(half + i * 2, 17f);
			enemies.Add(obj);
		}
	}
}
