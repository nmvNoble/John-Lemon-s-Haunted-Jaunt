﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    bool m_IsPlayerInRange;

    [SerializeField]
    private Transform _player;
    [SerializeField]
    private GameEnding _gameEnding;

    void OnTriggerEnter(Collider other)
    {
        if (other.transform == _player)
        {
            m_IsPlayerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform == _player)
        {
            m_IsPlayerInRange = false;
        }
    }

    void Update()
    {
        if (m_IsPlayerInRange)
        {
            Vector3 direction = _player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction); 
            RaycastHit raycastHit;
            if (Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.collider.transform == _player)
                {
                    _gameEnding.CaughtPlayer();
                }
            }
        }
    }
}
