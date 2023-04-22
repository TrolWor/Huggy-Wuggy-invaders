using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUPSpeed : PowerUP
{
    [SerializeField]
    private float _inscrableSpeed;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            _player.IncreaseFireRate(_inscrableSpeed);
            Destroy(gameObject);
        }
    }
}
