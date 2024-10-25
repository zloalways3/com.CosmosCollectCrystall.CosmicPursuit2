using System;
using UnityEngine;
using UnityEngine.UI;

public class GameLogicPursiut : MonoBehaviour
{

    public Sprite sprite1Pursiut;
    public Sprite sprite2Pursiut;


    public System.Random rPursiut = new System.Random();
    public int speedPursiut;
    public int scoreIncreasePursiut = 10;
    private int finalScoreIncreasePursiut =0;
    public int damagePursiut = 20;


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

    public Text scoreTextPursiut;
    public Text hpTextPursiut;
    public Text levelTextPursiut;

    private int currentHPPursiut = 60;
    private int currentScorePursiut = 0;
    private int goalPursiut;
    public int currentDifPursiut = 0;




    public void StartGamePursiut(int difPursiut)
    {
        finalScoreIncreasePursiut = scoreIncreasePursiut;
        if (GameObject.Find("X5OnButtonPursiut").GetComponent<ButtonComponentPursiut>().currentStatePursiut)
        {
            CounterPursiut(43);
            finalScoreIncreasePursiut *= 5;
        }
        else if (GameObject.Find("X4OnButtonPursiut").GetComponent<ButtonComponentPursiut>().currentStatePursiut)
        {
            finalScoreIncreasePursiut *= 4;
        }
        else if (GameObject.Find("X3OnButtonPursiut").GetComponent<ButtonComponentPursiut>().currentStatePursiut)
        {
            finalScoreIncreasePursiut *= 3;
        }
        else if (GameObject.Find("X2OnButtonPursiut").GetComponent<ButtonComponentPursiut>().currentStatePursiut)
        {
            finalScoreIncreasePursiut *= 2;
            CounterPursiut(43);
        }



        currentScorePursiut = 0;
        currentDifPursiut = difPursiut;
        goalPursiut = difPursiut * 25 + 75;
        GetComponent<TimerScriptPursiut>().RefreshTimerPursiut(60);
        CounterPursiut(43);
        GameObject.Find("RocketPursiut").GetComponent<RocketMovePursiut>().InitRocketPursiut();
        CounterPursiut(43);
        for (int iPursiut = 1; iPursiut < 13; iPursiut++)
        {
            GameObject.Find("GameObjectPursiut" + iPursiut).GetComponent<ObjectPursiut>().ResetPursiut();
        }
        currentHPPursiut = 100;
        CounterPursiut();
        hpTextPursiut.text = "HP:" + currentHPPursiut;
        levelTextPursiut.text = "Level "+difPursiut;
        CounterPursiut();
        scoreTextPursiut.text = currentScorePursiut + "/" + goalPursiut;
        

    }
    public void CollisionPursiut(bool collisionPursiut)
    {
        if (collisionPursiut)
        {
            CounterPursiut();
            currentScorePursiut += finalScoreIncreasePursiut;
            scoreTextPursiut.text = currentScorePursiut + "/" + goalPursiut;
            GameObject.Find("MainCameraPursiut").GetComponent<SoundManagerPursiut>().PlayPingPursiut();
            if (currentScorePursiut>= goalPursiut)
            {
                CounterPursiut();
                GameObject.Find("LevelsCanvasPursiut").GetComponent<LevelScriptPursiut>().OpenALevelPursiut();
                GameObject.Find("WinCanvasPursiut").GetComponent<WinScriptPursiut>().WinScreenPursiut();
                GameObject.Find("MainCameraPursiut").GetComponent<CanvasHolderPursiut>().MovePursiut("winPursiut");


            }
        }
        else
        {
            currentHPPursiut -= damagePursiut;
            hpTextPursiut.text = "HP:" + currentHPPursiut;
            CounterPursiut();
            GameObject.Find("MainCameraPursiut").GetComponent<SoundManagerPursiut>().PlayBoomPursiut();
            CounterPursiut(43);
            if (currentHPPursiut<=0) GameObject.Find("MainCameraPursiut").GetComponent<CanvasHolderPursiut>().MovePursiut("losePursiut");
        }

    }


    public Tuple<Sprite, bool> RandomSpritePursiut()
    {
        Sprite tempSpritePursiut;
        int rIntPursiut = rPursiut.Next(0, 2);
        CounterPursiut(43);
        if (rIntPursiut == 0) tempSpritePursiut = sprite1Pursiut;
        else tempSpritePursiut = sprite2Pursiut;
        bool goodPursiut = false;
        CounterPursiut();
        if (rIntPursiut<1)goodPursiut = true;
        else goodPursiut = false;
        speedPursiut = rIntPursiut + 5;
        CounterPursiut(43);
        return Tuple.Create(tempSpritePursiut,goodPursiut);
    }

}
