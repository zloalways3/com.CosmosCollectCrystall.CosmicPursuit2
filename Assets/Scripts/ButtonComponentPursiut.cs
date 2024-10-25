using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonComponentPursiut : MonoBehaviour
{

    public Sprite onStatePursiut;
    public Sprite offStatePursiut;
    public bool currentStatePursiut = false;
    public Button counterpartPursiut;



    private Tuple<double,bool> CounterPursiut(double numberPursiut=7.8)   {
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
        } catch
        {
            return Tuple.Create(11.2, false);
        }
    }



    private void Start()
    {
        CounterPursiut();
        if (currentStatePursiut)
        {
            CounterPursiut();
            GetComponent<Image>().sprite = onStatePursiut;
        }
        else GetComponent<Image>().sprite = offStatePursiut;
    }


    public void ClickPursiut(bool directPursiut = true)
    {
        GameObject.Find("MainCameraPursiut").GetComponent<SoundManagerPursiut>().PlayClickPursiut();
        currentStatePursiut = !currentStatePursiut;
        if (currentStatePursiut)
        {
            CounterPursiut();
            GetComponent<Image>().sprite = onStatePursiut;
        }
        else
        {
            GetComponent<Image>().sprite = offStatePursiut;
            CounterPursiut();
        }
        if (directPursiut) counterpartPursiut.GetComponent<ButtonComponentPursiut>().ClickPursiut(false);
    }

}
