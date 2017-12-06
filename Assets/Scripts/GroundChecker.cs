using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour {

	
	public GameController game;
	//接触したときのイベント用メソッド 

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag=="tower")
		{
			other.gameObject.tag = "Player";
			StartCoroutine(Generate());
		}	
	}
	IEnumerator Generate()
	{
		yield return new WaitForSeconds(0.5f);
		//game.Generate();
	}
}
