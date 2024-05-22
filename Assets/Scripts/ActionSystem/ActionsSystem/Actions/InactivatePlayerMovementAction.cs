using PlayerMovementScripts;
using UnityEngine;

namespace ActionSystem
{
    public class InactivatePlayerMovementAction : ActionBase
    {
        [SerializeField] GameObject _target;
        public override void Execute(object data = null)
        {
            if (_target != null)
            {
               _target.GetComponent<PlayerMovement>().enabled = false;               
            }

               

        } 
    }
}