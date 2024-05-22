using UnityEngine;
namespace ActionSystem
{
    public class StopSoundAction : ActionBase
    {
        [SerializeField] AudioSource _soundToStop;
        public override void Execute(object data = null)
        {
            _soundToStop.Stop();
        }
    }
}