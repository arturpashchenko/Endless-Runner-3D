using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ActionSystem
{
    public class LoadAnotherSceneAction : ActionBase
    {
        [SerializeField] private float _delay;
        [SerializeField] private string _sceneName;
        public override void Execute(object data = null)
        {
            StartCoroutine(LoadWithDelay());
        }

        IEnumerator LoadWithDelay()
        {
            yield return new WaitForSeconds(_delay);
            if (_sceneName != null)
            {
                SceneManager.LoadScene(_sceneName);
            }
            else Debug.Log("Name = null");
        }
    }
}