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

    public GameObject camera;
    public PlayableDirector director;
    public string nameTag = "Player";
    bool actChecker = false;
    bool cameraActive = true;

    private void Start()
    {
        if (actChecker == true)
            director = GetComponent<PlayableDirector>();

        if (cameraActive == false)
            camera = GetComponent<GameObject>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag(nameTag) && Input.GetKey(KeyCode.Space))
        {
                Debug.Log("当たってるぜ");
                
                TimeLineStart();
                actChecker   = true;
                cameraActive = false;
        }
        else 
        {
            TimeLineStop();
            actChecker   = false;
            cameraActive = true;
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
