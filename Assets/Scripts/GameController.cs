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
	public GameObject[] chara;
	int power;
	int powerValue = 10000;
	void Start () {
		image = Tower;
		power = powerValue;
		CanvasRect = canvas.GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	public void Generate()
	{
		isDown = false;
		power = powerValue;
		int id = Random.Range(0,chara.Length);
		image = Instantiate(chara[id]);
		image.transform.parent = GameObject.Find("Canvas").transform;
		image.transform.GetComponent<RectTransform>().localPosition = chara[id].transform.GetComponent<RectTransform>().position;
		image.transform.GetComponent<RectTransform>().localScale = chara[id].transform.GetComponent<RectTransform>().localScale;

	}
	public void InputGetButton()
	{
		if(isButton)
			return;
		Vector3 pos = Input.mousePosition;
		Vector3 worldPos = new Vector3(pos.x-CanvasRect.position.x,0,0);
		image.transform.GetComponent<RectTransform>().anchoredPosition = new Vector2(worldPos.x,image.transform.GetComponent<RectTransform>().anchoredPosition.y);
	}
	public void InputGetButtonUp()
	{
		if(isButton)
			return;
		Rigidbody2D rb = image.transform.GetComponent<Rigidbody2D>();
		rb.constraints = RigidbodyConstraints2D.None;
		isDown = true;
		StartCoroutine(GenerateCounter());
	}
	void Update () {
		if(isDown)
		{
			image.transform.GetComponent<Rigidbody2D>().AddForce(Vector2.down * power);
			if(power>=0)
				power-=200;
			if(power<=7000)
				power=0;
			
		}
	}
	public void ClickButton()
	{
		isButton = true;

			image.transform.GetComponent<RectTransform>().DORotate(
		new Vector3(0f,0f,image.transform.GetComponent<RectTransform>().localEulerAngles.z+30),   // 終了時点のRotation
		0.5f
	).OnComplete(() => {

			isButton = false;
    });
	}
	IEnumerator GenerateCounter()
	{
		yield return new WaitForSeconds(4.5f);
		Generate();
	}
}
