using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int vida;
    public int pontos;



    public void LifeCalc(int lifeAlt)
    {
        vida += lifeAlt;
    }
    public void PointCalc(int pointAlt)
    {
        pontos += pointAlt;
    }

}
