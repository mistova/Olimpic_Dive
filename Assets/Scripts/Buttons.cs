using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public int poses;
    [SerializeField] private int rpos;
    private void Start()
    {
        rpos = poses;
    }

}
