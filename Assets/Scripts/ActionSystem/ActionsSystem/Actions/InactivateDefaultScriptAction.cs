using System;
using UnityEngine;

namespace ActionSystem
{
    public class InactivateDefaultScriptAction : ActionBase
    {
        [SerializeField] GameObject _target;
        [SerializeField] string _nameDefaultScript;

        public override void Execute(object data = null)
        {
            if (_target != null && !string.IsNullOrEmpty(_nameDefaultScript))
            {
                Component[] components = _target.GetComponents<Component>();
                foreach (Component component in components)
                {
                    if (component.GetType().Name == _nameDefaultScript)
                    {
                        ((MonoBehaviour)component).enabled = false;
                        Debug.Log($"Component {_nameDefaultScript} on {_target.name} has been disabled.");
                        return;
                    }
                }

            }
        }
    }
}
