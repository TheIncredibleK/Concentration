using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneInstantiator : MonoBehaviour {

	[SerializeField]
	private GameObject playerPrefab;
	void Awake () {
		Instantiate(playerPrefab);
	}
	
}
