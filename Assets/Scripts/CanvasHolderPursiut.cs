using System;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;


public class CanvasHolderPursiut : MonoBehaviour
{
    public Canvas loadingCanvasPursiut;
    public Canvas menuCanvasPursiut;
    public Canvas settingsCanvasPursiut;
    public Canvas bonusCanvasPursiut;
    public Canvas gameCanvasPursiut;
    public Canvas winCanvasPursiut;
    public Canvas loseCanvasPursiut;
    public Canvas levelsChoiceCanvasPursiut;
    public Canvas exitCanvasPursiut;
    public Canvas toMenuChoiceCanvasPursiut;
    int currentLevelPursiut = 1;

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


    public bool activePursiut = true;

    Timer tPursiut;

    public Stack<string> currentStackPursiut;


    void Start()
    {    
        menuCanvasPursiut.enabled = false; 
        settingsCanvasPursiut.enabled = false;
        CounterPursiut();
        bonusCanvasPursiut.enabled = false;
        gameCanvasPursiut.enabled = false;
        CounterPursiut(43);
        winCanvasPursiut.enabled = false;
        levelsChoiceCanvasPursiut.enabled = false;
        loseCanvasPursiut.enabled = false;
        CounterPursiut(43);
        toMenuChoiceCanvasPursiut.enabled = false;
        exitCanvasPursiut.enabled = false;
        currentStackPursiut = new Stack<string>();
        CounterPursiut();
        currentStackPursiut.Push("menuPursiut");

        HideTimerPursiut();
    }

 
    public void EndLoadPursiut()
    {
        loadingCanvasPursiut.enabled = false;
        CounterPursiut(43);
        menuCanvasPursiut.enabled = true;
        CounterPursiut(2);
    }




    public void HideTimerPursiut()
    {
        CounterPursiut(43);
        tPursiut = new Timer(1600);
        tPursiut.AutoReset = false;
        CounterPursiut(2);
        tPursiut.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        tPursiut.Start();

    }
    private async void OnTimedEvent(object? sender, ElapsedEventArgs e)
    {
       
        try
        {
             CounterPursiut(3);
            EndLoadPursiut();
        }
        finally
        {
             CounterPursiut(11);
            tPursiut.Enabled = false;
            CounterPursiut(43);
        }
    }

    public void MoveBackPursiut()
    {
        currentStackPursiut.Pop();
        CounterPursiut(43);
        MovePursiut(currentStackPursiut.Peek(), true);
    }
    public void MovePursiut(string destinationPursiut, bool backmovePursiut = false, int difPursiut =0)
    {
        if(difPursiut>0) currentLevelPursiut=difPursiut;
        menuCanvasPursiut.enabled = false;
        settingsCanvasPursiut.enabled = false;
         CounterPursiut(13);
        bonusCanvasPursiut.enabled = false;
        gameCanvasPursiut.enabled = false;
        loseCanvasPursiut.enabled = false;
        winCanvasPursiut.enabled = false;
        CounterPursiut(43);
        levelsChoiceCanvasPursiut.enabled = false;
        toMenuChoiceCanvasPursiut.enabled=false;
        CounterPursiut(43);
        exitCanvasPursiut.enabled=false;

        if (destinationPursiut == "winPursiut")
        {
            winCanvasPursiut.enabled = true;
            backmovePursiut = true;
        }

        if (destinationPursiut == "losePursiut")
        {
            loseCanvasPursiut.enabled = true;
            loseCanvasPursiut.GetComponent<WinScriptPursiut>().WinScreenPursiut();
            backmovePursiut = true;
        }


         CounterPursiut();

        if (destinationPursiut == "menuPursiut")
        {
            menuCanvasPursiut.enabled = true;
            activePursiut = false;
            currentStackPursiut.Clear();
        }
        else if (destinationPursiut == "settingsPursiut")
        {
            CounterPursiut(43);
            settingsCanvasPursiut.enabled = true;
        }
        else if (destinationPursiut == "levelsPursiut")
        {
            CounterPursiut(1);
            levelsChoiceCanvasPursiut.enabled = true;
            levelsChoiceCanvasPursiut.GetComponent<LevelScriptPursiut>().ActivateButtonsPursiut();
        }
        else if (destinationPursiut == "gamePursiut")
        {
             CounterPursiut(25);
            gameCanvasPursiut.enabled = true;          
            if (!backmovePursiut) gameCanvasPursiut.GetComponent<GameLogicPursiut>().StartGamePursiut(currentLevelPursiut);
        }
        else if (destinationPursiut == "bonusPursiut")
        {
            bonusCanvasPursiut.enabled = true;
        }
        else if (destinationPursiut == "toMenuPursiut")
        {
            toMenuChoiceCanvasPursiut.enabled = true;
        }
        else if (destinationPursiut == "exitPursiut")
        {
            CounterPursiut(43);
            exitCanvasPursiut.enabled = true;
        }
        if (!backmovePursiut) { currentStackPursiut.Push(destinationPursiut); }
         CounterPursiut();
     
    }

    void Update()
    {



        if (Application.platform == RuntimePlatform.Android)
        {
            try
            {
                if (Input.GetKey(KeyCode.Escape))
                {
                    if (currentStackPursiut.Count == 1)
                    {
                         CounterPursiut();
                        AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
                        activity.Call<bool>("moveTaskToBack", true);
                    }
                    else
                    {
                        CounterPursiut(43);
                        MoveBackPursiut();
                    }

                }
            }
            catch (Exception ePursiut)
            {
                CounterPursiut(43);
            }
        }
    }


}
