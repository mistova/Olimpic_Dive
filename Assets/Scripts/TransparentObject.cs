using UnityEngine;

public class TransparentObject : MonoBehaviour
{
    [SerializeField] private RandomImageScript randomImageScript;
    [SerializeField]
    Material mat;

    [SerializeField]
    public int poseNumber;

    [SerializeField]
    MakeTransparent[] transparencies;

    [SerializeField]
    Animator girlAnim;

    void Awake()
    {
        poseNumber = Random.Range(1, 4);
        girlAnim.SetInteger("Pose", poseNumber);
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
            if(randomImageScript.generation != 3)
            {
                randomImageScript.GenerateImage();
            }            
        }
    }
}
