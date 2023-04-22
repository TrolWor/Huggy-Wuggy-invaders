using UnityEngine;

public class PowerUPMaxLive : PowerUP
{
    [SerializeField]
    private float _inscrableMaxLive;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            _player.IncreaseMaxLife(_inscrableMaxLive);
            Destroy(gameObject);
        }
    }
}
