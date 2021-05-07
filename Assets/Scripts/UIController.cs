using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController Instance;

    [SerializeField]
    Slider slider;

    [SerializeField]
    Text text, startText;

    [SerializeField]
    GameObject player;

    int value;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        value = 0;
    }

    internal void StartSliderMovement()
    {
        slider.gameObject.SetActive(true);
    }

    internal void StopSliderMovement()
    {
        value = (int)(GameController.Instance.sliderScoreMultiplier * slider.GetComponent<SliderMove>().GetValue());
        RefreshScore();
        slider.gameObject.SetActive(false);
    }

    public void ButtonClick(string buttonString)
    {
        player.GetComponent<CheckMove>().ChangePosition(buttonString);
    }

    internal void AddScore(int score)
    {
        value += score;
        RefreshScore();
    }

    internal void StartMoving()
    {
        startText.gameObject.SetActive(false);
    }

    void RefreshScore()
    {
        text.text = "Score: " + value;
    }
}
