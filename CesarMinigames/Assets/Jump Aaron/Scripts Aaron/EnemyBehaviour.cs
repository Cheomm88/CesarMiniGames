using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public GameObject[] enemigos;

    public Vector3 targetPosition = new Vector3(-1.5f, 0f, 0f);
    public bool isMoving;

    //Dificultad
    public float speed;
    public float levelFactor = 1f;
    public float timeInLevel = 0;

    public bool reverse = false;
    public float screenSpeed = 0;

    private float targetDirection;
    int enemyIndex = 0;

    float originPosition = 1;

    bool gameInitialized;
    //public GameObject pajaroPosition;


    // Start is called before the first frame update
    void Start()
    {
        //yield return new WaitForSeconds(1);

        SelectEnemy(); //Inicia el movimiento de los enemigos
        //enemigos = GameObject.FindGameObjectsWithTag("Enemigos");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.instance.isPlaying)
        {
            if (isMoving)
            {
                Rigidbody2D rb = enemigos[enemyIndex].GetComponent<Rigidbody2D>();
                rb.MovePosition(rb.position + new Vector2(targetDirection, 0) * speed * Time.fixedDeltaTime);
                if ((enemigos[enemyIndex].transform.position.x >= 0 && targetDirection == 1) || //Determina hacia que direcci?n se mueven los enemigos en funci?n de su posici?n inicial.
                    (enemigos[enemyIndex].transform.position.x <= 0 && targetDirection == -1))
                {
                    reverse = true;
                    isMoving = false;
                    enemigos[enemyIndex].transform.Rotate(180, 0, 180);
                    //Debug.Log("Enemigo >" + enemyIndex + " va hacia atras"); xxxxxxx
                }
            }
            else if (reverse)
            {
                Rigidbody2D rb = enemigos[enemyIndex].GetComponent<Rigidbody2D>();
                rb.MovePosition(rb.position + new Vector2(-1 * targetDirection, 0) * speed * Time.fixedDeltaTime);
                if ((enemigos[enemyIndex].transform.position.x <= originPosition && targetDirection == 1) ||
                    (enemigos[enemyIndex].transform.position.x >= originPosition && targetDirection == -1))
                {
                    reverse = false;
                    //Debug.Log("Enemigo >" + enemyIndex + " se para"); xxxxxxxx
                    enemigos[enemyIndex].transform.Rotate(0, 0, 0);
                    enemigos[enemyIndex].transform.Rotate(180, 0, 180);
                }
            }
            else
            {
               //enemigos[enemyIndex].transform.position = new Vector3(originPosition, enemigos[enemyIndex].transform.position.y, enemigos[enemyIndex].transform.position.z);
                SelectEnemy();
            }
        }   
    }

    private void SelectEnemy()
    {
        if (GameController.instance.isPlaying)// && gameInitialized == false)
        {
            enemyIndex = Random.Range(0, enemigos.Length);
            originPosition = enemigos[enemyIndex].transform.position.x;
            targetDirection = originPosition < 0 ? 1 : -1;
            isMoving = true;
        }
       
        //enemigos[enemyIndex].transform.Rotate(180, 0, 180);
        //Debug.Log("Enemigo >" + enemyIndex + " va hacia delante");    xxxxxxxxx
        //CheckPosition();
        /*if(enemigos[enemyIndex] = 6 || 7)
        {
            Rigidbody2D rb = enemigos[enemyIndex].GetComponent<Rigidbody2D>();
            rb.MovePosition(rb.position + new Vector2(targetDirection, 0) * (speed *2) * Time.fixedDeltaTime);
        }*/
    }

    /*public void CheckPosition()
    {
        if ((enemigos[enemyIndex].transform.position != originPosition))
        {
            enemigos[enemyIndex].transform.position = originPosition;
            Debug.Log("Se ha corregido la posici?n de un enemigo");
        }
        
    }*/
}

