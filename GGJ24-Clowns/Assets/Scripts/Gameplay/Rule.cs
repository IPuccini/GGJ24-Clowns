using TMPro;
using UnityEngine;

public class Rule : MonoBehaviour
{
	[SerializeField]
	private TMP_Text _text;

	public void Init(RulesDataBase rule)
	{
		_text.text = rule.Text;
		gameObject.SetActive(true);
	}
}


