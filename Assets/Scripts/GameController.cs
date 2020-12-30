using UnityEngine;

public class GameController : MonoBehaviour
{
	void Start()
	{
		GameObject.Find("WaveController").GetComponent<WaveController>().NewWave();
	}

	public void PlayerDead()
	{
		Debug.Log($"DeadDeadDeadDeadDeadDeadDeadDeadDeadDeadDeadDeadDeadDeadDeadDeadDeadDeadDeadDead!");
	}
}
