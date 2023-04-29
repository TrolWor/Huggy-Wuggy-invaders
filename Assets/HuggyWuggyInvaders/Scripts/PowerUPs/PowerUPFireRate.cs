using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PowerUPFireRate : PowerUP
{
    [SerializeField]
    private float _inscrableFireRate;
    private void Awake()
    {
        gameObject.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = "Скорострельность " + _inscrableFireRate;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            _player.IncreaseFireRate(_inscrableFireRate);
            Destroy(gameObject);
        }
    }

}
