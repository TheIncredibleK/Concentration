using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score  {

	[SerializeField]
	public int CurrentScore { get; private set; }

	public Score(int score)
	{
		CurrentScore = score;
	}
	
}
