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
    
    public float speed = 20f;
    // Start is called before the first frame update
    void Start()
    {
        samUiMap = inputActions.FindActionMap("UI");
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!samUiMap.enabled)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            animator.speed = 1;
        }  
        else
        {
            animator.speed = 0;
        }  
    }
}
