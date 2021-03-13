using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
	public class WaveUnit
	{
		WaveController parent;
		List<GameObject> objects;
		GameObject group;
		float leftBound;
		float rightBound;
		float speed = float.MaxValue;
		bool firstTick = true;
		private bool moveRight;

		public WaveUnit(WaveController parent, List<GameObject> objects, bool firstRight)
		{
			this.parent = parent;
			this.objects = objects;
			moveRight = firstRight;

			this.objects.Sort(CompareByPosition_xMin);

			group = new GameObject("EnemyUnit");

			leftBound = this.objects[0].transform.position.x;
			rightBound = this.objects[this.objects.Count - 1].transform.position.x;
		}

		public void Update()
		{
			// Objects have to be initialized first so we can get their speed
			if (firstTick)
			{
				foreach (var obj in objects)
				{
					obj.transform.parent = group.transform;
					var enemyScript = obj.GetComponent<Enemyship>();
					enemyScript.SetPartOfUnit(this);

					if (enemyScript.Speed < speed)
						speed = enemyScript.Speed;
				}
				firstTick = false;
			}

			move();
		}

		int CompareByPosition_xMin(GameObject objA, GameObject objB)
		{
			float fA = objA.GetComponent<Transform>().position.x;
			float fB = objB.GetComponent<Transform>().position.x;

			if (fA < fB)
				return -1;
			else if (fA > fB)
				return 1;
			else
				return 0;
		}

		void move()
		{
			if (rightBound > 8f)
				moveRight = false;
			else if (leftBound < -8f)
				moveRight = true;

			var movement = 1f;
			if (!moveRight)
				movement = -1f;

			group.transform.position += new Vector3(movement * speed * Time.deltaTime, speed * -0.1f * Time.deltaTime);
			rightBound += movement * speed * Time.deltaTime;
			leftBound += movement * speed * Time.deltaTime;
		}

		public void ObjectDown(GameObject objDown)
		{
			objects.Remove(objDown);
			if (objects.Count > 0)
			{
				objects.Sort(CompareByPosition_xMin);

				leftBound = objects[0].transform.position.x;
				rightBound = objects[objects.Count - 1].transform.position.x;
			}
			else
			{
				parent.UnitDown(this);
				Debug.Log($"Unit down! {this}");
			}
		}
	}
}