using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Parallax : MonoBehaviour
{
    [SerializeField] private GameObject _camera;
    [SerializeField] private float _parallaxEffect;

    private float _startedPosition;
    private float _lenght;

    void Start()
    {
        _startedPosition = transform.position.x;
        _lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }
  
    void Update()
    {
        float tempDistance = _camera.transform.position.x * (1 - _parallaxEffect);
        float distance = _camera.transform.position.x * _parallaxEffect;

        transform.position =new Vector3(_startedPosition * distance, transform.position.y, transform.position.z);

        if (tempDistance > _startedPosition + _lenght) _startedPosition += _lenght;
        else if (tempDistance < _startedPosition - _lenght)_startedPosition -= _lenght;        
    }
}
