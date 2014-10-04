// <copyright file="Hero.cs" >(C)2014</copyright>
using System.Collections;
using UnityEngine;

public class Hero : MonoBehaviour
{

    [SerializeField] public Vector2 pos;
		[SerializeField] public Vector2 posPrev;
		[SerializeField] public Vector2 accel;
		[SerializeField] public Vector2 maxSpeed;
		[SerializeField] public float gravity;
		[SerializeField] public float maxSpeedY;
		private bool facingRight = false;
		// Use this for initialization
		public void Start ()
		{
	
		}
		// Update is called once per frame
		public void Update ()
		{
	
		}

		public void FixedUpdate ()
		{
				float v = Input.GetAxis ("Vertical");
				float h = Input.GetAxis ("Horizontal");
				Vector2 vector;
				vector.x = h * accel.x;  
				vector.y = (v * accel.y) - gravity;
//		accel = vector;
				rigidbody2D.AddForce (vector);
/* 
		float y_temp = pos.y;
		pos.y +=  Mathf.Clamp(pos.y - posPrev.y - accel.y - gravity,  -maxSpeed.y, maxSpeed.y);
		posPrev.y = y_temp;
*/
				//右を向いていて、左の入力があったとき、もしくは左を向いていて、右の入力があったとき
				if ((h > 0 && !facingRight) || (h < 0 && facingRight)) {
						//右を向いているかどうかを、入力方向をみて決める
						facingRight = h > 0;
						//localScale.xを、右を向いているかどうかで更新する
						transform.localScale = new Vector3 (facingRight ? -1 : 1, 1, 1);
				}
				GetComponent<Animator> ().SetFloat ("MoveSpeed", Mathf.Abs (h)); 
		}
}
