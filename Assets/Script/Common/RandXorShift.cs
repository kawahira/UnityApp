// <copyright file="RandXorShift.cs" >(C)2013</copyright>
using System;
using System.Diagnostics;

/// <summary>
/// 乱数の取得
/// </summary>
public sealed class RandXorShift
{
		public XorShift128 Player   { get { return rndArray [0]; } }

		public XorShift128 Stage    { get { return rndArray [1]; } }

		public XorShift128 Itme     { get { return rndArray [2]; } }

		public XorShift128 Enemy    { get { return rndArray [3]; } }

		public XorShift128 Menu     { get { return rndArray [4]; } }

		public XorShift128 Rule     { get { return rndArray [5]; } }

		public XorShift128 Sequence { get { return rndArray [6]; } }

		private XorShift128[] rndArray = new XorShift128[7];
		private static volatile RandXorShift instance;
		private static object syncRoot = new Object ();

		/// <summary>
		/// シングルトン取得 
		/// </summary>
		public static RandXorShift Instance {
				get {
						if (instance == null) {
								lock (syncRoot) {
										if (instance == null)
												instance = new RandXorShift ();
								}
						}
						return instance;
				}
		}

		/// <summary>
		/// コンストラクター
		/// </summary>
		private RandXorShift ()
		{
				for (int i = 0; i < rndArray.Length; ++i) {
						rndArray [i] = new XorShift128 (1);
				}
				Seed (1);
				Enable (true);
		}

		/// <summary>
		/// 乱数シードを取得する
		/// </summary>
		public void Seed (int seed)
		{
				int seedTemp = seed;
				for (int i = 0; i < rndArray.Length; ++i) {
						rndArray [i].Seed (seedTemp);
						seedTemp = rndArray [i].Next () + i;
				}
		}

		/// <summary>
		/// ステータスの一括設定
		/// </summary>
		public void Enable (bool status)
		{
				for (int i = 0; i < rndArray.Length; ++i) {
						rndArray [i].enable = status;
				}
		}

		/// <summary>
		/// 実際の乱数生成器のクラス
		/// </summary>
		public class XorShift128 : Random
		{
				public bool enable;
				private int w, x, y, z;

				public int CallCount { set; get; }

				/// <summary>
				/// コンストラクター(時間初期化）
				/// </summary>
				public XorShift128 () : this ((int)DateTime.Now.Ticks)
				{
				}

				/// <summary>
				/// コンストラクター(指定seedで初期化)
				/// </summary>
				public XorShift128 (int seed)
				{
						Seed (seed); 
						enable = true;
				}

				/// <summary>
				/// Seedで初期化
				/// </summary>
				public void Seed (int seed)
				{
						Debug.Assert (seed != 0, "seed 0 is illegal paarmeter");
						w = seed;
						x = (seed << 16) + (seed >> 16);
						y = w + x;
						z = x ^ y;
						CallCount = 0;
				}

				/// <summary>
				/// 乱数取得 ( enable == false時はassert)
				/// </summary>
				public override int Next ()
				{
						++CallCount;
						Debug.Assert (enable, "Call Disable Randam");
						int t = x ^ (x << 11);
						x = y;
						y = z;
						z = w;
						return w = (w ^ (w >> 19)) ^ (t ^ (t >> 8));
				}

				/// <summary>
				/// 乱数取得 ( 最少、最大指定 )
				/// </summary>
				public override int Next (int minValue, int maxValue)
				{
						return ((this.Next () >> 1) % (maxValue - minValue)) + minValue;
				}

				/// <summary>
				/// 乱数取得 ( 0 ～ 最大指定 )
				/// </summary>
				public override int Next (int maxValue)
				{
						return Next (0, maxValue);
				}
		}
}
