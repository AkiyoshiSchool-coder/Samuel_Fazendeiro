using UnityEngine;

public class StatsManager : MonoBehaviour
{
    
    public GameObject Player;
    public PlayerStats playerstats;
    public GameObject vida1,vida2,vida3;
    void Start()
    {
        playerstats = Player.GetComponent<PlayerStats>();        
    }

    // Update is called once per frame
    void Update()
    {
        Life();
    }

    void Life()
    {
        if(playerstats.vida == 3)
        {
            vida1.SetActive(true);
            vida2.SetActive(true);
            vida3.SetActive(true);
        }

        if(playerstats.vida == 2)
        {
            vida1.SetActive(true);
            vida2.SetActive(true);
            vida3.SetActive(false);
        }

        if(playerstats.vida == 1)
        {
            vida1.SetActive(true);
            vida2.SetActive(false);
            vida3.SetActive(false);
        }
    }
}
