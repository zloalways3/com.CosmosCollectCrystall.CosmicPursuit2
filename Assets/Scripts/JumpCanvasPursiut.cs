using System;
using UnityEngine;

public class JumpCanvasPursiut : MonoBehaviour
{
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

    public void JumpPursiut(string destinationPursiut)
    {
        CounterPursiut();
        GameObject.Find("MainCameraPursiut").GetComponent<SoundManagerPursiut>().PlayClickPursiut();
        CounterPursiut(29);
        GameObject.Find("MainCameraPursiut").GetComponent<CanvasHolderPursiut>().MovePursiut(destinationPursiut,false);
    }

    public void JumpPursiutGame(int difPursiut)
    {
       
        GameObject.Find("MainCameraPursiut").GetComponent<SoundManagerPursiut>().PlayClickPursiut();
        CounterPursiut(12);
        GameObject.Find("MainCameraPursiut").GetComponent<CanvasHolderPursiut>().MovePursiut("gamePursiut", false,difPursiut);
        CounterPursiut();
    }


    public void JumpBackPursiut()
    {
        CounterPursiut();
        GameObject.Find("MainCameraPursiut").GetComponent<SoundManagerPursiut>().PlayClickPursiut();
        CounterPursiut(29);
        GameObject.Find("MainCameraPursiut").GetComponent<CanvasHolderPursiut>().MoveBackPursiut();
        CounterPursiut();
    }

    public void ClosePursiut()
    {
        CounterPursiut(29);
        AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
        activity.Call<bool>("moveTaskToBack", true);
        CounterPursiut();
    }
}
