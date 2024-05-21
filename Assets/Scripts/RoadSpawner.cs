using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _roadPrefab;

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            Vector3 _positionToSpawn = new Vector3(this.transform.position.x + 249, _roadPrefab.transform.position.y, _roadPrefab.transform.position.z);
            Instantiate(_roadPrefab, _positionToSpawn, Quaternion.identity);
        }
    }

    
}
