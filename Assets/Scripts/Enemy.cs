using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(SpriteRenderer))]

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private float _speed;
    [SerializeField] Transform[] _points;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private int _index;

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _points[_index].position, _speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, _points[_index].position) < 0.1f)
        {
            if (_index > 0)
            {
                _index = 0;
                _spriteRenderer.flipX = false;
            }
            else
            {
                _index = 1;
                _spriteRenderer.flipX = true;
            }
        }
    }
}
