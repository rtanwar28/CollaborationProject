using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour 
{
	public GameObject playerPrefab;
	GameObject startPoint;

	// Use this for initialization
	void Start () 
	{
		startPoint = GameObject.Find ("PlayerStartPoint");
		Instantiate (playerPrefab, startPoint.transform.position, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
