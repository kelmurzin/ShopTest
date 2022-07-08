using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{   
    public static TimeManager sharedInstance = null;
    private string _url = "http://worldtimeapi.org/api/timezone/Europe/Samara";
    private string _timeData;
    private string _currentTime;
    private string _currentDate;

    public IEnumerator getTime()
    {
        WWW www = new WWW(_url);
        yield return www;
        _timeData = www.text;

        string[] words = _timeData.Split(',', 'T', '"', '.', '+');
        _currentDate = words[17];
        _currentTime = words[18];
    }

    public string getCurrentDateNow()
    {
        return _currentDate;
    }

    public string getCurrentTimeNow()
    {
        return _currentTime;
    }

    private void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
        else if (sharedInstance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
   
    private void Start()=>            
        StartCoroutine("getTime");
    
}
