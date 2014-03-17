// <copyright file="Spline.cs" >(C)2014</copyright>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

/// <summary>
/// スプライン計算
/// </summary>
public class Spline
{
	List<Vector3> _points = new List<Vector3>();
	float _segmentSize = 0;
	
	/// <summary>
	/// ポイントの追加
	/// </summary>
	public void AddPoint(Vector3 point)
	{
		_points.Add(point);
		_segmentSize = 1 / (float)_points.Count;
	}
	/// <summary>
	/// Get the points around the segment
	/// </summary>
	private int LimitPoints(int point)
	{
		if (point < 0)
		{
			return 0;
		}
		else if (point > _points.Count - 1)
		{
			return _points.Count - 1;
		}
		else
		{
			return point;
		}
	}
	
	/// <summary>
	/// t ranges from 0 - 1
	/// </summary>
	public Vector3 GetPositionOnLine(float t)
	{
		if (_points.Count <= 1)
		{
			return new Vector3(0, 0, 0);
		}
		
		// Get the segment of the line we're dealing with.
		int interval = (int)(t / _segmentSize);
		
		// Get the points around the segment
		int p0 = LimitPoints(interval - 1);
		int p1 = LimitPoints(interval);
		int p2 = LimitPoints(interval + 1);
		int p3 = LimitPoints(interval + 2);
		
		// Scale t to the current segement
		float scaledT = (t - _segmentSize * (float)interval) / _segmentSize;
		return CalculateCatmullRom(scaledT, _points[p0], _points[p1], _points[p2], _points[p3]);
	}
	/// <summary>
	/// 計算処理実体
	/// </summary>
	private Vector3 CalculateCatmullRom(float t, Vector3 p1, Vector3 p2, Vector3 p3, Vector3 p4)
	{
		float t2 = t * t;
		float t3 = t2 * t;
		
		float b1 = 0.5f * (-t3 + 2.0f * t2 - t);
		float b2 = 0.5f * (3.0f  * t3 - 5.0f * t2 + 2.0f);
		float b3 = 0.5f * (-3.0f * t3 + 4.0f * t2 + t);
		float b4 = 0.5f * (t3 - t2);
		
		return (p1 * b1 + p2 * b2 + p3 * b3 + p4 * b4);
	}
}
