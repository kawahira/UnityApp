using System.Collections;
using UnityEngine;

public class FlickThrowTouch : MonoBehaviour 
{
	public Vector2 touchStart;
	public Vector2 touchEnd;
	public int flickTime = 5;
	public int flickLength = 0;
	public float ballVelocity = 0.0f;
	public float ballSpeed = 0;
	public Vector3 worldAngle;
	public GameObject ballPrefab;
	private bool getVelocity = false;
	public AudioClip ballAudio;  //yes
	public float comfortZone = 0.0f;
	public bool couldBeSwipe;
	public float startCountdownLength = 0.0f;
	public bool startTheTimer = false;
	private static bool shootEnable = false;
	private float startGameTimer = 0.0f;
	public void  Start () 
	{
		startTheTimer = true;
		Time.timeScale = 1;
		if ( Application.isEditor )
		{
			Time.fixedDeltaTime = 0.01f;
		}
	}
	public void Update () 
	{
		if (startTheTimer) 
		{
			startGameTimer += Time.deltaTime;
		}
		
		if (startGameTimer > startCountdownLength)
		{
			shootEnable = true;
			startTheTimer = false;
			startGameTimer = 0;
		}   
		if (shootEnable) 
		{
			Debug.Log ("enabled!");
			if (Input.touchCount > 0) 
			{
				var touch = Input.touches[0];
				switch (touch.phase) 
				{
				case TouchPhase.Began:
					flickTime = 5;
					timeIncrease();
					couldBeSwipe = true;
					getVelocity = true;
					touchStart= touch.position;
					break;
				case TouchPhase.Moved:
					if (Mathf.Abs(touch.position.y - touchStart.y) < comfortZone) 
					{
						couldBeSwipe = false;
					}
					else 
					{
						couldBeSwipe = true;
					}
					break;
				case TouchPhase.Stationary:
					if (Mathf.Abs(touch.position.y - touchStart.y) < comfortZone) 
					{
						couldBeSwipe = false;
					}
					break;
				case TouchPhase.Ended:
					float swipeDist = (touch.position - touchStart).magnitude;
					if (couldBeSwipe && swipeDist > comfortZone) 
					{
						getVelocity = false;
						touchEnd = touch.position;
						Rigidbody ball = Instantiate(ballPrefab, new Vector3(0.0f,2.6f,-11.0f), Quaternion.identity) as Rigidbody;
						GetSpeed();
						GetAngle();
//						ball.rigidbody.AddForce(new Vector3((worldAngle.x * ballSpeed), (worldAngle.y * ballSpeed), (worldAngle.z * ballSpeed)));
					}
					break;
				default :
					break;
				}
				if (getVelocity) 
				{
					flickTime++;
				}
			}
		}
		if (!shootEnable)
		{
			Debug.Log("shot disabled!");
		}
	}
	public void TimeIncrease() 
	{
		if (getVelocity) 
		{
			flickTime++;
		}
	}
	public void GetSpeed() 
	{
		flickLength = 90;
		if (flickTime > 0) 
		{
			ballVelocity = flickLength / (flickLength - flickTime);
		}
		ballSpeed = ballVelocity * 30;
		ballSpeed = ballSpeed - (ballSpeed * 1.65f);
		if (ballSpeed <= -33)
		{
			ballSpeed = -33;
		}
		Debug.Log("flick was" + flickTime);
		flickTime = 5;
	}
	public void GetAngle () 
	{
//		worldAngle = camera.ScreenToWorldPoint(new Vector3 (touchEnd.x, touchEnd.y + 800.0f, ((camera.nearClipPlane - 100.0f)*1.8f)));
	}
}
