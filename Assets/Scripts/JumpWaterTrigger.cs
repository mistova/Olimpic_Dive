using UnityEngine;

public class JumpWaterTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            UIController.Instance.SetButtonActive(false);
            AnimationController.Instance.Dive();
        }
    }
}
