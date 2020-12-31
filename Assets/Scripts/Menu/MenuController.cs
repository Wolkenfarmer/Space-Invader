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
		var smallestFontSize = float.MaxValue;
		foreach (GameObject label in buttonLabels)
		{
			var fontSize = label.GetComponent<TextMeshProUGUI>().fontSize;
			if (fontSize < smallestFontSize)
				smallestFontSize = fontSize;
		}

		foreach (GameObject label in buttonLabels)
		{
			var mesh = label.GetComponent<TextMeshProUGUI>();
			mesh.autoSizeTextContainer = false;
			mesh.fontSizeMax = (int)Mathf.Floor(smallestFontSize);
		}

		Debug.Log($"Set all button label to one maximum font size: {smallestFontSize}");
	}
}
