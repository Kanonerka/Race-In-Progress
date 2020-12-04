using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score2 : MonoBehaviour
{
    public int counter = 0;
    public GameObject win;
    public Text score;
    public GameObject Musicplayer;
    
    private void OnTriggerEnter(Collider checkpoint)
    {
        if (checkpoint.CompareTag("5"))
        {
            counter++;
            Debug.Log($"Rounds blue = {counter}");
            if (counter == 10)
            {
                Musicplayer.SetActive(false);
                win.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0;
            }
        }
    }
    public void Update()
    {
        score.text = $"{ counter}";
    }
}
