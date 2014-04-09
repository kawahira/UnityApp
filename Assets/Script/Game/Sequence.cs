// <copyright file="Sequence.cs" >(C)2014</copyright>
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	/// <summary>
	/// シーケンス管理処理 </summary>
	public class Sequence : MonoBehaviour
	{
			[SerializeField] public GUISkin skin;
			private Stack<SequenceInfo> myStack = new Stack<SequenceInfo>();
			private SequenceInfo currentSequence;
			private	Scene.Base currentScene = null;
			/// <summary>
			/// Start </summary>
			public void Start ()
			{
					currentSequence = new SequenceInfo(Resource.Instance.sequenceList[0]);
					myStack.Push(currentSequence);
					StartCoroutine (Coroutine ());
			}

			/// <summary>
			/// シーケンス実体 </summary>
			private IEnumerator Coroutine ()
			{
					for (;;) {
	            			Debug.Log (currentSequence.data.sceneList[currentSequence.sceneIndex] + " index:" + currentSequence.sceneIndex);
							{
								
								SerializeData.Scene data = Resource.Instance.sceneList.Find(delegate(SerializeData.Scene s) { return s.name == currentSequence.data.sceneList[currentSequence.sceneIndex]; } );
								currentScene = (Scene.Base)Activator.CreateInstance (WrapClass.GetType (data.functionName));
								currentScene.Initialize (data);
							}
							currentScene.RequestLoad (ref GetComponent<FileAssetBundle> ().blockList);
							do {
									yield return null;
							} while (GetComponent<FileAssetBundle> ().blockList.Find (delegate(Asset.Block block) {
									return block.IsRead () == false;
							}) != null);
							currentScene.RequestStart ();
							do {
									if (currentScene.IsDone ()) {
											break;
									}
									yield return null;
							} while (true);
							currentScene.RequestUnload ();
							do {
									if (currentScene.IsUnload ()) {
											break;
									}
									yield return null;
							} while (true);
							switch (currentScene.endStatus) {
									case Scene.EndStatus.NEXT  :
										if ( currentSequence.sceneIndex < currentSequence.data.sceneList.Count - 1 )
										{
											++currentSequence.sceneIndex;
										} else {
												if ( currentSequence.data.isLoop )
												{
													currentSequence.sceneIndex = 0;
												}
												else
												{
													if ( currentSequence.data.next != string.Empty)
													{
															SerializeData.Sequence tmp = Resource.Instance.sequenceList.Find(delegate(SerializeData.Sequence seq) { return seq.name == currentSequence.data.next; } );
															if ( tmp != null )
															{
																	currentSequence = new SequenceInfo(tmp);
																	myStack.Push(currentSequence);
															} else {
																	Debug.Log("no sequence");
															}
													} else {
															if ( myStack.Count > 1 )
															{
																	currentSequence = myStack.Pop();
															} else {
																	Debug.Log("root stack no back sequence");
															}
													}
												}
										}
									break;
									case Scene.EndStatus.BACK  :
										if ( currentSequence.sceneIndex != 0 )
										{
											--currentSequence.sceneIndex;
										} else {
												if ( myStack.Count > 1 ) {
														currentSequence = myStack.Pop();
												} else {
														Debug.Log("root stack no back sequence");
												}
										}
									break;
									case Scene.EndStatus.ABORT :
									break;
							}
							Resources.UnloadUnusedAssets (); 
							GC.Collect ();
					}
			}

			/// <summary>
			/// シーンの On GUI（本来はあってはいけない） </summary>
			public void OnGUI ()
			{
					GUI.skin = skin;
					if ( currentScene != null ) {
						currentScene.DebugDraw(5.0f, 150.0f);
					}
			}
	}
}