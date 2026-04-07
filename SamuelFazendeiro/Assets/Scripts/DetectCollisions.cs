using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;
    public PlayerStats playerstats;


    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Player"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
