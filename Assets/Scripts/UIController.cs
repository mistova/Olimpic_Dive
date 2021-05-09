using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController Instance;

    [SerializeField]
    Slider slider;

    [SerializeField]
    TMPro.TextMeshProUGUI text, startText;

    [SerializeField]
    GameObject player;

    [SerializeField]
    GameObject buttonHolder;

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

    public void ButtonClick(int i)
    {
        AnimationController.Instance.PerformPose(i);
    }

    internal void AddScore(int score)
    {
        value += score;
        startText.text = "" + score;
        startText.gameObject.SetActive(true);
        StartCoroutine(SetTextInActiveAsync());
        RefreshScore();
    }

    IEnumerator SetTextInActiveAsync()
    {
        yield return new WaitForSeconds(1f);
        startText.gameObject.SetActive(false);
    }

    internal void StartMoving()
    {
        startText.gameObject.SetActive(false);
    }

    internal void SetButtonActive(bool b)
    {
        buttonHolder.SetActive(b);
    }

    void RefreshScore()
    {
        text.text = "Score: " + value;
    }
}
