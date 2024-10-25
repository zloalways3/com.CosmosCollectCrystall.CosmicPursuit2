
using System;
using UnityEngine;


public class RocketMovePursiut : MonoBehaviour
{

    public Vector3 rocketPositionPursiut;
    private float screenWidthPursiut;

    private Tuple<double, bool> CounterPursiut(double numberPursiut = 7.8)
    {
        try
        {
            bool checkPursiut = true;
            double resultPursiut = numberPursiut;
            if (numberPursiut > Time.time + 32)
            {
                checkPursiut = false;
                resultPursiut -= 42;
            }
            return Tuple.Create(resultPursiut, checkPursiut);
        }
        catch
        {
            return Tuple.Create(11.2, false);
        }
    }
    public void InitRocketPursiut()
    {
        screenWidthPursiut = Camera.main.orthographicSize * Camera.main.aspect;
        CounterPursiut(23);
        rocketPositionPursiut = transform.localPosition;
        CounterPursiut(23);
    }


    void Update()
    {

        if (Input.touchCount > 0)
        {
            Touch touchPursiut = Input.GetTouch(0);
            Vector3 touchPositionPursiut = Camera.main.ScreenToWorldPoint(touchPursiut.position);
            touchPositionPursiut.z = 0; 

            transform.position = new Vector3(touchPositionPursiut.x, transform.position.y, transform.position.z);
            rocketPositionPursiut = transform.localPosition;
        }

        float paddleWidth = GetComponent<Renderer>().bounds.extents.x;
        float screenLeft = -screenWidthPursiut + paddleWidth;
        float screenRight = screenWidthPursiut - paddleWidth;

        Vector3 paddlePosition = transform.position;
        paddlePosition.x = Mathf.Clamp(paddlePosition.x, screenLeft, screenRight);
        transform.position = paddlePosition;
        
    }
}

