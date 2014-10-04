using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Anim
{
		public class Data
		{
  		public bool loop;
			public float length;
			public List<Pair<float,int>> frame = new List<Pair<float,int>> ();
		}
	
		public class Controller
		{
				private float frame = 0.0f;
				public List<Data> data =  new List<Data>();
				public int index = 0;
				public void Set(int idx)
	  		{
						if ( idx != index && idx < data.Count )
						{
								index = idx;
								frame = 0.0f;
	  				}
	  		}
	  		Data Get()
	  		{
	  				return data[index];
	  		}
				public bool Update(float delta)
				{
						frame += delta;
						if ( frame >= Get().length )
						{
								frame -= Get().length;
								return true;
						}
						else
						{
								return false;
						}
				}
				public int GetSprite()
				{
						int spno = Get().frame[0].Value;
						foreach( Pair<float,int> pair in Get().frame )
						{
								if ( frame >= pair.Key )
								{
										spno = pair.Value;
								}
								else
								{
										break;
								}
						}
						return spno;
				}
		}
}

public class Character : MonoBehaviour {

	// Use this for initialization
	public string spriteName;
	Anim.Controller anim = new Anim.Controller();
	Sprite[] sprites = null;
	float Angle = 0.0f;
	float AngleDt = 0.0f;
	int directionIndex = 2;
	void Start () {
		for ( int i = 0 ; i < 4 ; i++ )
		{
				Anim.Data anm = new Anim.Data();
				anm.loop = true;
				anm.length = 1.0f;
				anm.frame.Add(new Pair<float,int >(0.0f,(i*3)+0));
				anm.frame.Add(new Pair<float,int >(0.25f,(i*3)+1));
				anm.frame.Add(new Pair<float,int >(0.5f,(i*3)+2));
				anm.frame.Add(new Pair<float,int >(0.75f,(i*3)+1));
				anim.data.Add(anm);
				Debug.Log(i + ":" + anm.frame.Count);
		}
		sprites = Resources.LoadAll<Sprite>(spriteName);
	}
	// Update is called once per frame
	Vector3 MoveTarget;
	Vector3 MoveVector;
	float testFrame = 2.0f;
	/// <summary>
	/// 指定のオブジェクトの方向に回転する
	/// </summary>
	/// <param name="self">Self.</param>
	/// <param name="target">Target.</param>
	/// <param name="forward">正面方向</param>
	public void LookAt2D(Transform self, Transform target, Vector2 forward)
	{
		LookAt2D (self, target.position, forward);
	}
	
	public void LookAt2D(Transform self, Vector3 target, Vector2 forward)
	{
		var forwardDiff = GetForwardDiffPoint (forward);
		Vector3 direction = target - self.position;
		float angle = Mathf.Atan2(direction.y,direction.x) * Mathf.Rad2Deg;
		self.rotation = Quaternion.AngleAxis(angle - forwardDiff, Vector3.forward);
	}
	
	/// <summary>
	/// 正面の方向の差分を算出する
	/// </summary>
	/// <returns>The forward diff point.</returns>
	/// <param name="forward">Forward.</param>
	private float GetForwardDiffPoint(Vector2 forward)
	{
		if (Equals (forward, Vector2.up)) return 90;
		if (Equals (forward, Vector2.right)) return 0;
		return 0;
	}	
	void Move(float delta)
	{
		testFrame += delta ;
		if ( testFrame >= 8.0f )
		{
			testFrame -= 8.0f;
					MoveTarget.x = (RandXorShift.Instance.Player.Next(1,200) / 100.0f);
					MoveTarget.y = (RandXorShift.Instance.Player.Next(1,150) / 100.0f);
					transform.position = new Vector3(0.0f,0.0f,0.0f);
		}
		float targetAngle  = Vector3.Angle(transform.position, MoveTarget);
			float diffAngle = targetAngle - Angle;
		  if ( diffAngle < 0.0f )
			{
					AngleDt -= delta;
					if ( AngleDt < -2.0f ) AngleDt = -2.0f;
			}
			else
			{
					AngleDt += delta;
					if ( AngleDt > 2.0f ) AngleDt = 2.0f;
			}
			Angle += AngleDt;
		Debug.Log("Angle:" + Angle + "Dt:" + AngleDt+"target:"+targetAngle+"diff:"+diffAngle);
		float dist = Vector3.Distance(MoveTarget, transform.position);
			if ( dist >= 0.01 )
			{
		  		MoveVector = (MoveTarget - transform.position);
					if ( Mathf.Abs(MoveVector.x) > Mathf.Abs(MoveVector.y) )
					{				    }
					else
					{
			}
			MoveVector.Normalize();
					transform.position += (MoveVector * delta);
		}
		LookAt2D(transform,MoveTarget,Vector2.up);
	}
	void Update () {
		float delta = DeltaTime.Instance.Get();
		Move(delta);
		anim.Update(delta);
		GetComponent<SpriteRenderer>().sprite = sprites[anim.GetSprite()];
	}
}
