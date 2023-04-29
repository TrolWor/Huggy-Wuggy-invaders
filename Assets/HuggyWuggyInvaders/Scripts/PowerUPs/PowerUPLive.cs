using UnityEngine;
using TMPro;

public class PowerUPLive : PowerUP
{
    [SerializeField]
    private float _inscrableLive;
    private void Awake()
    {
        gameObject.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = "Жизни " + _inscrableLive;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            _player.IncreaseLife(_inscrableLive);
            Destroy(gameObject);
        }
    }
}
