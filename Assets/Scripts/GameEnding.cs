using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;

    [SerializeField]
    private GameObject _player;
    [SerializeField]
    private CanvasGroup _exitBGImageCanvasGroup;
    [SerializeField]
    private AudioSource _exitAudio;
    [SerializeField]
    private CanvasGroup _caughtBGImageCanvasGroup;
    [SerializeField]
    private AudioSource _caughtAudio;

    bool m_IsPlayerAtExit;
    bool m_IsPlayerCaught;
    float m_Timer; 
    bool m_HasAudioPlayed;

    void Update()
    {
        if (m_IsPlayerAtExit)
            EndLevel(_exitBGImageCanvasGroup, false, _exitAudio);
        else if (m_IsPlayerCaught)
            EndLevel(_caughtBGImageCanvasGroup, true, _caughtAudio);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _player)
            m_IsPlayerAtExit = true;
    }

    public void CaughtPlayer()
    {
        m_IsPlayerCaught = true;
    }

    void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart, AudioSource audioSource)
    {
        if (!m_HasAudioPlayed)
        {
            audioSource.Play(); 
            m_HasAudioPlayed = true;
        }

        m_Timer += Time.deltaTime;
        imageCanvasGroup.alpha = m_Timer / fadeDuration;

        if (m_Timer > fadeDuration + displayImageDuration)
        {
            if (doRestart)
            {
                SceneManager.LoadScene(0);
            }
            else
                Application.Quit();
        }
    }
}
