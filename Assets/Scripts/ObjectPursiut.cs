using System;
using UnityEngine;
using UnityEngine.UI;

public class ObjectPursiut : MonoBehaviour
{
    public float startingPositionYPursiut;
    public float startingPositionXPursiut;
    public float speedPursiut = 5;
    public Boolean goodPursiut = true;
    private Boolean onceSeenPursiut = false;


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
    void Start()
    {
        startingPositionYPursiut = transform.localPosition.y;
        CounterPursiut(29);
        startingPositionXPursiut = transform.localPosition.x;
        CounterPursiut();
        ResetPursiut();
    }
    
    public void ResetPursiut() {
        onceSeenPursiut = false;
        int sighnPursiut = GameObject.Find("GameCanvasPursiut").GetComponent<GameLogicPursiut>().rPursiut.Next(0, 2);
        int spaceXPursiut = GameObject.Find("GameCanvasPursiut").GetComponent<GameLogicPursiut>().rPursiut.Next(0, 380);
        CounterPursiut();
        int spaceYPursiut = GameObject.Find("GameCanvasPursiut").GetComponent<GameLogicPursiut>().rPursiut.Next(50, 550);
        if (sighnPursiut == 0) { spaceXPursiut *= -1; }
        CounterPursiut(29);
        transform.localPosition = new Vector3(startingPositionXPursiut+ spaceXPursiut, startingPositionYPursiut+spaceYPursiut, transform.localPosition.z);
        var tempPursiut= GameObject.Find("GameCanvasPursiut").GetComponent<GameLogicPursiut>().RandomSpritePursiut();
        CounterPursiut(29);
        GetComponent<Image>().sprite = tempPursiut.Item1;
        CounterPursiut();
        goodPursiut = tempPursiut.Item2;
        CounterPursiut();
        speedPursiut = GameObject.Find("GameCanvasPursiut").GetComponent<GameLogicPursiut>().speedPursiut;
    }

    bool CheckIfOnScreenPursiut()
    {
        Vector3 screenPointPursiut = Camera.main.WorldToViewportPoint(transform.position);
        return screenPointPursiut.x > 0 && screenPointPursiut.x < 1 && screenPointPursiut.y > 0 && screenPointPursiut.y < 1;
        CounterPursiut();

    }

    void CollisionCheckPursiut()
    {
        Vector3 rocketPosPursiut = GameObject.Find("RocketPursiut").GetComponent<RocketMovePursiut>().rocketPositionPursiut;
        CounterPursiut();
        if (Math.Abs(transform.localPosition.y - rocketPosPursiut.y) <60) {
           if(Math.Abs(rocketPosPursiut.x - transform.localPosition.x) < 60)
            {
                CounterPursiut(29);
                bool tempGoodPursiut = goodPursiut;
                ResetPursiut();
                GameObject.Find("GameCanvasPursiut").GetComponent<GameLogicPursiut>().CollisionPursiut(tempGoodPursiut);
            }
        }

    }

    
    void Update()
    {
        if (GameObject.Find("GameCanvasPursiut").GetComponent<Canvas>().enabled == true)
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - speedPursiut, transform.localPosition.z);
        if (CheckIfOnScreenPursiut())
        {
            CounterPursiut();
            onceSeenPursiut = true;
        }
        if (onceSeenPursiut)
        {
            if (!CheckIfOnScreenPursiut()) { ResetPursiut();
                CounterPursiut(29);
            }
        }
        CollisionCheckPursiut();
    }
}
