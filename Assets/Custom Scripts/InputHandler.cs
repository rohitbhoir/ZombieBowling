using UnityEngine;
using System.Collections;

public class InputHandler : MonoBehaviour 
{   
	public static int swipeDir = 0;
	public GameObject bowlBall;
	public GameObject[] pins;

	public GUIText debText;
	public bool bowled = false;

	private Vector3[] pinPos = new Vector3[10];
	private Vector3 ballPos;

	public float rollSpeed = 20.0f;
	

	// Swipe related
	private float             comfortZone = 500.0f; //Experiment with these values to get desired result
	private float             minSwipeDist = 10.0f; //Experiment with these values to get desired result
	private float             maxSwipeTime = 15f;    //Experiment with these values to get desired result
	private enum             eSwipeDirection 
	{
		None,
		Left,
		Right,
		Up,
		Down,
	}
	private float startTime;
	private Vector2 startPos;
	private bool couldBeSwipe;   
	private eSwipeDirection      m_LastSwipe = InputHandler.eSwipeDirection.None; 
	private Vector2              m_HorizontalSwipeVector;
	private Vector2              m_VerticalSwipeVector;
	

	void Start()
	{
		bowlBall.rigidbody.Sleep();
		for(int i=0; i < 10; i++)
		{
			pinPos[i] = new Vector3(0,0,0);
		}
		for(int i=0; i < pins.Length; i++)
		{
			pinPos[i] = pins[i].transform.position;
		}
		ballPos = bowlBall.transform.position;
	}

	void Update () 
	{
		HandleTouchGestureInput();

		if(bowled)
			handleAccelerometerInput();

	}


	void handleAccelerometerInput()
	{
		Vector3 dir = Vector3.zero;
		
		//dir.x = -Input.acceleration.y;
		dir.x = -Input.acceleration.x;
		
		Debug.Log("acc x " + dir.x + " acc z " + dir.z);
		
		if (dir.sqrMagnitude > 1)
			dir.Normalize();

		// Make it move 10 meters per second instead of 10 meters per frame...
		//dir *= Time.deltaTime;
		// Move object
		//transform.Translate (dir * speed);
		bowlBall.rigidbody.AddForce(dir * rollSpeed);
	}

	private void HandleTouchGestureInput()
	{  
		if(Input.touches.Length == 1)
		{
			//Finger data
			Touch touchedFinger = Input.touches[0];
			
			switch(touchedFinger.phase)
			{         
			case TouchPhase.Began: // stop/start swipe
				m_LastSwipe = InputHandler.eSwipeDirection.None;       
				couldBeSwipe = true;
				startPos = touchedFinger.position;          
				startTime = Time.time;
				bowlBall.rigidbody.WakeUp();
				for(int i=0; i < pins.Length; i++)
				{
					pins[i].rigidbody.WakeUp();
				}

				break;
//			case TouchPhase.Moved: //Detection if not a swipe
//				if (Mathf.Abs(touchedFinger.position.y - startPos.y) > comfortZone) 
//				{
//					Debug.Log("Not a swipe. Swipe is " + (int)(Mathf.Abs(touchedFinger.position.y - startPos.y) - comfortZone) + "px outside the comfort zone.");
//					couldBeSwipe = false;  
//				}
//				
//				if (Mathf.Abs(touchedFinger.position.x - startPos.x) > comfortZone) 
//				{
//					Debug.Log("Not a swipe. Swipe is " + (int)(Mathf.Abs(touchedFinger.position.x - startPos.x) - comfortZone) + "px outside the comfort zone.");
//					couldBeSwipe = false;  
//				}
//				break;

				//Instantiate(dummy,touchedFinger.position,Quaternion.identity);

			case TouchPhase.Ended: //Swipe detection           
				if (couldBeSwipe)
				{        
					bowled = true;
					float swipeTime = Time.time - startTime;             
					Vector3 swipeDir = touchedFinger.position - startPos;
					float swipeDist = swipeDir.magnitude;  
					Vector3 swipeDirNormalized = swipeDir.normalized;
					Vector3 endPos = touchedFinger.position;
					
//					Debug.Log("swipeDist : " + swipeDist + " and min swipe dis is : " + minSwipeDist);
//					Debug.Log("swipeTime : " + swipeTime + " and max swipe time is : " + maxSwipeTime);
					
					if ((swipeTime < maxSwipeTime) && (swipeDist > minSwipeDist)) 
					{
						//             // It's a swiiiiiiiiiiiipe!           
						float tolerance = 0.1f;
						float minSwipeDot = Mathf.Clamp01( 1.0f - tolerance );

						m_HorizontalSwipeVector = Vector2.right;
						m_VerticalSwipeVector = Vector2.up;


//						
						float ang = Vector3.Angle(swipeDir,Vector3.right);
						float rad = Vector3.Angle(swipeDir,Vector3.right) * Mathf.Deg2Rad;
						float xForce = Mathf.Cos(rad) * swipeDist*10;
						float yForce = Mathf.Sin(rad) * swipeDist*10;
						if(ang > 90.0f)
							bowlBall.rigidbody.AddForce(-xForce,0,-swipeDist*30);
						else
							bowlBall.rigidbody.AddForce(-xForce,0,-swipeDist*30);
						//Debug.Log("Last swipe : " + m_LastSwipe + " start Pos " + startPos + " end Pos " + endPos + " Angle " + Vector3.Angle(swipeDir,Vector3.right));
						//Debug.Log("Xforce " + xForce + " yforce " + yForce);
						debText.text =  "Xforce " + xForce + " yforce " + yForce + " \nstart Pos " + startPos + " \nend Pos " + endPos + " \nAngle " + Vector3.Angle(swipeDir,Vector3.right) + "\nRad " + rad;
					}
				}
				break;
			default:
				break;
			}
		}
	}

	public void reset()
	{
		bowled = false;
		for(int i=0; i < pins.Length; i++)
		{
			pins[i].rigidbody.Sleep();
			pins[i].transform.position = pinPos[i];
			pins[i].transform.localEulerAngles = new Vector3(270,0,0);

		}
		bowlBall.transform.position  = ballPos;
		bowlBall.transform.rotation = Quaternion.identity;
		bowlBall.rigidbody.Sleep();
	}


}