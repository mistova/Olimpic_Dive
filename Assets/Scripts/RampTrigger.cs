using UnityEngine;

public class RampTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            UIController.Instance.StartSliderMovement();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AnimationController.Instance.Dive();
            UIController.Instance.StopSliderMovement();
        }
    }
}
