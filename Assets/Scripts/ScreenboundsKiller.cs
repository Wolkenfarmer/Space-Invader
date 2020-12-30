using UnityEngine;

public class ScreenboundsKiller : MonoBehaviour
{
	Vector2 screenBounds;
	Vector2 spriteBounds;

	void Start()
	{
		screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));

		var sprite = transform.GetComponent<SpriteRenderer>().bounds;
		spriteBounds = new Vector2(sprite.size.x, sprite.size.y);
	}

	void Update()
	{
		var position = transform.position;

		if (position.x < -screenBounds.x - spriteBounds.x / 2 || position.x > screenBounds.x + spriteBounds.x / 2)
			Destroy();

		if (position.y < -screenBounds.y - spriteBounds.y / 2 || position.y > screenBounds.y + spriteBounds.y / 2)
			Destroy();
	}

	void Destroy()
	{
		Destroy(gameObject);
	}
}
