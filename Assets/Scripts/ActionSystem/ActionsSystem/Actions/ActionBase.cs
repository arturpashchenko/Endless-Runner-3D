using UnityEngine;

namespace ActionSystem
{
    public abstract class ActionBase : MonoBehaviour
    {
        public abstract void Execute(object data = null);
    }
}
