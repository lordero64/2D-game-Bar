using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Transform _player;

    private Vector3 _offset;

    void Start()
    {
        _offset= transform.position - _player.position;
    }

    void Update()
    {
        transform.position = _player.position + _offset;
    }
}
