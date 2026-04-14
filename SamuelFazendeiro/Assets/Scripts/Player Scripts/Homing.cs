using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;
using System;

public class Homing : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private IEnumerator Coroutine;
    private IEnumerator Cooldown;
    public bool homing;
    public bool cooldown = true;
    public InputActionAsset InputActions;
    private InputAction homingAction;
    private PlayerControl2 playercontrol;
    private TimeStop timestop;

    public GameObject blablabla;
    
    void Awake()
    {
        homingAction = InputSystem.actions.FindAction("Homing");
        playercontrol = GetComponent<PlayerControl2>();
        timestop = GetComponent<TimeStop>();
    }

    // Update is called once per frame
    void Update()
    {
        Coroutine = TeleTime();
        if(homingAction.WasPressedThisFrame() && cooldown && !timestop.timeStomped)
        {
        Teleguiar();
       // blablabla.SetActive(true);
        }
    }
    private IEnumerator TeleTime()
    {
        homing = true;
        playercontrol.teleguiar = true;
        yield return new WaitForSeconds(5);
        //blablabla.SetActive(false);
        playercontrol.teleguiar = false;
        homing = false;
        cooldown = false;
    }
    private IEnumerator TelegCooldown()
    {
        yield return new WaitForSeconds(10);
        cooldown = true;
    }
    private void Teleguiar()
    {
        StartCoroutine(Coroutine);     
        Cooldown = TelegCooldown();
        StartCoroutine(Cooldown);
    }
}
