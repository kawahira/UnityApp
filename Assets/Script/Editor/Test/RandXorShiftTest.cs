using System;
using System.Threading;
using NUnit.Framework;

internal class RandXorShiftTest
{
		[Test]
		public void RandXorShiftTestCall ()
		{
				int loopCount = 1000;
				RandXorShift.Instance.Seed (0);
				Assert.AreEqual (0, RandXorShift.Instance.Player.Next ());
				RandXorShift.Instance.Seed (1);
				Assert.AreEqual (2056, RandXorShift.Instance.Player.Next ());
				Assert.AreEqual (8394888, RandXorShift.Instance.Stage.Next ());
				Assert.AreEqual (8396976, RandXorShift.Instance.Itme.Next ());
				Assert.AreEqual (21002514, RandXorShift.Instance.Enemy.Next ());
				Assert.AreEqual (6503175, RandXorShift.Instance.Menu.Next ());
				Assert.AreEqual (355796057, RandXorShift.Instance.Rule.Next ());
				Assert.AreEqual (1771517083, RandXorShift.Instance.Sequence.Next ());
				Assert.AreEqual (1, RandXorShift.Instance.Player.Next ());
				Assert.AreEqual (4099, RandXorShift.Instance.Stage.Next ());
				Assert.AreEqual (4100, RandXorShift.Instance.Itme.Next ());
				Assert.AreEqual (6203, RandXorShift.Instance.Enemy.Next ());
				Assert.AreEqual (6294616, RandXorShift.Instance.Menu.Next ());
				Assert.AreEqual (33399135, RandXorShift.Instance.Rule.Next ());
				Assert.AreEqual (13808322, RandXorShift.Instance.Sequence.Next ());
				{   // 最大値を入れたらそれ以上の値が出てはいけない
						bool flag = true;
						for (int i = 0; i < loopCount; ++i) {
								if (RandXorShift.Instance.Player.Next (1) != 0) {
										flag = false;
										break;
								}
						}
						Assert.IsTrue (flag);
				}
				{   // 最少、最大設定パターン
						bool flag = true;
						for (int i = 0; i < loopCount; ++i) {
								if (RandXorShift.Instance.Player.Next (0, 1) != 0) {
										flag = false;
										break;
								}
						}
						Assert.IsTrue (flag);
				}
				{   // 最少、最大設定パターン
						bool flag = true;
						for (int i = 0; i < loopCount; ++i) {
								if (RandXorShift.Instance.Player.Next (1, 2) != 1) {
										flag = false;
										break;
								}
						}
						Assert.IsTrue (flag);
				}
				{   // 最少、最大設定パターン
						int count = 0;
						for (int i = 0; i < loopCount; ++i) {
								if (RandXorShift.Instance.Player.Next (0, 2) == 1) {
										++count;
								}
						}
						Assert.AreEqual (511, count);
				}
		}
}
