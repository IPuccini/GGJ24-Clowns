using System.Collections.Generic;
using UnityEngine;

public class RulesController : MonoBehaviour
{
	[SerializeField]
	private ObjectPool _rulePool;

	private readonly List<Rule> _rules = new List<Rule>();


	public void Init(RulesDataBase[] rules)
	{
		if (_rules.Count > 0)
		{
			foreach (Rule rule in _rules)
			{
				rule.gameObject.SetActive(false);
			}
			_rules.Clear();
		}

		foreach (RulesDataBase rule in rules)
		{
			Rule newRule = _rulePool.GetPooledObject().GetComponent<Rule>();
			newRule.Init(rule);
			_rules.Add(newRule);
		}
	}
}


