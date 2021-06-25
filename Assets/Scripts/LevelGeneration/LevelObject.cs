using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.LevelGeneration
{
	class LevelObject
	{
		public static float MaxRadius { private get; set; }
		public static float MaxX { private get; set; }
		public GameObject Prefab { get; set; }

		public float PositionX { get; private set; }
		public float PositionY { get; private set; }

		public LevelObject(float previousX, float previousY)
		{
			(PositionX, PositionY) = ChoosePosition(previousX, previousY);
		}

		private (float, float) ChoosePosition(float previousX, float previousY)
		{
			var randomPoint = GetRandomCirclePoint(MaxRadius);

			while (Math.Abs(randomPoint.x + previousX) >= MaxX || randomPoint.y < 0)
			{
				randomPoint = GetRandomCirclePoint(MaxRadius);
			}

			return (randomPoint.x + previousX, randomPoint.y + previousY);
		}

		private Vector2 GetRandomCirclePoint(float radius)
		{
			return Random.insideUnitCircle * radius;
		}
	}
}
