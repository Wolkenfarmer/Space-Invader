using UnityEngine;

public class Blockade : MonoBehaviour
{
	public GameObject Player;
	SpriteRenderer blockadeRenderer;

	Vector2 linePoint;
	Vector2 lineDirection;

	void Start()
	{
		blockadeRenderer = gameObject.GetComponent<SpriteRenderer>();

		linePoint = gameObject.transform.position;
		lineDirection = Vector2.right;
	}

	void Update()
	{
		var playerPos = Player.transform.position;
		var distance = (NearestPointOnLine(playerPos) - playerPos).magnitude - 1.14f;

		var color = blockadeRenderer.color;
		if (distance < 5)
			color.a = 1 - distance / 5;
		else
			color.a = 0;

		blockadeRenderer.color = color;
	}

	// https://forum.unity.com/threads/how-do-i-find-the-closest-point-on-a-line.340058/
	Vector3 NearestPointOnLine(Vector2 point)
	{
		var v = point - linePoint;
		var d = Vector2.Dot(v, lineDirection);

		return linePoint + lineDirection * d;
	}
}
