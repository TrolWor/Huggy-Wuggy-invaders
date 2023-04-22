using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class Player : MonoBehaviour
    {
        [SerializeField]
        private float _maxLife;
        [SerializeField]
        private float _life;
        public List<GameObject> Pool;
        private bool GameOn = true;
        [SerializeField]
        private float _speed = 5.0f;
        [SerializeField]
        private float _fireRate = 0.25f;
        private float _canFire = 0.0f;
        [SerializeField]
        private bool freeBullet = false;
        [SerializeField]
        private GameObject _ShootPrefab;
        private AudioSource _audioSource;
        private UIManager _uIManager;

    public void IncreaseSpeed(float value)
    {
        _speed += value;
    }
    public float GetFireRate()
    {
        return _fireRate;
    }

    public void IncreaseFireRate(float value)
    {
        _fireRate += value;
    }

    public float GetMaxLife()
        {
            return _maxLife;
        }

        public void IncreaseMaxLife(float value)
        {
            _maxLife += value;
        _uIManager.UpdateLifes(_life, _maxLife);
        }

        public float GetLife()
        {
            return _life;
        }

        public void IncreaseLife(float value)
        {
            _life += value;
        _uIManager.UpdateLifes(_life,_maxLife);
        }

        // Start is called before the first frame update
        void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            _uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
            _uIManager.UpdateLifes(GetLife(), GetMaxLife());
        }

        // Update is called once per frame
        void Update()
        {
            if (GameOn == true)
            {
                Movement();
                Shoot();
            }
        }
        private void Movement()
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate((Vector3.left * _speed) * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate((Vector3.right * _speed) * Time.deltaTime);
            }
        }
    public void Damage(float value)
    {
        _life -= value;
       // IncreaseLife(GetLife() - value);
        _uIManager.UpdateLifes(GetLife(), GetMaxLife());
    }
        private void Shoot()
        {
            if (Time.time > _canFire)
            {
                _audioSource.Play();
                for (int i = 0; i < Pool.Count; i++)
                {
                    if (!Pool[i].activeInHierarchy)
                    {
                        Pool[i].transform.position = transform.position;
                        Pool[i].SetActive(true);
                        freeBullet = true;
                    }
                
                }
                if (!freeBullet) {
                    Pool.Add(Instantiate(_ShootPrefab, transform.position + new Vector3(0, 0.9f, 0), Quaternion.identity));

                }
                 else
                {
                freeBullet = false;
                }

            _canFire = Time.time + 1/_fireRate;
            }
        }
        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("EnemyBullet")|| col.gameObject.CompareTag("Enemy"))
            {
            Damage(10f);
                //Destroy(col.gameObject);

            }
        }
    }

