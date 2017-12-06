using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class MoveKumo : MonoBehaviour {

	// Use this for initialization
	private RectTransform rt;
	void Start () {
		rt = transform.GetComponent<RectTransform>();
		Move();
	}
	private void Move()
	{
		rt.DOAnchorPos (
			new Vector3(-1200,-400,0),
			40.0f
			).OnComplete(() => {

			ResetPos();
    });
	}
	private void ResetPos()
	{
		rt.anchoredPosition = new Vector3(100,-400,0);
		Move();
	}
	
	// Update is called once per frame
	void Update () {
	}
}
