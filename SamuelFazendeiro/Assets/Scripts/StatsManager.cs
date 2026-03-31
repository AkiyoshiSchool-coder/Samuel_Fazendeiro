using UnityEngine;

public class StatsManager : MonoBehaviour
{
    
    public GameObject Player;
    public PlayerStats playerstats;

    void Start()
    {
        playerstats = Player.GetComponent<PlayerStats>();        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
