using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField]
    private float _enemySpeed = 5f;

    [SerializeField]
    private float _enemyHealth = 5f;

    [SerializeField]
    private int _scoreEnemy = 1;

    [SerializeField]
    private bool _isShoot;
    public List<GameObject> _poolBullet;
    [SerializeField]
    private float _fireRate = 0.25f;
    private float _canFire = 0.0f;
    private bool freeBullet = false;
    [SerializeField]
    private GameObject _ShootPrefab;

    [SerializeField]
    private GameObject _Enemy_Explosion;
    private UIManager _uIManager;

    public float EnemyHealth { get => _enemyHealth; }

    // Start is called before the first frame update
    void Start()
    {
        _uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((Vector3.down * _enemySpeed) * Time.deltaTime);

        
        if (_isShoot)
        {
            Shoot();
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
            _enemyHealth -= col.GetComponent<Bullet>().Damage ;

            if (_enemyHealth <= 0)
            {
                _uIManager.UpdateScore(_scoreEnemy);
                Destroy(gameObject);
            }
        }
    }
    private void Shoot()
    {
        if (Time.time > _canFire)
        {
            for (int i = 0; i < _poolBullet.Count; i++)
            {
                if (!_poolBullet[i].activeInHierarchy)
                {
                    _poolBullet[i].transform.position = transform.position;
                    _poolBullet[i].SetActive(true);
                    freeBullet = true;
                }

            }
            if (!freeBullet)
            {
                _poolBullet.Add(Instantiate(_ShootPrefab, transform.position + new Vector3(0, 0.9f, 0), Quaternion.identity));

            }
            else
            {
                freeBullet = false;
            }

            _canFire = Time.time + 1 / _fireRate;
        }
    }
}
