using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameEnding : MonoBehaviour
{
    public float faderDuration = 1f;
    public GameObject player;
    public CanvasGroup exitBackgroundImageCanvasGroup;
    public CanvasGroup caughtBackgroundImageCanvasGroup;
    public AudioSource exitAudio;
    public AudioSource caughtAudio;
    public float displayImageDuration = 1f;

    bool m_IsPlayerAtExit = false;
    bool m_IsPlayerCaught = false;
    bool m_HasAudioPlayed = false;
    float m_Timer;

    private void Update()
    {
        if (m_IsPlayerAtExit)
        {
            EndLevel(exitBackgroundImageCanvasGroup, false, exitAudio);
        }
        else if (m_IsPlayerCaught) {
            EndLevel(caughtBackgroundImageCanvasGroup, true, caughtAudio);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player) {
            m_IsPlayerAtExit = true;
        }
    }

    void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart, AudioSource audioSource)
    {
        if (!m_HasAudioPlayed) {
            audioSource.Play();
            m_HasAudioPlayed = true;
        }
        //Debug.Log(imageCanvasGroup);
        m_Timer += Time.deltaTime;
        imageCanvasGroup.alpha = m_Timer / faderDuration;
        if (m_Timer > faderDuration + displayImageDuration) {
            if (doRestart)
            {
                SceneManager.LoadScene(0);
            }
            else {
                Application.Quit();
            }
        }
    }

    public void CaughtPlayer() {
        m_IsPlayerCaught = true;
    }
}
