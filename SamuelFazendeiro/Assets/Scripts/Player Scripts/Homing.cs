using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class Homing : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private IEnumerator Coroutine;
    public bool homing;
    public bool cooldown;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator temporizador()
    {
        homing = true;
        yield return new WaitForSeconds(5);
        cooldown = false;
    }
}
