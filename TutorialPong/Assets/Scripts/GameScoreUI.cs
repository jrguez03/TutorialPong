using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameScoreUI : MonoBehaviour
{
    //goles jugador 1
    int goalsPlayerOne;
    //goles jugador 2
    int goalsPlayerTwo;

    public TextMeshProUGUI scoreText;

    //resetear goles
    public void ResetScore()
    {
        goalsPlayerOne = 0;
        goalsPlayerTwo = 0;
        UpdateScoreText();
    }
    //a�adir goles
    //crear una funci�n que aumente los goles de cada jugador
    public void GoalsPlayerOne()
    {
        goalsPlayerOne++;
        UpdateScoreText();
    }
    public void GoalsPlayerTwo()
    {
        goalsPlayerTwo++;
        UpdateScoreText();
    }
    //mostrar
    void UpdateScoreText()
    {
        scoreText.text = goalsPlayerOne + " : " + goalsPlayerTwo;
    }
}
