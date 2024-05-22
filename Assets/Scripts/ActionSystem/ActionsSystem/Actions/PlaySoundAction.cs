using UnityEngine;
namespace ActionSystem {
    public class PlaySoundAction : ActionBase
    {
        [SerializeField] AudioSource _sound;
        public override void Execute(object data = null)
        {
           _sound.Play();
        }
    }
}