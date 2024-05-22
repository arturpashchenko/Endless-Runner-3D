using UnityEngine;

namespace ActionSystem
{
    public class ExecutorBase : MonoBehaviour
    {
        [SerializeField] private ConditionBase _condition;
        [SerializeField] private ActionBase[] _actions;

        public void Execute(object data = null)
        {
            if (_condition == null || _condition.Check(data))
            {
                foreach (var action in _actions)
                {
                  
                    action.Execute(data);
                }
            }
        }
    }
}
