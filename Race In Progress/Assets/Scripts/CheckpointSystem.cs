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
    public int counter = 0;
    

    void Start()
    {
        point1.SetActive(true);  
        //активирует первый чекпоинт
    }

    private void OnTriggerEnter(Collider checkpoint)
    {
        
        if (checkpoint.CompareTag("1"))   //активация финиша
        {
            point2.SetActive(true);
            point1.SetActive(false);
        }
        if (checkpoint.CompareTag("2"))  //финиш
        {
            point1.SetActive(true);
            point2.SetActive(false);
        }
        if (checkpoint.CompareTag("3"))  //wrongway
        {
            point1.SetActive(true);
            point2.SetActive(false);
        }
        

    }


}
