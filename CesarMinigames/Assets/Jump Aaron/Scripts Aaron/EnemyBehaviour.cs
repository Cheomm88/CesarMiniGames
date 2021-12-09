using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public GameObject[] enemigos;

    public Vector3 targetPosition = new Vector3(-1.5f, 0f, 0f);
    public bool isMoving;

    //Dificultad
    public float speed = 2f;
    public float levelFactor = 1f;
    public float timeInLevel = 0;

    public bool reverse = false;
    public float screenSpeed = 0;

    private float targetDirection;
    int enemyIndex;

    float originPosition;


    // Start is called before the first frame update
    void Start()
    {
        SelectEnemy();
        //enemigos = GameObject.FindGameObjectsWithTag("Enemigos");
    }

    // Update is called once per frame
    void Update()
    {
        timeInLevel += Time.deltaTime;

        if (isMoving)
        {
            Rigidbody2D rb = enemigos[enemyIndex].GetComponent<Rigidbody2D>();
            rb.MovePosition(rb.position + new Vector2(targetDirection, 0) * speed * Time.fixedDeltaTime);
            if ((enemigos[enemyIndex].transform.position.x >= 0 && targetDirection == 1) ||
                (enemigos[enemyIndex].transform.position.x <= 0 && targetDirection == -1))
            {
                reverse = true;
                isMoving = false;
                Debug.Log("Enemigo >" + enemyIndex + " va hacia atras");
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
                Debug.Log("Enemigo >" + enemyIndex + " se para");
            }
        }
        else
        {
            enemigos[enemyIndex].transform.position = new Vector3(originPosition, enemigos[enemyIndex].transform.position.y, enemigos[enemyIndex].transform.position.z);
            SelectEnemy();
        }
    }

    private void SelectEnemy()
    {
        enemyIndex = Random.Range(0, enemigos.Length);
        originPosition = enemigos[enemyIndex].transform.position.x;
        targetDirection = originPosition < 0 ? 1 : -1;
        isMoving = true;

        Debug.Log("Enemigo >" + enemyIndex + " va hacia delante");
    }
}

