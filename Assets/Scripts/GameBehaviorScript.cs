using UnityEngine;

public class GameBehaviorScript : MonoBehaviour
{
	void Start()
	{
		GameObject.Find("WaveController").GetComponent<WaveScript>().NewWave();
	}

	public void PlayerDead()
	{
		Debug.Log($"DeadDeadDeadDeadDeadDeadDeadDeadDeadDeadDeadDeadDeadDeadDeadDeadDeadDeadDeadDead!");
	}
}
