using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl2 : MonoBehaviour
{
    public float speed = 20f;
        public float xRange = 25f;
    public GameObject projectilePrefab;
    public GameObject PauseMenu;
    public GameObject Soundmuel;
    

    public InputActionAsset InputActions;
    private InputAction moveAction;
    private InputAction shootAction;
    private InputAction soundAction;

    private InputAction pauseAction;
    private InputAction pauseActionM;

    void Update()
    {
         float horizontalInput = moveAction.ReadValue<Vector2>().x;
        // movimenta o player para esquerda e direita a partir da entrada do usu�rio
        transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInput);
        // mant�m o player dentro dos limites do jogo (eixo x)
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.y);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.y);
        }
        // dispara comida ao pressionar barra de espa�o
        if (shootAction.WasPressedThisFrame())
        {
            Instantiate(projectilePrefab, transform.position + new Vector3(0,2f,0), projectilePrefab.transform.rotation);
        }
        if(pauseAction.WasPressedThisFrame())
        {
            InputActions.FindActionMap("Player").Disable();
            InputActions.FindActionMap("UI").Enable();
            UiEnable();
        }
        if(pauseActionM.WasPressedThisFrame())
        {
            InputActions.FindActionMap("UI").Disable();
            InputActions.FindActionMap("Player").Enable();
            UiDisable();
        }

        
    }
    private void UiEnable()
    {
        PauseMenu.SetActive(true);
    }
    private void UiDisable()
    {
        PauseMenu.SetActive(false);
    }
    private void OnEnable()
    {
        InputActions.FindActionMap("Player").Enable();
    }
    private void OnDisable()
    {
        InputActions.FindActionMap("Player").Disable();
    }
    private void Awake()
    {
        PauseMenu = GameObject.Find("pauseMenu");
        PauseMenu.SetActive(false);
        moveAction = InputSystem.actions.FindAction("Move");
        shootAction = InputSystem.actions.FindAction("Jump");
        soundAction = InputSystem.actions.FindAction("Attack");
        pauseAction = InputSystem.actions.FindAction("Pause");
        pauseActionM = InputSystem.actions.FindAction("Unpause");
        
    }

    // public void MoveEvent(InputAction.CallbackContext context)
    // {
    //     horizontalInput = context.ReadValue<Vector2>().x;
    // }

    // public void ShootEvent(InputAction.CallbackContext context)
    // {
    //     // dispara comida ao pressionar barra de espa�o
    //     if(context.performed)
    //     {
    //         Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
    //     }
    // }
}
