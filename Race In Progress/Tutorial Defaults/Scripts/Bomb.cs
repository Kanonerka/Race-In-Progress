using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject bomb;

    void OnTriggerEnter(Collider Object)
    {
        if (Object.CompareTag("Player"))
        {
            //bomb.SetActive(false);
            Destroy(bomb);
        }
    }
}

