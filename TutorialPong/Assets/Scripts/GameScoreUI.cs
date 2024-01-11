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

    [SerializeField]
    float animationTime = 0.2f;
    [SerializeField]
    LeanTweenType animationCurve;

    public GameObject goalText;
    [SerializeField]
    float animationTimeGoal = 0.2f;
    [SerializeField]
    LeanTweenType animationCurveGoal;
    [SerializeField]
    float textPosition = 1340;
    float endAnimationPosition;

    //resetear goles
    public void ResetScore()
    {
        goalsPlayerOne = 0;
        goalsPlayerTwo = 0;
        UpdateScoreText();
    }
    //añadir goles
    //crear una función que aumente los goles de cada jugador
    public void GoalsPlayerOne()
    {
        goalsPlayerOne++;
        UpdateScoreText();
        GoalText(1);
    }
    public void GoalsPlayerTwo()
    {
        goalsPlayerTwo++;
        UpdateScoreText();
        GoalText(2);
    }
    //mostrar
    void UpdateScoreText()
    {
        LeanTween.scale(scoreText.gameObject, Vector3.zero, 0.0f);
        LeanTween.scale(scoreText.gameObject, Vector3.one, animationTime).setEase(animationCurve);
        scoreText.text = goalsPlayerOne + " : " + goalsPlayerTwo;
    }

    //Texto de gol
    void GoalText(int player)
    {
        float textInitialPosition = 0f;
        if (player == 1)
        {
            textInitialPosition = textPosition;
        }
        else
        {
            textInitialPosition = -textPosition;
        }

        endAnimationPosition -= textInitialPosition;

        LeanTween.moveLocalX(goalText, textInitialPosition, 0.0f);
        LeanTween.moveLocalX(goalText, 0.0f, 0.9f).setOnComplete(EndAnimation);
    }

    void EndAnimation()
    {
        LeanTween.scale(goalText, Vector3.one, 0.75f).setOnComplete(() =>
        {
            LeanTween.scale(goalText, Vector3.one * 1.5f, 0.75f).setEaseInBounce().setOnComplete(() =>
                {
                    LeanTween.moveLocalX(goalText, endAnimationPosition, 0.5f).setEaseInCirc();
                    LeanTween.scale(goalText, Vector3.one, 0f);
                });
        });
    }
}
