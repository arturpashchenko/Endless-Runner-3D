using UnityEngine;
namespace ActionSystem
{
    public class MoveAction : ActionBase
    {
        [SerializeField] private float _movementSpeed;
        [SerializeField] GameObject _target;
        public override void Execute(object data = null)
        {
            _target.transform.position += new Vector3(-_movementSpeed, 0, 0) * Time.deltaTime;
        }
    }
}