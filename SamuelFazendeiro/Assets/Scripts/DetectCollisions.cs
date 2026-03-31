using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;
    public PlayerStats playerstats;

    private void start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Player = GameObject.Find("Player");
        playerstats = Player.GetComponent<PlayerStats>();
        if(!other.CompareTag("Player"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
        if(gameObject.tag == "animal" && other.tag == "Player")
        {
            playerstats.LifeCalc(-1);
            Destroy(gameObject);
        }
    }
}
