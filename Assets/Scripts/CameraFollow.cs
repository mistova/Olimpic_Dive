using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Vector3 position;
    [SerializeField]
    Transform playerTransform;

    [SerializeField]
    float followLimitY;

    void Start()
    {
        position = playerTransform.position - transform.position;
    }

    void Update()
    {
        if(transform.position.y > followLimitY)
            transform.position = playerTransform.position - position;
    }
}
