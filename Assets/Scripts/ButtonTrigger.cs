using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            UIController.Instance.SetButtonActive(true);
            AnimationController.Instance.Fall();
        }
    }
}
