using UnityEngine;

namespace ActionSystem
{
    public class CountCondition : ConditionBase
    {
        [SerializeField] private int _count;

        public override bool Check(object data = null)
        {
            return _count-- > 0;
        }
    }
}
