using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneSpawner : MonoBehaviour {

	[SerializeField]
	private Vector3[] _potentialLocations;
	[SerializeField]
	private GameObject player;
	[SerializeField]
	private PrefabProvider PrefabProvider;

	// Preferable this should be out of view of camera
	[SerializeField]
	private float verticalSpawnPosition;
	// Use this for initialization
	void Start () {
		PrefabProvider = ObjectProvider.ProvidePrefabProvider();
		player = ObjectProvider.ProvidePlayer();
		_potentialLocations = LocationProvider.ProvideLocations(player.transform).ToArray();
		SpawnLane();
	}
	
	public void SpawnLane()
	{
		var obstacles = new List<GameObject>();
		foreach(var location in _potentialLocations)
		{
			var newObstacle = Instantiate(PrefabProvider.Obstacle);
			newObstacle.transform.position = new Vector3(location.x, LocationProvider.ProvideVerticalOffset(), location.z);
			obstacles.Add(newObstacle);
		}
	}
}
