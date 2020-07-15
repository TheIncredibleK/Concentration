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
	[SerializeField]
	private int Segments = 10;

	// PUBLIC ACCESSORS AND INFO PROVIDERS //
	public  PlayerInformationProvider PlayerInformationProvider { get; }
	public Vector3 SlerpToPosition { get; private set; }
	private int postiionIndex = 0;
	public Vector3[] PotentialPositions;
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
		var locations = LocationProvider.ProvideLocations(Segments, transform);
		PotentialPositions = locations.ToArray();

		foreach(var locat in locations)
		{
			var gob = GameObject.CreatePrimitive(PrimitiveType.Cube);
			gob.transform.position = locat;
		}
		transform.position = PotentialPositions[postiionIndex];
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
		transform.position = PotentialPositions[postiionIndex];
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
		var directionAsint = (int)move;

		var potentialNewIndex = postiionIndex + directionAsint;
		if(potentialNewIndex > Segments -1 || potentialNewIndex < 0)
		{
			return;
		}

		postiionIndex = potentialNewIndex;
	}

	
}
