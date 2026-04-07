using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCOntroler : MonoBehaviour
{
    public String cena;
    public GameObject Options;
    void Jogar()
    {
        SceneManager.LoadScene(cena);
    }
    void OptionsOpen()
    {
        Options.SetActive(true);
    }
    void OptionsClose()
    {
        Options.SetActive(false);
    }
    void Sair()
    {
        
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif  
    }
}
