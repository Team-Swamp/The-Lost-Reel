using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndAnimationScript : MonoBehaviour
{
    [SerializeField] private float duration;

    private void Update()
    {
        duration -= Time.deltaTime;
        if (duration <= 0)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
