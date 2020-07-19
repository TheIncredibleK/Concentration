using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constants {

	public static class GameStateConstants
	{
		public const int LOCATION_AMT = 10;
		public const float OBSTACLE_SPEED = 5.0f;
	}

	public static class Directions
	{
		public const string HORIZONTAL = "Horizontal";
	}

	public static class Tags
	{
		public const string PLAYER = "Player";
		public const string OBSTACLE = "Obstacle";
		public const string PREFAB_PROVIDER = "PrefabProvider";
	}
}
