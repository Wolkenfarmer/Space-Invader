using UnityEngine;

public class ScreenClamper : MonoBehaviour
{
	public bool IsPlayer;

	Vector2 screenBounds;
	Vector2 spriteBounds;

	void Start()
	{
		screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));

		var sprite = transform.GetComponent<SpriteRenderer>().bounds;
		spriteBounds = new Vector2(sprite.size.x, sprite.size.y);
	}

	void LateUpdate()
	{
		var position = transform.position;

		position.x = Mathf.Clamp(position.x, -screenBounds.x + spriteBounds.x / 2, screenBounds.x - spriteBounds.x / 2);
		if (IsPlayer)
			position.y = Mathf.Clamp(position.y, -screenBounds.y + spriteBounds.y / 2, -spriteBounds.y / 2);
		else if (position.y < -screenBounds.y - spriteBounds.y / 2)
			leftScreen();

		transform.position = position;
	}

	void leftScreen()
	{
		Debug.Log($"{gameObject} left the game area.");
		Destroy(gameObject);
	}
}
