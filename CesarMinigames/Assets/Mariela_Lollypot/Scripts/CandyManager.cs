using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyManager : MonoBehaviour
{   
    
    private Coroutine a;
    private Vector3 newPos;

    private float speed = 0.05f;


    private void Start()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, 1.77f);
    }
    public IEnumerator CandyRotation()
    {
        Debug.Log("Checasdasdasdking: ");

        if (transform.position.y <= -1.8f)
        {
            transform.position = new Vector3(transform.position.x, 1.77f);
        }
        else {
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f);
        }

        yield return new WaitForSeconds(speed);
        a = StartCoroutine(CandyRotation());
    }

    public string StopCandy() {
        StopCoroutine(a);
        StopCoroutine(CandyRotation());
        return CorrectPosition();
    }

    public void ChangeSpeed() {
        if (speed <= 0.15f)
        {
            speed += 0.05f;
        }
    }

    public string CorrectPosition()
    {
        string image = "";
        if (transform.localPosition.y <= (-1.55f))
        {
            newPos = new Vector3(transform.localPosition.x, -1.8f, transform.localPosition.z);
            image = "palo";
        }
        else if (transform.localPosition.y > (-1.55f) && transform.localPosition.y <= (-1.05))
        {
            image = "rueda";
            newPos = new Vector3(transform.localPosition.x, -1.3f);
        }
        else if (transform.localPosition.y > (-1.05) && transform.localPosition.y <= (-0.55))
        {
            image = "tubo";
            newPos = new Vector3(transform.localPosition.x, -0.8f);
        }
        else if (transform.localPosition.y > (-0.55) && transform.localPosition.y <= (-0.05))
        {
            image = "caramelo";
            newPos = new Vector3(transform.localPosition.x, -0.3f);
        }
        else if (transform.localPosition.y > (-0.05) && transform.localPosition.y <= (0.45))
        {
            image = "judias";
            newPos = new Vector3(transform.localPosition.x, 0.2f);
        }
        else if (transform.localPosition.y > (0.45) && transform.localPosition.y <= (0.95))
        {
            image = "piruleta";
            newPos = new Vector3(transform.localPosition.x, 0.7f);
        }
        else if (transform.localPosition.y > (0.95) && transform.localPosition.y <= (1.45))
        {
            image = "huevo";
            newPos = new Vector3(transform.localPosition.x, 1.2f);
        }
        else if (transform.localPosition.y > (1.45))
        {
            image = "palo";
            newPos = new Vector3(transform.localPosition.x, 1.77f);
        }
        else {
            Debug.Log("TACA: " + transform.localPosition.y);
        }

        transform.localPosition = new Vector3(newPos.x, newPos.y);
        return image;
    }

    //public string CheckPosition() {
    //    string image = "";
    //    StartCoroutine(CorrectPosition());
    //    switch (transform.position.y)
    //    {
    //        case -1.8f:
    //            image = "palo";
    //            break;
    //        case -1.3f:
    //            image = "rueda";
    //            break;
    //        case -0.8f:
    //            image = "tubo";
    //            break;
    //        case -0.3f:
    //            image = "caramelo";
    //            break;
    //        case 0.2f:
    //            image = "judias";
    //            break;
    //        case 0.7f:
    //            image = "piruleta";
    //            break;
    //        case 1.2f:
    //            image = "huevo";
    //            break;
    //        case 1.77f:
    //            image = "palo";
    //            break;
    //        default:
                
    //            break;
    //    }
    //    return image;
    //}

}
