using UnityEngine;

public class TransparentObject : MonoBehaviour
{
    [SerializeField]
    Material mat;

    [SerializeField]
    int poseNumber;

    [SerializeField]
    MakeTransparent [] transparencies;

    void Start()
    {
        for (int i = 0; i < transparencies.Length; i++)
            transparencies[i].ChangeAlpha(mat.color);
    }

    internal int GetNumberOfPose()
    {
        return poseNumber;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<CheckMove>().SetOther(gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<CheckMove>().CalculatePoint();
            other.gameObject.GetComponent<CheckMove>().SetOther(null);
        }
    }
}
