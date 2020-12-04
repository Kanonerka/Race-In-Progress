using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSystem2 : MonoBehaviour
{
    [SerializeField]
    private GameObject point5;
    [SerializeField]
    private GameObject point6;
    [SerializeField]
    private GameObject point7;
    [SerializeField]
    private GameObject point8;
    private int counter = 0;

    void Start()
    {
        point5.SetActive(true);
    }
    
    private void OnTriggerEnter(Collider checkpoint)
    {

        if (checkpoint.CompareTag("5"))
        {
            point6.SetActive(true);
            point5.SetActive(false);
        }
        if (checkpoint.CompareTag("6"))
        {
            point7.SetActive(true);
            point6.SetActive(false);
        }
        if (checkpoint.CompareTag("7"))
        {
            point8.SetActive(true);
            point7.SetActive(false);
        }
        if (checkpoint.CompareTag("8"))
        {
            point5.SetActive(true);
            point8.SetActive(false);
            counter++;
            Debug.Log($"Rounds blue = {counter}");
            if (counter > 9)
            {

            }
        }
    }
}
