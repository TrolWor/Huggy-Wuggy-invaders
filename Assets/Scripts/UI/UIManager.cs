using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Image LifesImageDisplay;
    public TMP_Text LifeText;
    public TMP_Text ScoreText;

    public int Score;
    public int BestScore = 0;

    public void UpdateLifes(float CurrentLifes, float MaxLifes)
    {
        var value = CurrentLifes / MaxLifes;
        LifesImageDisplay.fillAmount = value;
        LifeText.text = "Жизни: " + CurrentLifes + "/" + MaxLifes;
    }
    public void UpdateScore(int CurrentScore)
    {
        Score += CurrentScore;
        ScoreText.text = "Очки: " + Score;
    }
}
