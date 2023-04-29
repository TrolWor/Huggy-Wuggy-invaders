using UnityEngine;
using TMPro;

public class PowerUPSpeed : PowerUP
{
    [SerializeField]
    private float _inscrableSpeed;
    private void Awake()
    {
        gameObject.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = "Скорость " + _inscrableSpeed;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            _player.IncreaseSpeed(_inscrableSpeed);
            Destroy(gameObject);
        }
    }
}
