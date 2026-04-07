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
    public InputActionAsset InputActions;
    public GameObject Player;
    private InputAction ghostAction;
    private IEnumerator Coroutine;
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
        if(ghostAction.WasPressedThisFrame() && !ghosting)
        {
            ghosting = true;
            Player.SetActive(false);
            StartCoroutine(Coroutine);
            
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
        ghosting = false;
        Player.SetActive(true);
    }
}
