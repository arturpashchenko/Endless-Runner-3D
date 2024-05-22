using UnityEngine;
namespace ActionSystem
{
    public class TeleportationAction : ActionBase
    {
        [SerializeField] GameObject _target;
        [SerializeField] Vector3 _position;
        public override void Execute(object data = null)
        {
            Debug.Log("Worked");
            _target.transform.position = _position; _target.transform.rotation = Quaternion.identity;
        }
    }
}