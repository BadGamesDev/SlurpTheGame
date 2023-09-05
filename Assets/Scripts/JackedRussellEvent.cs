using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JackedRusselEvent : MonoBehaviour
{
    public AudioManager audioManager;
    public GameObject russellMessage;
    public bool eventHappened;

    public float coolDown;

    private void Start()
    {
        coolDown = 3;
    }

    private void FixedUpdate()
    {
        if(transform.position.x > -23.6f && eventHappened == false)
        {
            audioManager.PlayFreeze();
            russellMessage.SetActive(true);
            eventHappened = true;
        }

        if (eventHappened == true)
        {
            coolDown -= Time.deltaTime;
            if (coolDown <= 0)
            {
                russellMessage.SetActive(false);
            }
        }
    }
}
