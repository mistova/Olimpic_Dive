using UnityEngine;

public class CheckMove : MonoBehaviour
{
    GameObject other;
    internal void CalculatePoint()
    {
        if (other == null || other.GetComponent<TransparentObject>().GetNumberOfPose() != AnimationController.Instance.pose)
            UIController.Instance.AddScore(GameController.Instance.wrongActionScore);
        else
            UIController.Instance.AddScore(GameController.Instance.correctActionScore);
        AnimationController.Instance.BackFromPose();
    }

    internal void SetOther(GameObject other)
    {
        this.other = other;
    }
}
