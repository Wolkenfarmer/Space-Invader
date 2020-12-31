using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class MenuController : MonoBehaviour
{
	List<GameObject> buttonLabels;
	public GameObject StoryLabel;
	public GameObject EndlessLabel;
	public GameObject SettingsLabel;
	public GameObject ExitLabel;

	void Start()
	{
		buttonLabels = new List<GameObject>
		{
			StoryLabel,
			EndlessLabel,
			SettingsLabel,
			ExitLabel
		};

		equalButtonLabelFontSize();
	}

	void equalButtonLabelFontSize()
	{
		List<float> fontSizes = new List<float>();
		foreach (GameObject label in buttonLabels)
		{
			float fontSize = label.GetComponent<TextMeshProUGUI>().fontSize;
			fontSizes.Add(fontSize);
		}
		float smallestFontSize = fontSizes.Min();

		foreach (GameObject label in buttonLabels)
		{
			label.GetComponent<TextMeshProUGUI>().autoSizeTextContainer = false;
			label.GetComponent<TextMeshProUGUI>().fontSizeMax = (int)Mathf.Floor(smallestFontSize);
		}

		Debug.Log($"Set all button label to one maximum font size: {smallestFontSize}");
	}
}
