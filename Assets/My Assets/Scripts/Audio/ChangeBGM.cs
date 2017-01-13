using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChangeBGM : MonoBehaviour 
{
    private AudioSource myAudio;
    private GameObject PM;

    public AudioClip stageClip;
    private float initialAudioVolume;
    public AudioClip introBossClip;
    private bool isIntroPlaying;
    public AudioClip loopingBossClip;
    public AudioClip gameOverClip;
    private bool isGameOver;
    public float gameOverWaitTime;
    public AudioClip winClip;
    public float winWaitTime;
    private bool isWin;

    public float fadeOutSeconds;
    //for game over text
    public Text gameOverText;
    public float gameOverTextBlinkTime;
    //for win text
    public Text winText;
    public float winTextBlinkTime;

    void Start () 
	{
        isGameOver = false;
        isWin = false;
        isIntroPlaying = false;
        myAudio = GetComponent<AudioSource>();
        initialAudioVolume = myAudio.volume;
        PM = GameObject.Find("PlayerManager").gameObject;
	}

	void Update () 
	{
        if (GameStateMachine.myGameState == GameStateMachine.GameState.BOSS && !isIntroPlaying && PM.GetComponent<PlayerLives>().playerLives >= 0)
        {
            isIntroPlaying = true;
            myAudio.loop = false;
            //play boss bgm
            StartCoroutine(SwitchBGMToBoss());
        }
        if (PM.GetComponent<PlayerLives>().playerLives < 0 && !isGameOver && GameStateMachine.myGameState == GameStateMachine.GameState.GAMEOVER)
        {
            isGameOver = true;
            //play game over bgm
            StartCoroutine(InstantSwitchBGMAndPlay(gameOverClip, gameOverWaitTime));
            //blink game over text
            StartCoroutine(BlinkText(gameOverText, gameOverTextBlinkTime, gameOverWaitTime));
            //send player to start screen
            GetComponent<LoadScenes>().StartScreen();
        }
        else if (GameStateMachine.myGameState == GameStateMachine.GameState.WIN && !isWin && PM.GetComponent<PlayerLives>().playerLives >= 0)
        {
            isWin = true;
            //play win bgm
            StartCoroutine(InstantSwitchBGMAndPlay(winClip, winWaitTime));
            //blink win text
            StartCoroutine(BlinkText(winText, winTextBlinkTime, winWaitTime));
            //send player to start screen
            GetComponent<LoadScenes>().StartScreen();
        }
	}

    IEnumerator SwitchBGMToBoss()
    {
        bool _switch = true;
        while (_switch)
        {
            _switch = false;
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
                //check if game over is true, if so, terminate script
                if (isGameOver == true)
                {
                    break;
                }
            }
            //check if game over is true, if so, terminate script
            if (isGameOver == true)
            {
                break;
            }
            //set intro boss clip
            myAudio.clip = introBossClip;
            myAudio.volume = initialAudioVolume;
            myAudio.Play();
            while (myAudio.isPlaying)
            {
                //wait until intro boss clip is finish
                yield return null;
                //check if game over is true, if so, terminate script
                if (isGameOver == true)
                {
                    break;
                }
            }
            //check if game over is true, if so, terminate script
            if (isGameOver == true)
            {
                break;
            }
            //set looping boss clip
            myAudio.clip = loopingBossClip;
            myAudio.Play();
            myAudio.loop = true;
        }
    }

    IEnumerator InstantSwitchBGMAndPlay(AudioClip myClip, float waitTime)
    {
        //stop bgm
        myAudio.Stop();
        myAudio.loop = false;
        //wait for few seconds
        yield return new WaitForSeconds(waitTime);
        //start gameover bgm
        myAudio.clip = myClip;
        myAudio.volume = initialAudioVolume;
        myAudio.Play();
    }
    
    IEnumerator BlinkText(Text myText, float blinkTime, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        for (int i = 0; i < 6; i++)
        {
            myText.gameObject.SetActive(true);
            yield return new WaitForSeconds(blinkTime);
            myText.gameObject.SetActive(false);
            yield return new WaitForSeconds(blinkTime);
        }
        myText.gameObject.SetActive(true);
    }


}
