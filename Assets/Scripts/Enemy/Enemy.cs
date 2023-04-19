using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField]
    private float _EnemySpeed = 5f;

    [SerializeField]
    private float _enemyHealth = 5f;

    [SerializeField]
    private int _scoreEnemy = 1;

    [SerializeField]
    private GameObject _Enemy_Explosion;
    private UIManager _uIManager;
    // Start is called before the first frame update
    void Start()
    {
        _uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((Vector3.down * _EnemySpeed) * Time.deltaTime);

        if (transform.position.y < -9.2f)
        {
            float RandomX = Random.Range(-7.6f, 7.6f);
            transform.position = new Vector3(RandomX, 6.35f, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {

            Destroy(gameObject);
            _uIManager.UpdateScore(_scoreEnemy);
        }
        if (col.CompareTag("PlayerBullet"))
        {
            _enemyHealth = _enemyHealth- col.GetComponent<Bullet>().Damage ;

            if (_enemyHealth <= 0)
            {
                _uIManager.UpdateScore(_scoreEnemy);
                Destroy(gameObject);
            }
        }
    }
    }
