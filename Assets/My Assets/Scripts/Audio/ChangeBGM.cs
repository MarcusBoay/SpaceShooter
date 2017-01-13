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

    public float fadeOutSeconds;
    //for game over text
    public Text gameOverText;
    public float gameOverTextBlinkTime;

    void Start () 
	{
        isGameOver = false;
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
            StartCoroutine(PlayGameOver());
            //blink game over text
            StartCoroutine(BlinkGameOverText());
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

    IEnumerator PlayGameOver()
    {
        //stop bgm
        myAudio.Stop();
        myAudio.loop = false;
        //wait for few seconds
        yield return new WaitForSeconds(2.5f);
        //start gameover bgm
        myAudio.clip = gameOverClip;
        myAudio.volume = 1;
        myAudio.Play();
    }
    
    public IEnumerator BlinkGameOverText()
    {
        yield return new WaitForSeconds(2.5f);
        for (int i = 0; i < 6; i++)
        {
            gameOverText.gameObject.SetActive(true);
            yield return new WaitForSeconds(gameOverTextBlinkTime);
            gameOverText.gameObject.SetActive(false);
            yield return new WaitForSeconds(gameOverTextBlinkTime);
        }
        gameOverText.gameObject.SetActive(true);
    }
}
