using UnityEngine;

public class CheckMove : MonoBehaviour
{
    GameObject other;

    string buttonString;

    internal void ChangePosition(string buttonString)
    {
        this.buttonString = buttonString;
    }
    internal void CalculatePoint()
    {
        if (other == null || !other.GetComponent<TransparentObject>().GetStringOfColor().Equals(buttonString))
            UIController.Instance.AddScore(GameController.Instance.wrongActionScore);
        else
            UIController.Instance.AddScore(GameController.Instance.correctActionScore);
    }

    internal void SetOther(GameObject other)
    {
        this.other = other;
    }
}
