using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Сountdown : MonoBehaviour
{
    private float pauseTime;
    void Start()
    {
        StartCoroutine("StartDelay");
    }

    IEnumerator StartDelay()
    {
        Time.timeScale = 0;
        pauseTime = Time.realtimeSinceStartup + 3f;
        while (Time.realtimeSinceStartup < pauseTime)
            yield return 0;
        Time.timeScale = 1;
    }
}
