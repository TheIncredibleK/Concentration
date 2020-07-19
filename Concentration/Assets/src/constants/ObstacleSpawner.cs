using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {

	[SerializeField]
	private Vector3[] _potentialLocations;
	[SerializeField]
	private GameObject player;
	// Use this for initialization
	void Start () {
		player = ObjectProvider.ProvidePlayer();
		_potentialLocations = LocationProvider.ProvideLocations(player.transform).ToArray();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
