using UnityEngine;

public class MakeTransparent : MonoBehaviour
{
    [SerializeField]
    float alpha = 1;

    internal void ChangeAlpha(Color color)
    {
        Material mat = GetComponent<Renderer>().material;
        mat.color = new Color(color.r, color.g, color.b, alpha);
    }
}
