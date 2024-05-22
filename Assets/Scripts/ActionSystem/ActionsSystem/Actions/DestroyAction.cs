using UnityEngine;

namespace ActionSystem
{
    public class DestroyAction : ActionBase
    {
        [SerializeField] private float _delay;
        
        [Tooltip("If true, the parent object of collided object will be destroyed.If false, the collided object will be destroyed")]
        [SerializeField] private bool _destroyParent;
        [Tooltip("If true you will destroy your object")]
        [SerializeField] private bool _destroySelectedObject;
        [SerializeField] private GameObject _objectToDestroy;

        public override void Execute(object data = null)
        {
            if (data == null)
            {
                return;
            }

            
            if(!_destroySelectedObject) 
            {
                if (data is Collider collider)
                {
                    _objectToDestroy = _destroyParent ? collider.transform.parent.gameObject : collider.gameObject;
                }
                else if (data is Collision collision)
                {
                    _objectToDestroy = _destroyParent ? collision.transform.parent.gameObject : collision.gameObject;
                    
                }

            }

            if (_objectToDestroy != null)
            {
                Destroy(_objectToDestroy, _delay);
            }
        }
    }
}
