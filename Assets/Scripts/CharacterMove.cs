using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    [SerializeField]
    float speed = 5;

    bool canGo;

    void Start()
    {
        canGo = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            canGo = true;
            UIController.Instance.StartMoving();
        }
        if (canGo)
            Move();
    }

    void Move()
    {
        transform.position += speed * Time.deltaTime * Vector3.forward;
    }
}
