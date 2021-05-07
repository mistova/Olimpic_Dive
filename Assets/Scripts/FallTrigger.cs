using UnityEngine;

public class FallTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Falling>().enabled = true;
            other.gameObject.GetComponent<CharacterMove>().enabled = false;
        }
    }
}
