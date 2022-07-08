using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DailyReward : MonoBehaviour
{    
    public Text timeLabel;    
    private string EndTime;
    private string Timeformat;
    private double tcounter;
    
    private TimeSpan eventEndTime;
    private TimeSpan currentTime;
    private TimeSpan _remainingTime;
        
    private bool timerSet;    
    private bool countIsReady2;

    [SerializeField] private string ProductID;
    [SerializeField] private Shop shop;
    
    public void StartTimeForItem()
    {
        StartCoroutine("CheckTime");
        currentTime = TimeSpan.Parse(TimeManager.sharedInstance.getCurrentTimeNow());
        eventEndTime = currentTime + TimeSpan.FromHours(2);
        EndTime = Convert.ToString(eventEndTime);
        PlayerPrefs.SetString("EndTime", EndTime);
                
    }

    public string GetRemainingTime(double x)
    {
        TimeSpan tempB = TimeSpan.FromMilliseconds(x);
        Timeformat = string.Format("{0:D2}:{1:D2}:{2:D2}", tempB.Hours, tempB.Minutes, tempB.Seconds);
        return Timeformat;
    }

    private void Start()
    {
        if (PlayerPrefs.GetString("EndTime") != "")
            eventEndTime = TimeSpan.Parse(PlayerPrefs.GetString("EndTime"));

        if (PlayerPrefs.GetInt(ProductID, 0) != 0)
            StartCoroutine("CheckTime");
    }

    private IEnumerator CheckTime()
    {
        
        yield return StartCoroutine(TimeManager.sharedInstance.getTime());
        updateTime();        

    }

    private void updateTime()
    {
        currentTime = TimeSpan.Parse(TimeManager.sharedInstance.getCurrentTimeNow());
        timerSet = true;        
    }

    private void Update()
    {
        if (timerSet)
        {
            if (currentTime <= eventEndTime)
            {
                _remainingTime = eventEndTime.Subtract(currentTime);
                tcounter = _remainingTime.TotalMilliseconds;
                countIsReady2 = true;

            }

            else
            {
                disableButton("The duration of the item is over");
            }
        }

        if (countIsReady2) { startCountdown2(); }

    }
            
    private void startCountdown2()
    {
        timerSet = false;
        tcounter -= Time.deltaTime * 1000;
        enableButton(" Item is available during : " + GetRemainingTime(tcounter));

        if (tcounter <= 0)
        {
            countIsReady2 = false;
            validateTime();
        }
    }
   
    private void enableButton(string x)=>   
        timeLabel.text = x;
        
    private void disableButton(string x)
    {        

        PlayerPrefs.SetInt(ProductID, 0);
        shop.CheckActivateItem();       
        timeLabel.text = x;

    }
    
    private void validateTime()=>            
        StartCoroutine("CheckTime");
    
}