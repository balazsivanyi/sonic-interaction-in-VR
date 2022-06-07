using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionManager : MonoBehaviour
{
    //  public static CollisionManager Instance { get; set; }
    public AudioSource playHarp;
    public FaustPlugin_BouncyHarp faustScript;
    private float[] fausOriginalParameters;
    bool _soundTriggered;
    private float[] samples;
    [SerializeField] private float soundDelay = 0.25f;
    
    /*
    private void Awake()
    {
        if (Instance == null) Instance = this;
    }
    */

    // Start is called before the first frame update
    void Start()
    {
        
        _soundTriggered = false;
        playHarp = GetComponent<AudioSource>();
        faustScript = GetComponent<FaustPlugin_BouncyHarp>();
        fausOriginalParameters = faustScript.parameters;
        //var currentInstrumentHand = _faustScript.getParameter(0);
        //faustScript.setParameter(0, 5.0f);
        // playHarp.Play();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (playHarp.clip != null)
        {
            playHarp.Play();
            samples = new float[playHarp.clip.samples * playHarp.clip.channels];
            playHarp.clip.GetData(samples, 0);
            receivedSamples = true;
        }
        */
    }
    void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.CompareTag("Hand"))
        {
            // playHarp.Play();
            if (_soundTriggered == false)
            {
                //faustScript.setParameter(0, 5.0f); 
                // playHarp.clip.SetData(samples, 0);
                //faustScript.context.process(buffer, buffer.Length / numchannels, numchannels);
                // playHarp.Stop();
                // if (buffer != null && numchannels > 0)
                // {
                //     faustScript.context.process(buffer, buffer.Length / numchannels, numchannels);
                    // playHarp.clip.SetData(buffer, 0);

                    // NOTE --> I set in OnEnabled() if BouncyHarp that it should reinitialize it
                    faustScript.enabled = false;
                    faustScript.enabled = true;
                    //Destroy(gameObject.GetComponent<FaustPlugin_BouncyHarp>());
                    //gameObject.AddComponent<FaustPlugin_BouncyHarp>();
                    //faustScript = GetComponent<FaustPlugin_BouncyHarp>();
                    /*
                    for (var index = 0; index < fausOriginalParameters.Length; index++)
                    {
                        var f = fausOriginalParameters[index];
                        faustScript.setParameter(index, fausOriginalParameters[index]);
                        // f = fausOriginalParameters[index];
                    }
                    */
                    
                    playHarp.Play();

                    // faustScript.parameters = fausOriginalParameters;
                    StartCoroutine(SoundDelay());
                // }
            
            print("The sphere was collided, sound triggered = " + _soundTriggered);

            }
            
        }
        
    }

    IEnumerator SoundDelay()
    {
        _soundTriggered = true;
        yield return new WaitForSeconds(soundDelay);
        _soundTriggered = false;
        print("Coroutine called, sound triggered = " + _soundTriggered);
    }
    
    //private void OnCollisionExit(Collision collision)
    //{
    //_soundTriggered = false;
    //Debug.Log("sound triggered set to false again");
    //}
}
