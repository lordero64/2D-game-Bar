using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{    
    [SerializeField] private AudioSource _coinSound;

    private int _coinsAmount;
    private double _fallLevel = -1.5;

    public void AddCoin()
    {
        _coinsAmount++;
        _coinSound.PlayOneShot(_coinSound.clip);
    }

    private void Update()
    {
        if (transform.position.y < _fallLevel)
        {
            Destroy(gameObject);
        }
    }
}
