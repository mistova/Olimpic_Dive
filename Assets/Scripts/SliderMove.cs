using UnityEngine;
using UnityEngine.UI;

public class SliderMove : MonoBehaviour
{
    [SerializeField]
    float speed = 10;

    float value;

    bool turn, canRun;
    Slider slider;

    void Start()
    {
        turn = true;
        canRun = true;
        value = -0.1f;
        slider = GetComponent<Slider>();
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
            slider.value = value;
        }
        else if (value > 0)
        {
            turn = false;
            value -= speed * Time.deltaTime;
            slider.value = value;
        }
        else
            turn = true;
    }

    internal float GetValue()
    {
        canRun = false;
        return slider.value;
    }
}
