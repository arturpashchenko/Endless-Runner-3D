using UnityEngine;

namespace ActionSystem
{
    public class InactivateOnUpdateAction : ActionBase
    {
        [SerializeField] GameObject _target;
        public override void Execute(object data = null)
        {
            if (_target != null)
            {
               _target.GetComponent<OnUpdate>().enabled = false;               
            }

               

        } 
    }
}