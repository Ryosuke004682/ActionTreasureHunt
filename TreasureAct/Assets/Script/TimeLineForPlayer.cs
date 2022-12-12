using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;

public class TimeLineForPlayer : MonoBehaviour
{
    public PlayableDirector director;
    public bool timeLine = false;
    public GameObject obj;

     void Start()
    {
        director = GetComponent<PlayableDirector>();
    }

     void Update()
    {
        obj.SetActive(false);
    }

     void OnCollisionEnter(Collision other)
    {
        if(timeLine && other.gameObject.CompareTag("Player"))
        {
            Debug.Log("ìñÇΩÇ¡ÇƒÇ‹Ç∑ÅB");
            timeLine = true;
            obj.SetActive(true);
        }
    }

    void PlayTimeLine()
    {
        director.Play();
    }
    void StopTimeLine()
    {
        director.Stop();
    }


}
