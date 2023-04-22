using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUPFireRate : PowerUP
{
    [SerializeField]
    private float _inscrableFireRate;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            _player.IncreaseFireRate(_inscrableFireRate);
            Destroy(gameObject);
        }
    }
}
