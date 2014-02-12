using UnityEngine;
using System.Collections;

public class GuiPosition : MonoBehaviour {

	//variables for poistioning of guielements
	private float rx;
	private float ry;
	private float curWidth;
	private float curHeight;
	private Vector2 btnTexPos;
	private Vector2 btnTexSiz;
	public GUITexture currTex;

	// Use this for initialization
	void Start () {
//		currTex = GetComponent<GUITexture>();
		Screen.SetResolution(720, 1280, true);
		curWidth = Screen.width;
		curHeight = Screen.height;
		rx = curWidth/720;
		ry = curHeight/1280;
//		btnTexPos = new Vector2(GetComponent<GUITexture>().pixelInset.x,GetComponent<GUITexture>().pixelInset.y);
		currTex.pixelInset= new Rect(currTex.pixelInset.x*rx,currTex.pixelInset.y*ry,128*rx,72*ry);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
