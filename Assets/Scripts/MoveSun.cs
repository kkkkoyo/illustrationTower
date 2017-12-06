using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveSun : MonoBehaviour {

	// Use this for initialization
	private RectTransform rt;

	void Start () {
		rt = transform.GetComponent<RectTransform>();
		Move(true);
	}
	private void Move(bool isBig)
	{
		rt.DOScale (
			isBig ? new Vector3(1.1f,1.1f,1.1f):Vector3.one,
			1.3f
			).OnComplete(() => {

			Move(!isBig);
    });
	}
	// Update is called once per frame
	void Update () {
		transform.Rotate(new Vector3(0,0,-0.4f));
	}
}
