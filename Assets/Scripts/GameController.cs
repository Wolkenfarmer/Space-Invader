using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	[System.NonSerialized]
	public UIController UIController;

	WaveController waveController;

	PauseController pauseController;

	void Start()
	{
		UIController = GameObject.Find("UIController").GetComponent<UIController>();
		waveController = GameObject.Find("WaveController").GetComponent<WaveController>();

		pauseController = GameObject.Find("PauseController").GetComponent<PauseController>();

		StartGame();
	}

	public void StartGame()
	{
		UIController.SetLevel(GameState.Level);
		waveController.Init(GameState.Level);
	}

	void Update()
	{
		if (Input.GetKey(KeyCode.Escape))
			pauseController.Pause(true);
	}

	public static void Victory()
	{
		Debug.Log("Happy noises");

		GameState.Level++;

		loadGameScene();
	}

	public static void Defeat()
	{
		Debug.Log("Sad noises");

		// For now, just restart the game
		loadGameScene();
	}

	static void loadGameScene()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
