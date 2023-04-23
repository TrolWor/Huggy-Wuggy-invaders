using UnityEngine;
using TMPro;
public class PowerUPMaxLive : PowerUP
{
    [SerializeField]
    private float _inscrableMaxLive;
    private void Awake()
    {
        gameObject.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = "Мак.Жизни " + _inscrableMaxLive;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            _player.IncreaseMaxLife(_inscrableMaxLive);
            Destroy(gameObject);
        }
    }
}
