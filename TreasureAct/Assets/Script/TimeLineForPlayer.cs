using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;

public class TimeLineForPlayer : MonoBehaviour
{

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            var anim = other.gameObject.AddComponent<Animator>();
            anim.Play("Animation_1");
        }
        else
        {
           // Destroy(other.gameObject.Animator);
        }
    }
}
