using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.LevelGeneration
{
	public class LevelGenerator : MonoBehaviour
	{
		[SerializeField]
		private Transform startPlatform;
		[SerializeField]
		private GameObject[] prefabs;
		[SerializeField]
		private float maxRadius;
		[SerializeField]
		private float maxX;

		private const int _queueStartCount = 3;
		private float _previousX;
		private float _previousY;

		private Queue<GameObject> instantiatedObjects;

		private void Start()
		{
			LevelObject.MaxRadius = maxRadius;
			LevelObject.MaxX = maxX;

			instantiatedObjects = new Queue<GameObject>();
			instantiatedObjects.Enqueue(new GameObject("Dummy"));

			InitializeLevel();
		}

		private void InstantiateObject()
		{
			var newLevelObject = new LevelObject(_previousX, _previousY);

			var instantiatedObject = Instantiate(
				RandomizePrefab(),
				new Vector3(newLevelObject.PositionX, startPlatform.position.y, newLevelObject.PositionY),
				Quaternion.identity
				);

			instantiatedObject.GetComponent<Platform>().PlatformTouched.AddListener(OnPlatformTouched);
			instantiatedObjects.Enqueue(instantiatedObject);

			_previousX = newLevelObject.PositionX;
			_previousY = newLevelObject.PositionY;
		}

		private void InitializeLevel()
		{
			_previousX = startPlatform.position.x;
			_previousY = startPlatform.position.z;

			for (int i = 0; i < _queueStartCount; ++i)
			{
				InstantiateObject();
			}
		}

		private void OnPlatformTouched(GameObject gameObject)
		{
			InstantiateObject();

			var firstObject = instantiatedObjects.Dequeue();

			if (firstObject)
			firstObject.GetComponent<Platform>()?.PlatformTouched.RemoveAllListeners();
			Destroy(firstObject);

			gameObject.GetComponent<Platform>().PlatformTouched.RemoveListener(OnPlatformTouched);
		}

		private GameObject RandomizePrefab()
		{
			return prefabs[Random.Range(0, prefabs.Length)];
		}
	}
}