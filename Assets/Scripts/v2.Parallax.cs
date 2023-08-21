using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ParallaxVersion2 : MonoBehaviour
{
    [SerializeField] private Transform _followingTarget;
    [SerializeField, Range(0f,1f)] private float _parallaxEffect;
    [SerializeField] private bool _disableVerticalParallax;

    private Vector3 _targetPreviousPosition;

    void Start()
    {
        if(!_followingTarget)
        {
            _followingTarget= Camera.main.transform;
        }

        _targetPreviousPosition= _followingTarget.position;
    }
        
    void Update()
    {
        var offset = _followingTarget.position - _targetPreviousPosition;

        if (_disableVerticalParallax)
        {
            offset.y = 0;
        }

        _targetPreviousPosition = _followingTarget.position;
        transform.position += offset * _parallaxEffect;
    }
}
