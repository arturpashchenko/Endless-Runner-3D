using UnityEngine;
using System.Collections.Generic;

namespace ActionSystem
{
    public class SpawnerAction : ActionBase
    {
        [SerializeField] private GameObject[] _objectsToSpawn;
        [SerializeField] private Vector3 _positionToSpawn;
        [SerializeField] private GameObject _parent;
        [SerializeField] private bool _isSpawnAllObjects;
        [Header("For random spawn")]
        [SerializeField] private bool _isRandom = false;
        [SerializeField] private bool _avoidSamePosition = false; 
        [SerializeField] private float _firstX;
        [SerializeField] private float _secondX;
        [SerializeField] private int[] _ZPositions;
        [SerializeField] private float _minDistanceX = 10f; 

        private List<Vector3> _previousSpawnPositions = new List<Vector3>(); 

        GameObject _spawnedObject;

        public override void Execute(object data = null)
        {
            if (_objectsToSpawn != null && !_isRandom)
            {
                int _randomObject = Random.Range(0, _objectsToSpawn.Length);
                _spawnedObject = Instantiate(_objectsToSpawn[_randomObject], _positionToSpawn, Quaternion.identity);

                if (_parent != null)
                {
                    _spawnedObject.transform.parent = _parent.transform;
                }
            }
            else if (_objectsToSpawn != null && _isRandom)
            {
                if (_ZPositions != null && _ZPositions.Length > 0)
                {
                    Vector3 spawnPosition;
                    int randomIndex;
                    float _randomPositionX;
                    int _randomPositionZ;
                    int _randomObject;

                    for (int i = 0; i < (_isSpawnAllObjects ? _objectsToSpawn.Length : 1); i++)
                    {
                        do
                        {
                            randomIndex = Random.Range(0, _ZPositions.Length);
                            _randomPositionX = Random.Range(_firstX, _secondX);
                            _randomPositionZ = _ZPositions[randomIndex];
                            spawnPosition = new Vector3(_randomPositionX, 0, _randomPositionZ);
                        }
                        while (_avoidSamePosition && IsPositionTooClose(spawnPosition));

                        _previousSpawnPositions.Add(spawnPosition);

                        _randomObject = Random.Range(0, _objectsToSpawn.Length);

                        _spawnedObject = Instantiate(_objectsToSpawn[_randomObject], spawnPosition, Quaternion.identity);
                        if (_parent != null)
                        {
                            _spawnedObject.transform.parent = _parent.transform;
                        }
                    }
                }
            }
        }

        private bool IsPositionTooClose(Vector3 newPosition)
        {
            foreach (var position in _previousSpawnPositions)
            {
                if (Mathf.Abs(newPosition.x - position.x) < _minDistanceX)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
