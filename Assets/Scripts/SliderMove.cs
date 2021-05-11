using UnityEngine;
using UnityEngine.UI;

public class SliderMove : MonoBehaviour
{
    [SerializeField]
    float speed = 2;

    float value;

    bool turn, canRun;
    Image slider;

    void Start()
    {
        turn = true;
        canRun = true;
        value = -0.1f;
        slider = GetComponent<Image>();
    }

    void Update()
    {
        if (canRun)
            Move();
        if (Input.GetMouseButtonDown(0))
            canRun = false;
    }

    void Move()
    {
        if (value < 1 && turn)
        {
            value += speed * Time.deltaTime;
            slider.fillAmount = value;
        }
        else if (value > 0)
        {
            turn = false;
            value -= speed * Time.deltaTime;
            slider.fillAmount = value;
        }
        else
            turn = true;
    }

    internal float GetValue()
    {
        canRun = false;
        return slider.fillAmount;
    }
}
