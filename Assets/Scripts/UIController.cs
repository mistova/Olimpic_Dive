using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController Instance;

    [SerializeField]
    GameObject slider;

    [SerializeField]
    TMPro.TextMeshProUGUI text, startText;

    [SerializeField]
    GameObject player;

    [SerializeField]
    GameObject buttonHolder;

    int value;

    private GameObject[] buttons;
    void Awake()
    {
        if (Instance == null)
            Instance = this;
        value = 0;

        buttons = GameObject.FindGameObjectsWithTag("Button");
    }

    internal void StartSliderMovement()
    {
        slider.transform.parent.gameObject.SetActive(true);
    }

    internal void StopSliderMovement()
    {
        value = (int)(GameController.Instance.sliderScoreMultiplier * slider.GetComponent<Image>().fillAmount);
        RefreshScore();
        slider.transform.parent.gameObject.SetActive(false);
    }

    public void ButtonClick(int a)
    {
        AnimationController.Instance.PerformPose(a);
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
