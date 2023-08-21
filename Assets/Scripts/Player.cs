using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int coinsAmount;
    [SerializeField] private AudioSource _coinSound;

    public void AddCoin()
    {
        coinsAmount++;
        _coinSound.PlayOneShot(_coinSound.clip);
    }

    private void Update()
    {
        if (transform.position.y < -1.5)
        {
            Destroy(gameObject);
        }
    }
}
