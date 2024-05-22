using UnityEngine;

namespace ActionSystem
{
    public class SpawnerAction : ActionBase
    {
        [SerializeField] private GameObject[] _objectsToSpawn;
        [SerializeField] private Vector3 _positionToSpawn;
        [SerializeField] private GameObject _parent;
        [Header("For random spawn")]
        [SerializeField] private bool _isRandom = false;
        private int _randomObject;
        private int _counter;
        private int _usedVariant = -1; 
        private GameObject _spawnedObject;

        public override void Execute(object data = null)
        {
            if (_objectsToSpawn != null && !_isRandom)
            {
                if (_counter >= _objectsToSpawn.Length)
                {
                    _counter = 0; 
                }

                _spawnedObject = Instantiate(_objectsToSpawn[_counter], _positionToSpawn, Quaternion.identity);
                _counter++;
                if (_parent != null)
                {
                    _spawnedObject.transform.parent = _parent.transform;
                }
            }
            else if (_objectsToSpawn != null && _isRandom)
            {
                int attempts = 0;
                do
                {
                    _randomObject = Random.Range(0, _objectsToSpawn.Length);
                    attempts++;
                } while (_randomObject == _usedVariant && attempts < 100);

                _usedVariant = _randomObject;
                _spawnedObject = Instantiate(_objectsToSpawn[_randomObject], _positionToSpawn, Quaternion.identity);
                if (_parent != null)
                {
                    _spawnedObject.transform.parent = _parent.transform;
                }
            }
        }
    }
}
