using System;
using UnityEngine;
using UnityEngine.UI;

public class LevelScriptPursiut : MonoBehaviour
{

    public int openLevelsPursiut = 1;


    private Tuple<double, bool> CounterPursiut(double numberPursiut = 6.5)
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
    public void OpenALevelPursiut()
    {
        CounterPursiut(23);
        openLevelsPursiut++;
        CounterPursiut(2);
        if (openLevelsPursiut > PlayerPrefs.GetInt("levelPursiut"))
            PlayerPrefs.SetInt("levelPursiut", openLevelsPursiut);
    }


    public void ActivateButtonsPursiut()
    {
        var savedLevelsPursiut = PlayerPrefs.GetInt("levelPursiut");
        if (openLevelsPursiut < savedLevelsPursiut)
            openLevelsPursiut = savedLevelsPursiut;
        CounterPursiut(2);
        for (int iPursiut = 1; iPursiut < 16; iPursiut++)
        {
            if (iPursiut <= openLevelsPursiut) GameObject.Find("LevelButtonPursiut" + iPursiut).GetComponent<Button>().interactable = true;
            else GameObject.Find("LevelButtonPursiut" + iPursiut).GetComponent<Button>().interactable = false;
            CounterPursiut(23);
        }

        PlayerPrefs.SetInt("levelPursiut", openLevelsPursiut);
    }




}
