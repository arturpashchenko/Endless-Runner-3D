using System.Collections;
using UnityEngine;

namespace ActionSystem
{
    public class SetActiveAction : ActionBase
    {
        [SerializeField] GameObject _target;
        [SerializeField] bool _isActive;
        [Tooltip("Set true if you want to Activate some object")]
        [SerializeField] float _delay;
        public override void Execute(object data = null)
        {
            if (_isActive)
            {
                StartCoroutine(SetActiveWithDelay());
            }
            else if (!_isActive)
            {
                StartCoroutine(SetInactiveWithDelay());
            }
            else return;
        }



        private IEnumerator SetInactiveWithDelay()
        {
            yield return new WaitForSeconds(_delay);
            _target.SetActive(false);
        }
        private IEnumerator SetActiveWithDelay()
        {
            yield return new WaitForSeconds(_delay);
            _target.SetActive(true);
        }
    }
}