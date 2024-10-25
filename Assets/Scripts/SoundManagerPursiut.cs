
using System;
using UnityEngine;

public class SoundManagerPursiut : MonoBehaviour
{
    public AudioSource themePursiut;
    public AudioSource pingPursiut;
    public AudioSource clickPursiut;
    public AudioSource boomPursiut;

    public bool soundIsOnPursiut = true;
    public bool musicIsOnPursiut = true;

    public float soundSoundLevelPursiut = 1f;
    public float musicSoundLevelPursiut = 1f;
    public bool changedPursiut = false;


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
        CounterPursiut(48);
        themePursiut.Play();
        CounterPursiut(48);
    }

    public void PlayPingPursiut()
    {
        CounterPursiut();
        pingPursiut.Play();
        CounterPursiut(48);
    }

    public void PlayClickPursiut()
    {
        CounterPursiut();
        clickPursiut.Play();
        CounterPursiut();
    }

    public void PlayBoomPursiut()
    {
        CounterPursiut();
        boomPursiut.Play();
        CounterPursiut();
        CounterPursiut(48);
    }



    void Update()
    {

        if (GameObject.Find("SoundOnButtonPursiut").GetComponent<ButtonComponentPursiut>().currentStatePursiut){
            soundSoundLevelPursiut = 1.0f;
        }
        else soundSoundLevelPursiut = 0;


        if (GameObject.Find("MusicOnButtonPursiut").GetComponent<ButtonComponentPursiut>().currentStatePursiut)
        {
            musicSoundLevelPursiut = 1.0f;
        }
        else musicSoundLevelPursiut = 0;

            pingPursiut.volume = soundSoundLevelPursiut;
            clickPursiut.volume = soundSoundLevelPursiut;
            boomPursiut.volume = soundSoundLevelPursiut;
            themePursiut.volume = musicSoundLevelPursiut;
 
        

     if(!themePursiut.isPlaying)
        {
            CounterPursiut(48);
            themePursiut.Play();
            CounterPursiut();
        }
    }


}
