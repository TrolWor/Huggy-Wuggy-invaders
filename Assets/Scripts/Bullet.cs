using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private readonly float _speed = 10f;
    [SerializeField]
    private int _damage;
    [SerializeField]
    private bool _playerBullet;
    public float TimeToDisable;

    public int Damage { get => _damage; set => _damage = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnEnable()
    {
        StartCoroutine(SetDisabled(TimeToDisable));
    }
    IEnumerator SetDisabled(float TimeToDisable)
    {
        yield return new WaitForSeconds(TimeToDisable);
        gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (_playerBullet)
        {
            transform.Translate(Time.deltaTime * _speed * transform.up);
        }
        else
        {
            transform.Translate(Time.deltaTime * _speed * -transform.up);
        }

    }
}
