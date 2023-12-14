using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    [SerializeField]
    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        //Al darle al play la pelota irá a una dirección de forma random.
        if (Random.Range(0.0f, 1.0f) < 0.5f)
        {
            direction = Vector3.right;
        }
        else
        {
            direction = Vector3.left;
        }

        if (Random.Range(0.0f, 1.0f) < 0.5f)
        {
            //direction += Vector3.up;
        }
        else
        {
            //direction += Vector3.down;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Colisiona con " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Cambiar dirección eje X");
            direction.x = -direction.x;

            Debug.Log("Cambiar dirección eje Y");
            direction.y = -direction.y;
            direction.y = Random.Range(-1f, 1f);
        }
    }

}
