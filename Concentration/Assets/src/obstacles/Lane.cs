using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lane : MonoBehaviour {

	public Lane(List<Obstacle> obstacles)
	{
		AllObstacles = obstacles;
	}

	List<Obstacle> AllObstacles;
	// Use this for initialization
	void Start () {
			
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
