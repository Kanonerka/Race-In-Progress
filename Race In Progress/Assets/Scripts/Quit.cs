using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    public GameObject Esc;
    public GameObject Musicplayer;    
    

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Esc.SetActive(true);
            Musicplayer.SetActive(false);
            
            // Вызов метода остановки времени
            StartCoroutine("pause");

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
    }

    // Остановка времени
    IEnumerator pause()
    {
        // Включение нормального хода времени
        Time.timeScale = 0;
        gameObject.SetActive(false);
        yield return 0;
    }
    
}
