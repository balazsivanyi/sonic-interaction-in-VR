using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionManager : MonoBehaviour
{
    public AudioSource playHarp;
    public FaustPlugin_BouncyHarp faustScript;
    bool _soundTriggered;

    private float CollisionDelay;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _soundTriggered = false;
        playHarp = GetComponent<AudioSource>();
        
        //var currentInstrumentHand = _faustScript.getParameter(0);
       //faustScript.setParameter(0, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Hand"))
        {
            Debug.Log("collision detected");
            
            if (_soundTriggered == false)
            {
                faustScript.setParameter(0, 5.0f); 
                playHarp.Play();
                _soundTriggered = true;
            }
            Debug.Log("sound triggered");
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        _soundTriggered = false;
        Debug.Log("sound triggered set to false again");
    }
}
