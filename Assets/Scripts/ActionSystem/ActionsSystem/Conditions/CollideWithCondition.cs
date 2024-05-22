using UnityEngine;
namespace ActionSystem
{
    public class CollideWithCondition : ConditionBase
    {
        [SerializeField] LayerMask _mask;
        [SerializeField] private string _tag;
        [SerializeField] private bool _maskAndTag;
        public override bool Check(object data = null)
        {
            if (data == null)
            {
                return false;
            }
            else if (data is Collider collider)
            {
                
                bool resultOfMask = _mask == (_mask | (1 << collider.gameObject.layer));
                bool resulOfTag = _tag == collider.gameObject.tag;

                if (_maskAndTag)
                return resultOfMask && resulOfTag;

                else
                return resultOfMask || resulOfTag;
            }
            else if (data is Collision collision)
            {
                bool resultOfMask = _mask == (_mask | (1 << collision.gameObject.layer));
                bool resulOfTag = _tag == collision.gameObject.tag;

                if (_maskAndTag)
                return resultOfMask && resulOfTag;

                else
                return resultOfMask || resulOfTag;
            }
            return false;
        }
    }
}