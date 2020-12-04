using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSystem : MonoBehaviour
{
    [SerializeField]
    private GameObject point1;
    [SerializeField]
    private GameObject point2;
    [SerializeField]
    private GameObject point3;
    [SerializeField]
    private GameObject point4;
    private int counter = 0;

    void Start()
    {
        point1.SetActive(true);
    }

    private void OnTriggerEnter(Collider checkpoint)
    {
        
        if (checkpoint.CompareTag("1"))
        {
            point2.SetActive(true);
            point1.SetActive(false);
        }
        if (checkpoint.CompareTag("2"))
        {
            point3.SetActive(true);
            point2.SetActive(false);
        }
        if (checkpoint.CompareTag("3"))
        {
            point4.SetActive(true);
            point3.SetActive(false);
        }
        if (checkpoint.CompareTag("4"))
        {
            point1.SetActive(true);
            point4.SetActive(false);
            counter++;
            Debug.Log($"Rounds red = {counter}");
        }
    }


}
