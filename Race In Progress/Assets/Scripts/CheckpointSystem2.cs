using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSystem2 : MonoBehaviour
{
    [SerializeField]
    private GameObject point4;
    [SerializeField]
    private GameObject point5;
    [SerializeField]
    private GameObject point6;
    
    public int counter = 0;
    

    void Start()
    {
        point4.SetActive(true);
    }

    private void OnTriggerEnter(Collider checkpoint)
    {

        if (checkpoint.CompareTag("4"))   //активация финиша
        {
            point5.SetActive(true);
            point4.SetActive(false);
        }
        if (checkpoint.CompareTag("5"))  //финиш
        {
            point4.SetActive(true);
            point5.SetActive(false);
        }
        if (checkpoint.CompareTag("6"))  //wrongway
        {
            point4.SetActive(true);
            point5.SetActive(false);
        }
    }
}
