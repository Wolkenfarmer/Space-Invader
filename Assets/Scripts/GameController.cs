using UnityEngine;

public class GameController : MonoBehaviour
{
	[System.NonSerialized]
	public UIController UIController;

	// This can be overriden if needed.
	[System.NonSerialized]
	public int Level = 1;

	WaveController waveController;

	void Start()
	{
		UIController = GameObject.Find("UIController").GetComponent<UIController>();

		waveController = GameObject.Find("WaveController").GetComponent<WaveController>();

		StartGame();
	}

	public void StartGame()
	{
		UIController.SetLevel(Level);
		waveController.Init(Level);
	}

	public void PlayerDead()
	{
		Debug.Log($"DeadDeadDeadDeadDeadDeadDeadDeadDeadDeadDeadDeadDeadDeadDeadDeadDeadDeadDeadDead!");
	}
}
