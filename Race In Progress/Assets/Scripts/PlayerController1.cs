using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController1 : MonoBehaviour
{
    #region Старый код
    //public CharacterController controller;
    //public float speed = 12f;
    //public float angle = 2f;
    //public Transform body;
    //private float x;
    //private float z;
    //private float rotX = 0.0f;

    //public GameObject newBomb;
    //private bool isActive;
    ////public GameObject bomb;
    //public float delay = 3f;
    //public Transform dropSpot;
    //private bool dropped = false;
    //public float BombDelay = 5;

    //public float gravity = -10f;
    //Vector3 velocity;
    //public Transform groundCheck;
    //public float groundDistance = 0.3f;
    //public LayerMask groundMask;
    //private bool isGrounded;

    //void Start()
    //{
    //    isActive = true;
    //    Vector3 rotation = transform.localRotation.eulerAngles;
    //    rotX = rotation.x;
    //    Cursor.lockState = CursorLockMode.Locked;
    //    Cursor.visible = false;
    //}
    //void Update()
    //{
    //    if (isActive)
    //    {
    //        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    //        if (isGrounded && velocity.y < 0)
    //        {
    //            velocity.y = -2f;
    //        }

    //        if (Input.GetKey(KeyCode.W))
    //        {
    //            controller.Move(body.forward * speed * Time.deltaTime);
    //        }
    //        if (Input.GetKey(KeyCode.A))
    //        {
    //            rotX -= angle;
    //            body.rotation = Quaternion.Euler(0, rotX, 0);
    //        }
    //        if (Input.GetKey(KeyCode.D))
    //        {
    //            rotX += angle;
    //            body.rotation = Quaternion.Euler(0, rotX, 0);
    //        }

    //        if (Input.GetKey(KeyCode.S) && !dropped)
    //        {
    //            //bomb.SetActive(true);
    //            //bomb.transform.position = dropSpot.position;

    //            Rigidbody clone;
    //            clone = (Instantiate(newBomb, dropSpot.position, dropSpot.rotation)).GetComponent<Rigidbody>();

    //            dropped = true;
    //            StartCoroutine("BombDropped");
    //        }

    //        velocity.y += gravity * Time.deltaTime;
    //        controller.Move(velocity * 8f * Time.deltaTime);
    //    }
    //}
    //void OnTriggerEnter(Collider collider)
    //{
    //    if (collider.CompareTag("Bomb"))
    //    {
    //        isActive = false;
    //        StartCoroutine("Waiting");
    //    }
    //}

    //IEnumerator BombDropped()
    //{
    //    yield return new WaitForSeconds(BombDelay);
    //    dropped = false;
    //}
    //IEnumerator Waiting()
    //{
    //    yield return new WaitForSeconds(delay);
    //    isActive = true;
    //}
    #endregion

    private Rigidbody rb;
    public Transform body;
    public float speed = 100f;
    public float angle = 5f;
    private float rotX = 0.0f;

    public GameObject newBomb;
    private bool isActive;
    public float delay = 3f;
    public Transform dropSpot;
    private bool dropped = false;
    public float BombDelay = 5;
    public int bombLimit;
    private int bombCounter = 0;
    private Vector3 rotation;
    public GameObject activeBomb;
    public Text bombText;

    private void Start()
    {
        isActive = true;
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        rotation = transform.localRotation.eulerAngles;
        rotX = rotation.y;

        // Основное управление
        if (isActive)
        {
            if (Input.GetKey(KeyCode.W))
            {
                rb.velocity = body.forward * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.A))
            {
                rotX -= angle;
                rb.rotation = Quaternion.Euler(0, rotX, 0);
            }
            if (Input.GetKey(KeyCode.D))
            {
                rotX += angle;
                rb.rotation = Quaternion.Euler(0, rotX, 0);
            }
            if (Input.GetKey(KeyCode.S) && !dropped && bombCounter < bombLimit && Time.timeScale !=0) // Проверка и сброс бомбы
            {
                Rigidbody clone;
                clone = (Instantiate(newBomb, dropSpot.position, dropSpot.rotation)).GetComponent<Rigidbody>();

                dropped = true;
                activeBomb.SetActive(false);
                StartCoroutine("BombDropped");
                bombCounter++;
                bombText.text = $"{bombLimit - bombCounter}";
            }

        }
    }
    void OnTriggerEnter(Collider collider) // Столкновение с бомбой
    {
        if (collider.CompareTag("Bomb"))
        {
            isActive = false;
            StartCoroutine("Waiting");
        }
    }

    IEnumerator BombDropped() // Задержка перед броском следующей бомбы
    {
        yield return new WaitForSeconds(BombDelay);
        dropped = false;
        if (bombCounter != 5)
            activeBomb.SetActive(true);
    }
    IEnumerator Waiting() // Ожидание при поломке машины
    {
        yield return new WaitForSeconds(delay);
        isActive = true;
    }
}
