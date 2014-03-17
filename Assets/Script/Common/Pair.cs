// <copyright file="Pair.cs" >(C)2014</copyright>
 
public class Pair<K, V>
{
	private K key;
	private V val;
	/// <summary>
	/// コンストラクタ
	/// </summary>
	public Pair(K k, V v)
	{
		key = k;
		val = v;
	}
	/// <summary>
	/// Key情報(First)
	/// </summary>
	public K Key { get { return this.key; } set { this.key = value; } }
	/// <summary>
	/// Value情報(Sencond)
	/// </summary>
	public V Value { get { return this.val; } set { this.val = value; } }
}
