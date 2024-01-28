using TMPro;
using UnityEngine;

public class Rule : MonoBehaviour
{
	[SerializeField]
	private TMP_Text _text;
	[SerializeField]
	private SpriteRenderer _spriteRenderer;
	[SerializeField]
	private Sprite[] _sprites;

	public void Init(RulesDataBase rule)
	{
		_text.text = rule.Text;
		gameObject.SetActive(true);

		_spriteRenderer.sprite = _sprites[Random.Range(0, _sprites.Length)];
	}
}


