using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUP : MonoBehaviour
{
    [SerializeField]
    private float _powerUPSpeed = 5f;
    [HideInInspector]
    public Player _player;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("PlayerMain").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((Vector3.down * _powerUPSpeed) * Time.deltaTime);
    }
}
