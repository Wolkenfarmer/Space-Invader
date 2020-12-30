using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
	public class DefaultEnemyUnitScript
	{
		WaveScript parent;
		List<GameObject> objects = new List<GameObject>();
		GameObject group;
		float leftBound;
		float rightBound;
		float speed;
		private bool moveRight;

		public DefaultEnemyUnitScript(WaveScript parent, List<GameObject> objects, float speed, bool firstRight)
		{
			this.parent = parent;
			this.objects = objects;
			this.speed = speed;
			moveRight = false;

			this.objects.Sort(CompareByPosition_xMin);

			group = new GameObject("EnemyUnit");

			foreach (var obj in this.objects)
			{
				obj.transform.parent = group.transform;
				obj.GetComponent<DefaultEnemyBehaviorScript>().SetPartOfUnit(this);
			}

			leftBound = this.objects[0].transform.position.x;
			rightBound = this.objects[this.objects.Count - 1].transform.position.x;
		}

		public void Update()
		{
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

			group.transform.position += new Vector3(movement * speed, speed * -0.1f);
			rightBound += movement * speed;
			leftBound += movement * speed;
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
				parent.unitDown();
			}
		}
	}
}