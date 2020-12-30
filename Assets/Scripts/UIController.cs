using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject LevelText;
	TextMesh levelTextMesh;

    public GameObject WavesText;
	TextMesh wavesTextMesh;

	void Start()
	{
		findComponents();
	}

	public void SetLevel(int level)
	{
		if (levelTextMesh == null)
			findComponents();

		levelTextMesh.text = $"Level {level}";
	}

    public void SetWave(int current, int max)
	{
		if (wavesTextMesh == null)
			findComponents();

		wavesTextMesh.text = $"Wave {current}/{max}";
	}

	// Workaround: for some reason, the components are not initialized sometimes
	void findComponents()
	{
		levelTextMesh = LevelText.GetComponent<TextMesh>();
		wavesTextMesh = WavesText.GetComponent<TextMesh>();
	}
}
