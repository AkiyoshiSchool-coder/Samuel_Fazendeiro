using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCOntroler : MonoBehaviour
{
    public String cena;
    public GameObject Options;
    public void Jogar()
    {
        SceneManager.LoadScene(cena);
    }
    public void OptionsOpen()
    {
        Options.SetActive(true);
    }
    public void OptionsClose()
    {
        Options.SetActive(false);
    }
    public void Sair()
    {
        
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif  
    }
}
