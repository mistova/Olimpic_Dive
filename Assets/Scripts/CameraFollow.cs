using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Vector3 position;
    [SerializeField]
    Transform playerTransform;

    void Start()
    {
        position = playerTransform.position - transform.position;
    }

    void Update()
    {
        transform.position = playerTransform.position - position;
    }
}
