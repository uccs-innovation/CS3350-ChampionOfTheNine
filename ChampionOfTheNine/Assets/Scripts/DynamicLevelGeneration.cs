﻿using UnityEngine;
using System.Collections;

public class DynamicLevelGeneration : MonoBehaviour {
	int[] levels = new int[100];
	float elevationWeight = 1;

	// Use this for initialization
	void Start () {
		elevationWeight = Random.Range (.25f, .50f);
		Debug.Log (elevationWeight);

		//creates "platform" for the castle on the left
		for (int i = 0; i < 10; i++)
		{
			levels[i] = 5;
		}

		//fills in the rest of the aray.
		for (int i = 10; i < 90; i++) 
		{
			levels[i] = NextHeight(levels[i - 1]);
		}

		//creates platform for right castle
		for (int i = 90; i < 100; i++) 
		{
			levels[i] = levels[89];
		}

		DrawMap ();
	}

	int NextHeight(int previous)
	{
		//use weight to decide if we should change direction or not.
		if (Random.Range (0.00f, 1.00f) <= elevationWeight) {
			//change direction
			if (Random.Range (0.00f, 10.00f) >= (10 - previous))
			{
				//go down
				return previous - 1;
			} 
			else
			{
				//go up
				return previous + 1;
			}
		} else {
			return previous;
		}
	}

	void DrawMap()
	{
		Transform groundParent = GameObject.Find ("Ground").transform;

		//draws each of the top blocks
		for (int i = 0; i < levels.Length; i++) 
		{
			GameObject newObject = Instantiate (Resources.Load ("Prefabs/ground")) as GameObject;
			newObject.transform.SetParent(groundParent);
			newObject.transform.position = new Vector2(i, levels[i]);

			//draws the blocks under the top
			for (int j = 0; j < levels[i]; j++)
			{
				GameObject soil = Instantiate (Resources.Load ("Prefabs/rocks")) as GameObject;
				soil.transform.SetParent(groundParent);
				soil.transform.position = new Vector2(i, j);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
