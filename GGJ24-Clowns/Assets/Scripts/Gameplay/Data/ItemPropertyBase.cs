using UnityEngine;

public class ItemPropertyBase : ScriptableObject
{

}

public abstract class ItemProperty<T> : ItemPropertyBase
{
	[SerializeField]
	protected T _value;

	public T Value => _value;
}
