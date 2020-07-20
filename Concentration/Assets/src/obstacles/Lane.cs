using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lane : MonoBehaviour {

	[SerializeField]
	private bool amIActive = false;
	public Lane(List<GameObject> obstacles)
	{
		
		AllObstacles = obstacles;

		foreach(var obstacle in AllObstacles)
		{
			obstacle.transform.SetParent(transform);
		}
	}

	List<GameObject> AllObstacles = new List<GameObject>();
	// Use this for initialization
	void Start () {
			
	}
	
	// Update is called once per frame
	void Update () {
		if(amIActive)
		{
			transform.position += Vector3.down * Constants.GameStateConstants.OBSTACLE_SPEED * Time.deltaTime;
		}	
	}

	public void Activate()
	{
		amIActive = true;
	}
}
