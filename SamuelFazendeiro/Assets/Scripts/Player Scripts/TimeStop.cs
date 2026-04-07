using System;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class TimeStop : MonoBehaviour
{

    public bool cooldown = true;
    public bool timeStomped = false;
    public InputActionAsset InputActions;
    private InputAction interactAction;
    private IEnumerator Coroutine;
    public GameObject painel;

    public GameObject SpawnManager;
    private SpawnManager spawnManager;

    void Awake()
    {
        spawnManager = SpawnManager.GetComponent<SpawnManager>();
        interactAction = InputSystem.actions.FindAction("Attack");
        painel.SetActive(false);
        Coroutine = temporizador();
    }


    void Update()
    {
        if(interactAction.WasPressedThisFrame() && cooldown)
        {
            TimeStoping();
        }
    }

    void TimeStoping()
    {
        
        StartCoroutine(Coroutine);
        Coroutine = Cooldown();
        StartCoroutine(Coroutine);
    }

    private IEnumerator temporizador()
    {
        timeStomped = true;
        painel.SetActive(true);
        spawnManager.CancelSpawn();
        yield return new WaitForSeconds(5);
        spawnManager.InvokeAnimals();
        painel.SetActive(false);
        timeStomped = false;
        cooldown = false;
    }
    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(10);
        cooldown = true;
        Coroutine = temporizador();
    }
}
