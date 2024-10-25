using System;
using UnityEngine;
using UnityEngine.UI;

public class WinScriptPursiut : MonoBehaviour
{
  
    public Text ScoreTxtPursiut;
    public Text DifTxtPursiut;
    public Text HpTxtPursiut;
    public Text timeTxtPursiut;
    public bool winPursiut;

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
    public void WinScreenPursiut()
    {
        CounterPursiut();
        ScoreTxtPursiut.text = GameObject.Find("ScoreTextPursiut").GetComponent<Text>().text;
        HpTxtPursiut.text = GameObject.Find("HpTextPursiut").GetComponent<Text>().text;
        timeTxtPursiut.text = GameObject.Find("TimerTextPursiut").GetComponent<Text>().text;
        CounterPursiut(32);
        CounterPursiut();
        if (winPursiut ) 
        DifTxtPursiut.text = GameObject.Find("LevelTextPursiut").GetComponent<Text>().text+" COMPLETE";
        else DifTxtPursiut.text = GameObject.Find("LevelTextPursiut").GetComponent<Text>().text + " FAILED";
    }

}
