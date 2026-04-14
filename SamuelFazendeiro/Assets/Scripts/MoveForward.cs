using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveForward : MonoBehaviour
{
    public InputActionAsset inputActions;
    public InputActionMap samUiMap;
    private Animator animator;
    
    public GameObject Player;
    private TimeStop timeStop;
    public Vector3 AnimalPos;

    public bool Teleguiada;


    public float speed = 20f;
    public float stepEd;
    public float stepBuild;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        timeStop = Player.GetComponent<TimeStop>();
        samUiMap = inputActions.FindActionMap("UI");
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

    }
    
    void Movement()
    {
        if(!samUiMap.enabled)
        {
            if(gameObject.CompareTag("pizzaMark") && Teleguiada)
            {
                #if UNITY_EDITOR
                transform.position = Vector3.MoveTowards(transform.position,AnimalPos,stepEd);
                #else
                transform.position = Vector3.MoveTowards(transform.position,AnimalPos,stepEd);
                #endif
                animator.speed = 1;
            }
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            animator.speed = 1;
        }
        else
        {
            animator.speed = 0;
        }
        if(timeStop.timeStomped)
        {
            
            speed = 0;
            animator.speed = 0;
        }
        else if(!timeStop.timeStomped)
        {
            if(gameObject.tag == "pizza")
            speed = 20f;
            if(gameObject.tag == "animal")
            speed = 5f;
            animator.speed = 1;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("animal") && gameObject.CompareTag("pizza"))
        {
            gameObject.tag = "pizzaMark";
            AnimalPos = other.transform.position;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("animal") && gameObject.CompareTag("pizzaMark"))
        {
            AnimalPos = other.transform.position;
        }
    }
}
