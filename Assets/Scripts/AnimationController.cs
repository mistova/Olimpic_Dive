using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public static AnimationController Instance;

    Animator anim;
    internal int pose;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        pose = 0;
        anim = GetComponent<Animator>();
    }

    internal void StartToRun()
    {
        anim.SetTrigger("Run");
    }
    internal void Dive()
    {
        anim.SetTrigger("Dive");
    }
    internal void Fall()
    {
        anim.SetTrigger("Fall");
    }
    internal void PerformPose(int i)
    {
        if(pose > 0)
            anim.SetBool("isPose" + pose, false);
        anim.SetBool("isPose" + i, true);
        pose = i;
    }

    internal void BackFromPose()
    {
        anim.SetBool("isPose" + pose, false);
        pose = 0;
    }
}
