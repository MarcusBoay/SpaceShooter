using UnityEngine;
using System.Collections;

public class ChangeBGM : MonoBehaviour 
{
    private AudioSource myAudio;

    public AudioClip stageClip;
    private float initialAudioVolume;
    public AudioClip introBossClip;
    private bool isIntroPlaying = false;
    public AudioClip loopingBossClip;

    public float fadeOutSeconds;

	void Start () 
	{
        myAudio = GetComponent<AudioSource>();
        initialAudioVolume = myAudio.volume;
	}

	void Update () 
	{
        if (GameStateMachine.myGameState == GameStateMachine.GameState.BOSS && !isIntroPlaying)
        {
            isIntroPlaying = true;
            myAudio.loop = false;
            StartCoroutine(SwitchBGM());
        }
	}

    IEnumerator SwitchBGM()
    {
        //fade out bgm
        while (myAudio.volume != 0)
        {
            try
            {
                myAudio.volume -= initialAudioVolume / fadeOutSeconds * 0.1f;
            }
            catch
            {
                myAudio.volume = 0;
            }
            yield return new WaitForSeconds(0.1f);
        }
        //set intro boss clip
        myAudio.clip = introBossClip;
        myAudio.volume = initialAudioVolume;
        myAudio.Play();
        while (myAudio.isPlaying)
        {
            //wait until intro boss clip is finish
            yield return null;
        }
        //set looping boss clip
        myAudio.clip = loopingBossClip;
        myAudio.Play();
        myAudio.loop = true;
    }
}
