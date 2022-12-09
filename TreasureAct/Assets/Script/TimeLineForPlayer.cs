using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;

public class TimeLineForPlayer : MonoBehaviour
{
    public string tagName = "Player";

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == tagName)
        {
            var animPlay = other.gameObject.GetComponent<Animator>();
            animPlay.Play("Animation_1");
        }
    }
}
