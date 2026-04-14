using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class StatsManager : MonoBehaviour
{
    
    public GameObject Player;
    public PlayerStats playerstats;
    public GameObject vida1,vida2,vida3;
    public TextMeshProUGUI texto;
    public string level;
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
        if(playerstats.vida <= 0)
        {
            SceneManager.LoadScene(level);
        }
    }
    void Points()
    {
        texto.text =  "Pontos: " + playerstats.pontos.ToString();
    }

}
