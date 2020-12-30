using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject LevelText;
	TextMesh levelTextMesh;

    public GameObject WavesText;
	TextMesh wavesTextMesh;

	void Start()
	{
		levelTextMesh = LevelText.GetComponent<TextMesh>();
		wavesTextMesh = WavesText.GetComponent<TextMesh>();
	}

	public void SetLevel(int level)
	{
		levelTextMesh.text = $"Level {level}";
	}

    public void SetWave(int current, int max)
	{
		wavesTextMesh.text = $"Wave {current}/{max}";
	}
}
