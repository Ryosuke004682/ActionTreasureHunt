using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Playables;

public class TimeLineForPlayer : MonoBehaviour
{
    //このスクリプトがアタッチしているオブジェクトに
    //Playerタグがついたオブジェクトが接したら、TimeLineを再生したい。

    public PlayableDirector director;
    public string nameTag = "Player";
    bool actChecker = false;
    

    private void Start()
    {
        if (actChecker == true)
            director = GetComponent<PlayableDirector>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag(nameTag) && Input.GetKey(KeyCode.Space))
        {
                Debug.Log("当たってるぜ");
                
                TimeLineStart();
                actChecker   = true;
                
        }
        else 
        {
            TimeLineStop();
            actChecker   = false;
            
        }
    }


    void TimeLineStart()
    {
        director.Play();
    }

    void TimeLineStop()
    {
        director.Stop();
    }


}
