using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Playables;

public class TimeLineForPlayer : MonoBehaviour
{
    //���̃X�N���v�g���A�^�b�`���Ă���I�u�W�F�N�g��
    //Player�^�O�������I�u�W�F�N�g���ڂ�����ATimeLine���Đ��������B

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
                Debug.Log("�������Ă邺");
                
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
