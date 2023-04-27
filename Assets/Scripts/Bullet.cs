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

   // void OnEnable()
   // {
       // StartCoroutine(SetDisabled(TimeToDisable));
    //}
    //IEnumerator SetDisabled(float TimeToDisable)
    //{
       // yield return new WaitForSeconds(TimeToDisable);
        
   // }
    // Update is called once per frame
    void Update()
    {
       if( transform.position.y > 20f || transform.position.y < -20f)
        {
            gameObject.SetActive(false);
        }
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
