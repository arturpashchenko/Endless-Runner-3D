using UnityEngine;
namespace ActionSystem
{
    public class RotateAction : ActionBase 
    { 
    
        [SerializeField] Transform _target;
        [SerializeField] float _speed;
        public override void Execute(object data = null)
        {
            _target.transform.Rotate(0, _speed, 0);
        }
    }
}