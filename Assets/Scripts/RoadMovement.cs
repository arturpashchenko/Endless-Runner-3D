using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadMovement : MonoBehaviour
{
    [SerializeField] public float _movementSpeed;
    void Update()
    {
        transform.position += new Vector3(-_movementSpeed, 0, 0) * Time.deltaTime; 
    }
}
