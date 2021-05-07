using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    public int  sliderScoreMultiplier = 100,
                wrongActionScore = -10,
                correctActionScore = 40;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
}
