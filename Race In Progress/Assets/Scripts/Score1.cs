using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score1 : MonoBehaviour
{
    public int counter = 0;
    public GameObject win;
    public Text score;
    public GameObject Musicplayer;
    

    public void Update()
    {
        score.text = $"{ counter}";
        //Press F to win
        if (Input.GetKeyDown(KeyCode.F))
        {
            counter = 9;
        }


    }
    private void OnTriggerEnter(Collider checkpoint)
    {
        if (checkpoint.CompareTag("2"))
        {
            counter++;
            Debug.Log($"Rounds red = {counter}");
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
    
}
