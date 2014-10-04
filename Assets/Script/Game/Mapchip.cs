// <copyright file="Mapchip.cs" >(C)2014</copyright>
using System;
using UnityEngine;

/// <summary>
/// MapChipのステージ処理
/// </summary>
public class Mapchip : MonoBehaviour
{
		[SerializeField] public GameObject MapSpritePrefab = null;
		[SerializeField] public Sprite[] sprArr = null;
		private int mapchipWidth = 31;
		private int mapchipHeight = 31;
		[SerializeField] public float offsetX = 0.32f * 16.0f;
		[SerializeField] public float offsetY = 0.32f * 16.0f;

		public void Start ()
		{
				MapSpritePrefab.GetComponent<SpriteRenderer> ().sprite = sprArr [209];
				for (int i = 0; i < 32; ++i) {
						for (int j = 0; j < 32; ++j) {
//				int index = i+j+1;
//				MapSpritePrefab.transform.position.Set(i*mapchipWidth, j*mapchipHeight,0.0f);
								Instantiate (MapSpritePrefab, new Vector3 (-offsetX + ((float)(mapchipWidth * i) / 100.0f), offsetY + ((float)((mapchipHeight * j) * -1.0f) / 100.0f), 0.0f), Quaternion.identity);
 						}
				}
		}
}

