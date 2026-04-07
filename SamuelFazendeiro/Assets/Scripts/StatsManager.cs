using UnityEngine;
using TMPro;
using System;

public class StatsManager : MonoBehaviour
{
    
    public GameObject Player;
    public PlayerStats playerstats;
    public GameObject vida1,vida2,vida3;
    public TextMeshProUGUI texto;
    void Start()
    {
        playerstats = Player.GetComponent<PlayerStats>();        
    }

    // Update is called once per frame
    void Update()
    {
        Life();
        Points();
    }

    void Life()
    {
        if(playerstats.vida == 2)
        {
            vida3.SetActive(false);
        }

        if(playerstats.vida == 1)
        {
            vida2.SetActive(false);
        }
    }
    void Points()
    {
        texto.text =  "Pontos: " + playerstats.pontos.ToString();
    }

}
