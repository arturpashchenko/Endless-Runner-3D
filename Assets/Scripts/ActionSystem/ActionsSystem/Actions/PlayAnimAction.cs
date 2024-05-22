using UnityEngine;

namespace ActionSystem {
    public class PlayAnimAction : ActionBase
    {
        [SerializeField] Animator _animator;
        [SerializeField] private string _animationName;
        public override void Execute(object data = null)
        {
            Debug.Log("Anim played");
            _animator.Play(_animationName);
        }
    }
}