using UnityEngine;

public class ScreenClampBehaviorScript : MonoBehaviour
{
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
		position.y = Mathf.Clamp(position.y, -screenBounds.y + spriteBounds.y / 2, screenBounds.y - spriteBounds.y / 2);

		transform.position = position;
	}
}
