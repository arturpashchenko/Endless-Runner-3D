using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace ActionSystem
{
    public class AddNumberAction : ActionBase
    {
        [SerializeField] TMP_Text[] _texts;
        private int _counter;
        [HideInInspector] public int CounterOfCoins;
        [HideInInspector] public int CounterOfScore;
        public override void Execute(object data = null)
        {
            _counter++;
            for (int i = 0; i < _texts.Length; i++)
            {
                _texts[i].SetText(_counter.ToString());
            }
              
            CounterOfCoins = _counter;
            CounterOfScore = _counter;
        }
    }
}