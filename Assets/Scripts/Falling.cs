using UnityEngine;

public class Falling : MonoBehaviour
{
    [SerializeField]
    float speed = 5;

    bool canGo;

    void Start()
    {
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.position += speed * Time.deltaTime * Vector3.down;
    }

    internal void Falled()
    {
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Falling>().enabled = false;
    }
}
