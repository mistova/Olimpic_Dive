using UnityEngine;

public class FallLimitTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Falling>().enabled = false;
        }
    }
}
