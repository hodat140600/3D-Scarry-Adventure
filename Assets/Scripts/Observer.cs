﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public Transform player;
    public GameEnding gameEnding;

    bool m_IsPlayerInRange;

    private void Update()
    {
        if (m_IsPlayerInRange) {
            Vector3 direction = player.position - transform.position + Vector3.up;
            RaycastHit rayCastHit;
            Ray ray = new Ray(transform.position, direction);
            if (Physics.Raycast(ray, out rayCastHit)) {
                if (rayCastHit.collider.transform == player) {
                    gameEnding.CaughtPlayer();
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == player) {
            m_IsPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = false;
        }
    }
}
