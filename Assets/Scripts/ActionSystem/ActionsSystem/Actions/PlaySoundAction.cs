    using UnityEngine;
namespace ActionSystem {
    public class PlaySoundAction : ActionBase
    {
        [SerializeField] AudioSource _sound;
        [Header("Without AudioSource")]
        [SerializeField] bool _withoutAudioSource;
        [SerializeField] AudioClip _clip;
        [SerializeField] float _volume;
        
        public override void Execute(object data = null)
        {
            if (_withoutAudioSource) 
            {
                AudioSource.PlayClipAtPoint(_clip,transform.position,_volume);

            }
            else
           _sound.Play();
        }
    }
}
