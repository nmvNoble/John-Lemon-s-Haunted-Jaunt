using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;

    bool m_IsPlayerAtExit;
    float m_Timer;

    [SerializeField]
    private GameObject _player; 
    [SerializeField]
    private CanvasGroup _exitBGImageCanvasGroup;

    void Update()
    {
        if (m_IsPlayerAtExit)
        {
            EndLevel();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _player)
            m_IsPlayerAtExit = true;
    }
    void EndLevel()
    {
        m_Timer += Time.deltaTime; 
        _exitBGImageCanvasGroup.alpha = m_Timer / fadeDuration;
        if (m_Timer > fadeDuration + displayImageDuration)
        {
            Application.Quit();
        }
    }
}
