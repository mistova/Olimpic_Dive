using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmosForward : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, ((transform.forward*2)+transform.position) );
    }
}
