using UnityEngine;
using System.Collections;

public class GameGUI : MonoBehaviour {

	private InputHandler inpt;


	public GameObject alley;
//	public float speedSlider = 0.0F;
//	public float swingSlider = 0.0F;
//	public float dragSlider = 0.0F;

	private GUILayer layer;
	// Use this for initialization



	void Start () {

		layer = Camera.main.GetComponent<GUILayer>();

		inpt = alley.GetComponent<InputHandler>();



		//Debug.Log("Screen Resolution " + Screen.width + " " + Screen.height);
	}
	
	// Update is called once per frame
	void Update () {

		getInput();

		if(Input.GetKey(KeyCode.Escape))
		{
			Application.Quit();
		}

//		if (Input.touchCount > 0)
//			print(Input.touchCount);
		
	}

	void getInput()
	{
		string buttonName = "";
		if(Input.touches.Length > 0)
		{
			for(int i=0; i< Input.touches.Length; i++)
			{
				if(layer.HitTest(Input.GetTouch(i).position)) 
				{

					if(Input.GetTouch(i).phase == TouchPhase.Ended)
					{
//						Debug.Log(layer.HitTest(Input.GetTouch(i).position).name);
						switch (layer.HitTest(Input.GetTouch(i).position).name)
						{

						case "Button_Reset":
							inpt.reset();
							break;
						}
					}

				}
			}
		}
	}

	void OnGUI()
	{
//		speedSlider = GUI.HorizontalSlider(new Rect(25, 100, 100, 30), speedSlider, 0.0F, 500.0F);
//		swingSlider = GUI.HorizontalSlider(new Rect(150, 100, 100, 30), swingSlider, 0.0F, 500.0F);
//		dragSlider = GUI.HorizontalSlider(new Rect(275, 100, 100, 30), dragSlider, 0.0F, 500.0F);
//		GUI.Label(new Rect(130, 100, 25, 20), speedSlider.ToString());
//		GUI.Label(new Rect(260, 100, 25, 20), swingSlider.ToString());
//		GUI.Label(new Rect(385, 100, 25, 20), dragSlider.ToString());
//		
//		if (GUI.Button(new Rect(10, 10, 50, 50), "Fast"))
//		{
//			ballScript.updateBallStats(60.0f,0,0);
//			speedSlider = 60.0f;
//			swingSlider = 0.0f;
//			dragSlider = 0.0f;
//		}
//            
//        if (GUI.Button(new Rect(70, 10, 50, 50), "Slow"))
//		{
//			ballScript.updateBallStats(50,0,0);
//			speedSlider = 50.0f;
//			swingSlider = 0.0f;
//			dragSlider = 0.0f;
//		}
//            
//		
//		if (GUI.Button(new Rect(130, 10, 50, 50), "Curve"))
//		{
//			ballScript.updateBallStats(50,5,20);
//			speedSlider = 40.0f;
//			swingSlider = 5.0f;
//			dragSlider = 0.0f;
//		}
//		
//		if (GUI.Button(new Rect(190, 10, 50, 50), "Sinker"))
//		{
//			ballScript.updateBallStats(50.0f,0,45.0f);
//			speedSlider = 30.0f;
//			swingSlider = 0.0f;
//			dragSlider = 0.0f;
//		}
        
//		if (GUI.Button(new Rect(250, 10, 50, 50), "Pitch"))
//		{
////			ballScript.updateBallStats(speedSlider,swingSlider,dragSlider);
//			ballScript.updateBallStats(Random.Range(380,450),swingSlider,dragSlider);
//			ballScript.updateBallPos();
//			ballScript.isPitched = true;
//		}
//		
//		
//		if (GUI.Button(new Rect(310, 10, 100, 50), "Front camera"))
//		{
//			GameObject.Find("Main Camera").GetComponent<Camera>().enabled = true;
//			GameObject.Find("Side Camera").GetComponent<Camera>().enabled = false;
//			GameObject.Find("Ball Camera").GetComponent<Camera>().enabled = false;
//		}
//		
//		if (GUI.Button(new Rect(420, 10, 100, 50), "Side Camera"))
//		{
//			GameObject.Find("Main Camera").GetComponent<Camera>().enabled = false;
//			GameObject.Find("Side Camera").GetComponent<Camera>().enabled = true;
//			GameObject.Find("Ball Camera").GetComponent<Camera>().enabled = false;
//		}
//		
//		if (GUI.Button(new Rect(530, 10, 100, 50), "Reset Ball"))
//		{
//			ballScript.resetBallPos();
//		}
//		
//		if (GUI.Button(new Rect(640, 10, 100, 50), "Ball Cam"))
//		{
//			GameObject.Find("Main Camera").GetComponent<Camera>().enabled = false;
//			GameObject.Find("Side Camera").GetComponent<Camera>().enabled = false;
//			GameObject.Find("Ball Camera").GetComponent<Camera>().enabled = true;
//		}
		
	}
}
