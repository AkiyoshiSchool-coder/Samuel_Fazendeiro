using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Ghosting : MonoBehaviour
{
    // Variáveis;
    public bool ghosting = false;
    public float timer;
    public float timerLimit;
    public InputActionAsset InputActions;
    public GameObject Player;
    private InputAction ghostAction;
    private IEnumerator Coroutine;
    private IEnumerator Cooldown;
    // Update is called once per frame
    void Start()
    {

    }
    void Update()
    {
        Coroutine = temporizador(timer);
        ghostAct();
    }
    private void ghostAct()
    {
        if(ghostAction.WasPressedThisFrame() && !ghosting && timerLimit> 0)
        {
            ghosting = true;
            Player.SetActive(false);
        }
        else if(ghostAction.IsPressed() && ghosting && timerLimit> 0)
        {
            StartCoroutine(Coroutine);
        }
        else if(ghostAction.WasReleasedThisFrame() && ghosting || timerLimit <= 0)
        {
            ghosting = false;
            Player.SetActive(true);
            if(timerLimit < 0)
            {
                StopCoroutine(Coroutine);
                StartCoroutine(Cooldown);
            }
        }
        else if (!ghostAction.IsPressed())
        {
            if(timerLimit <2)
            {
            timerLimit += Time.deltaTime;
            }
        }
        /*
        else if(ghostAction.WasPressedThisFrame() && ghosting)
        {
            ghosting = false;
            Player.SetActive(true);
        }
        */
    }
    private void Awake()
    {
        ghostAction = InputSystem.actions.FindAction("Interact");
    }

    private IEnumerator temporizador(float ghostTime)
    {
        yield return new WaitForSeconds(ghostTime);
        timerLimit -= Time.deltaTime;
    }

    private IEnumerator Recarga(float tempo)
    {
        yield return new WaitForSeconds(tempo);
        timerLimit = 2;
    }
}
