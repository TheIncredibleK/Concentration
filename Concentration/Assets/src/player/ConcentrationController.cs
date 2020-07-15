using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controller class for the ship.
/// Main functions:
///  1) To contain, and enact movements.
///  2) Populate a common object for other objects to access the next movements and current position of the player.
/// </summary>
public class ConcentrationController : MonoBehaviour {

	// GAME SETTINGS.. TODO: Move out to config object //
	[SerializeField]
	private int _moveOffset = 1;
	[SerializeField]
	private List<Vector3> _potentialLocations;

	// PUBLIC ACCESSORS AND INFO PROVIDERS //
	public  PlayerInformationProvider PlayerInformationProvider { get; }
	public Vector3 SlerpToPosition { get; private set; }

	Queue<MoveDirection> playerMoves;

	// Use this for initialization
	void Start () 
	{
		playerMoves = new Queue<MoveDirection>();
		_potentialLocations = new List<Vector3>();
		SetupLocationsList();

	}
	// Set Up //
	private void SetupLocationsList()
	{
		var centreOfCamera = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));

		transform.position = LocationProvider.Test(transform);
	}
	
	// Update is called once per frame
	void Update () 
	{
		var moveDirection = MoveDirection.Undefined;

		if(TryProvideMove(out moveDirection))
		{
			Debug.Log("Got a move = " + moveDirection.ToString());
			playerMoves.Enqueue(moveDirection);
		}

		// TODO: Move this '1' to a variable in a settings file
		if (playerMoves.Count > _moveOffset)
		{
			ApplyMove(playerMoves.Dequeue());
		}

	}

	public bool TryProvideMove(out MoveDirection direction)
	{
		if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
		{
			direction = MoveDirection.Left;
			return true;
		}

		if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
		{
			direction = MoveDirection.Right;
			return true;
		}

		direction = MoveDirection.Undefined;
		return false;
	}

	public void ApplyMove(MoveDirection move)
	{
		var directionAsint = (float)move;

		this.transform.position = new Vector3(this.transform.position.x + (5.0f * directionAsint), this.transform.position.y, this.transform.position.z);
	}

	
}
