using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveScript : MonoBehaviour
{
	public GameObject EnemyPrefab;

	readonly List<GameObject> enemies = new List<GameObject>();
	int currentWave;
	Assets.Scripts.DefaultEnemyUnitScript unit;

	void Start()
    {
		NewWave();
	}

    void Update()
    {
		unit.Update();
	}

	void NewWave()
	{
		currentWave++;

		enemies.Clear();

		var half = (currentWave / 2) * -1;
		for (int i = 0; i < currentWave; i++)
		{
			var obj = Instantiate(EnemyPrefab);
			obj.transform.position = new Vector2(half + i * 2, 7f);
			enemies.Add(obj);
		}

		unit = new Assets.Scripts.DefaultEnemyUnitScript(this, enemies, enemies[0].GetComponent<SpaceShipBehaviorScript>().Speed, true);
	}

	public void unitDown()
    {
		NewWave();
    }
}
