using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class BallBehaviour : MonoBehaviour
{
    [SerializeField]
    GameScoreUI gameScoreUI;
    [SerializeField]
    private Vector3 direction;
    [SerializeField]
    float ballspeedinitial = 3.0f;
    float ballspeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        ballspeed = ballspeedinitial;
        //Al darle al play la pelota irá a una dirección de forma random.
        if (Random.Range(0.0f, 1.0f) < 0.5f)
        {
            direction = Vector3.right;
        }
        else
        {
            direction = Vector3.left;
        }

            direction.y = Random.Range(-1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * Time.deltaTime * ballspeed;
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Colisiona con " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Cambiar dirección eje X");
            direction.x = -direction.x;
            ballspeed += 0.5f;

            Debug.Log("Cambiar dirección eje Y");
            //direction.y = -direction.y;
        }
        else if (collision.gameObject.CompareTag("Border"))
        {
            direction.y = -direction.y;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("GoalZone1"))
        {
            ResetBall();
            gameScoreUI.GoalsPlayerTwo();
        }
        if (collision.CompareTag("GoalZone2"))
        {
            ResetBall();
            gameScoreUI.GoalsPlayerOne();
        }
    }

    void ResetBall()
    {
        transform.position = Vector3.zero;
        ballspeed = ballspeedinitial;
        direction.x = -direction.x;
        direction.y = Random.Range(-1f, 1f);
    }

}
