using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

	[SerializeField]
	public float MovementSpeed { get; private set; }
	// Use this for initialization
	void Start () {
		MovementSpeed = Constants.GameStateConstants.OBSTACLE_SPEED;
	}

	void Update()
	{
		transform.position += Vector3.down * Constants.GameStateConstants.OBSTACLE_SPEED * Time.deltaTime;
	}
}
