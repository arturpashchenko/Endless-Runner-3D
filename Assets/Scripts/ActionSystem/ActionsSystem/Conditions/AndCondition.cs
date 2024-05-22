using UnityEngine;

namespace ActionSystem
{
    public class AndCondition : ConditionBase
    {
        [SerializeField] private ConditionBase[] _conditions;

        public override bool Check(object data = null)
        {
            foreach (var condition in _conditions)
            {
                if (!condition.Check())
                {
                    return false;
                }
            }

            return true;
        }
    }
}
