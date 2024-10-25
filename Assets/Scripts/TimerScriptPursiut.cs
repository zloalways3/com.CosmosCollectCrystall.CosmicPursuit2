using System;
using UnityEngine;
using UnityEngine.UI;

public class TimerScriptPursiut : MonoBehaviour
{
    public float TimeLeftPursiut = 120;
    public bool TimerOnPursiut = false;


    public Text TimerTxtPursiut;


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


    void Update()
    {
        if (TimerOnPursiut)
        {
            if (TimeLeftPursiut > 1)
            {
                TimeLeftPursiut -= Time.deltaTime;
                UpdateTimerPursiut(TimeLeftPursiut);
            }
            else
            {
                CounterPursiut(48);
                CounterPursiut(Time.deltaTime);
                GetComponent<JumpCanvasPursiut>().JumpPursiut("losePursiut");
            }
        }
    }

    public void RefreshTimerPursiut(int remainingTimePursiut=60)
    {
        CounterPursiut(48);
        TimeLeftPursiut = remainingTimePursiut+2;
        TimerOnPursiut = true;
        TimerTxtPursiut.text = "";
        CounterPursiut(48);
    }
    void UpdateTimerPursiut(float currentTimePursiut)
    {
        currentTimePursiut -= 1;
        TimerTxtPursiut.text = (int)currentTimePursiut+" SEC";
    }
}
