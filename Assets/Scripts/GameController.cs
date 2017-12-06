using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

public class GameController : MonoBehaviour {

	// Use this for initialization
	private GameObject image;
	public GameObject Tower;
	private bool isButton = false;
	private bool isDown = false;
	RectTransform CanvasRect ;
	public Canvas canvas;
	void Start () {
		image = Tower;
		CanvasRect = canvas.GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!isDown&&Input.GetButton("Fire1")&&isButton)
		{
			Vector3 pos = Input.mousePosition;
			Vector3 worldPos = new Vector3(pos.x-CanvasRect.position.x,0,0);
			image.transform.GetComponent<RectTransform>().anchoredPosition = new Vector2(worldPos.x,image.transform.GetComponent<RectTransform>().anchoredPosition.y);
		}


		if (Input.GetButtonUp("Fire1")&&isButton)
        {
			Rigidbody2D rb = image.transform.GetComponent<Rigidbody2D>();
			rb.constraints = RigidbodyConstraints2D.None;
			isDown = true;

		}
		if(isDown)
		{
			image.transform.GetComponent<Rigidbody2D>().AddForce(Vector2.down * 10000);
		}
	}
	public void ClickButton()
	{
		isButton = false;

			image.transform.GetComponent<RectTransform>().DORotate(
		new Vector3(0f,0f,image.transform.GetComponent<RectTransform>().localEulerAngles.z+30),   // 終了時点のRotation
		0.5f
	).OnComplete(() => {

			isButton = true;
    });
	}
}
