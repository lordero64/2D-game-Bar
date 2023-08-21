using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

[RequireComponent(typeof(SpriteRenderer))]

public class EnemyCoroutine : MonoBehaviour
{
    [SerializeField] private float _Health;
    [SerializeField] private float _speed;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] Transform[] _points = new Transform[2];

    private Coroutine _coroutine;

    void Start()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(Patrol());

        if (_Health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator Patrol()
    {
        while (true)
        {
            yield return MoveTo(_points[1].position);
            _spriteRenderer.flipX = true;

            yield return MoveTo(_points[0].position);
            _spriteRenderer.flipX = false;
        }
    }

    private IEnumerator MoveTo(Vector3 target)
    {
        while (transform.position != target)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * _speed);

            yield return null;
        }
    }
}
