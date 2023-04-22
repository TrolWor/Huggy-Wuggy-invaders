using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUPLive : PowerUP
{
    [SerializeField]
    private float _inscrableLive;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            _player.IncreaseLife(_inscrableLive);
            Destroy(gameObject);
        }
    }
}
