using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;
    public PlayerStats playerstats;

    void Awake()
    {
        Player = GameObject.Find("Player");
        playerstats = Player.GetComponent<PlayerStats>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("animal"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            playerstats.PointCalc(1);
        }
    }
}
