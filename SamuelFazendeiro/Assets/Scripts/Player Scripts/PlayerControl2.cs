using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl2 : MonoBehaviour
{
    //Variáveis
    public float speed;
    public float xRange;
    public int PizzaC;
    public bool teleguiar;
    public PlayerStats playerstats;
    public MoveForward pizzaMove;

    private Ghosting ghost;

    public GameObject projectilePrefab;
    public GameObject PauseMenu;
    public GameObject Soundmuel;
    public GameObject PizzaUnit;
    
    public InputActionAsset InputActions;
    private InputAction moveAction;
    private InputAction shootAction;
    private InputAction soundAction;

    private InputAction pauseAction;
    private InputAction pauseActionM;
    public GameObject blablabla;
    

    void Update()
    {
         float horizontalInput = moveAction.ReadValue<Vector2>().x;
        // movimenta o player para esquerda e direita a partir da entrada do usu�rio
        transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInput);
        // mant�m o player dentro dos limites do jogo (eixo x)
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        // dispara comida ao pressionar barra de espa�o
        ShootAct();
        PauseGame();
       // SoundAct();
    }
    private void PauseGame()
    {
        if(pauseAction.WasPressedThisFrame())
        {
            Time.timeScale = 0;
            InputActions.FindActionMap("UI").Enable();
            UiEnable();
        }
        if(pauseActionM.WasPressedThisFrame())
        {
            InputActions.FindActionMap("UI").Disable();
            Time.timeScale = 1f;
            UiDisable();
        }
    }
    private void ShootAct()
    {
        if (shootAction.WasPressedThisFrame())
        {
            PizzaUnit = Instantiate(projectilePrefab, transform.position + new Vector3(0,2f,0), projectilePrefab.transform.rotation);
            
        }
    }
    private void SoundAct()
    {
        if(soundAction.WasPressedThisFrame() && ghost.ghosting == true)
        {
            Instantiate(Soundmuel, transform.position, Soundmuel.transform.rotation);
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
        playerstats = GetComponent<PlayerStats>();
        PauseMenu = GameObject.Find("pauseMenu");
        PauseMenu.SetActive(false);
        moveAction = InputSystem.actions.FindAction("Move");
        shootAction = InputSystem.actions.FindAction("Jump");
        soundAction = InputSystem.actions.FindAction("Interact");
        pauseAction = InputSystem.actions.FindAction("Pause");
        pauseActionM = InputSystem.actions.FindAction("Unpause");
        ghost = gameObject.GetComponent<Ghosting>();
        InputActions.FindActionMap("UI").Disable();
        InputActions.FindActionMap("Player").Enable();        
        
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("animal") && gameObject.CompareTag("Player") && !ghost.ghosting)
        {
            playerstats.LifeCalc(-1);
            Destroy(other.gameObject);
        }

        if(other.CompareTag("pizza") && teleguiar)
        {
            pizzaMove = PizzaUnit.GetComponent<MoveForward>();
            pizzaMove.Teleguiada = true;
        }
    }
    // public void AtivarTeleg()
    // {
    //     foreach(int i  in PizzaCount)
    //     {
    //         pizzaMove = PizzaUnit.GetComponent<MoveForward>();
    //         pizzaMove.Teleguiada = true;
    //     }
    // }
    // public void DesativarTeleg()
    // {
    //     foreach(int i in PizzaCount)
    //     {
    //         pizzaMove = PizzaUnit.GetComponent<MoveForward>();
    //         pizzaMove.Teleguiada = false;
    //     }
    // }

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
