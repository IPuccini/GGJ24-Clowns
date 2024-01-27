using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class RulesController : MonoBehaviour
{
	[SerializeField]
	private ObjectPool _rulePool;
	[SerializeField]
	private List<Transform> _positions;

	private readonly List<Rule> _rules = new List<Rule>();


	public void Init(RulesDataBase[] rules)
	{
		Hide();
		_positions.Shuffle();

		for (int i = 0; i < rules.Length; i++)
		{
			Rule newRule = _rulePool.GetPooledObject().GetComponent<Rule>();
			newRule.Init(rules[i]);
			newRule.transform.parent = transform;
			newRule.transform.position = _positions[i].position;
			_rules.Add(newRule);
		}
	}

	public void Hide()
	{
		if (_rules.Count > 0)
		{
			foreach (Rule rule in _rules)
			{
				rule.transform.parent = null;
				rule.gameObject.SetActive(false);
			}
			_rules.Clear();
		}
	}
}


