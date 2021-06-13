using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    private Vector3 mOffset, StartPos;
    private float zCord;
    public GameObject Elbow, Shoudler;

    [SerializeField] private Transform r1, r2;
    private Vector3 lastPos;
    private Vector3 r2FirstPos;
    private float r;

    [SerializeField] private bool isExceed;

    private Vector2 pointA, pointB, checkMousePosition;


    public int armDirection;
    public bool isArm;

    [SerializeField] private GameObject image;
    private void Start()
    {
        StartPos = transform.position;
        r2FirstPos = r2.position;
        r = Vector3.Distance(r2.position, r1.position);

    }
    private void OnMouseDown()
    {
        zCord = Camera.main.WorldToScreenPoint(transform.position).z;
        mOffset = transform.position - GetMouseWorldPos();

        GetComponent<Rigidbody>().isKinematic = false;
        Elbow.GetComponent<Rigidbody>().isKinematic = false;
        Shoudler.GetComponent<Rigidbody>().isKinematic = false;

        pointA = Input.mousePosition;
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 MousePoint = Input.mousePosition;
        MousePoint.z = zCord;
        return Camera.main.ScreenToWorldPoint(MousePoint);
    }

    private void OnMouseDrag()
    {
        //Debug.Log("distance = " + Vector3.Distance(r2.position, r1.position) + "  r = " + r);
        
        RotateZ();
        
        if (Vector3.Distance(r2.position, r1.position) > r + 0.2f)
        {
            if (!isExceed)
            {
                lastPos = transform.position;
                isExceed = true; 
            }
            else if (isExceed)
            {
                BackToLastPos();
            }
        }
        else if(!isExceed)
        {
            transform.position = GetMouseWorldPos() + mOffset;
        }
    }
    private void OnMouseUp()
    {
        GetComponent<Rigidbody>().isKinematic = true;
        Elbow.GetComponent<Rigidbody>().isKinematic = true;
        Shoudler.GetComponent<Rigidbody>().isKinematic = true;
    }

    private void Update()
    {
        if (isExceed)
        {
            BackToLastPos();
        }
        image.transform.LookAt(Camera.main.transform);
    }
    private void BackToLastPos()
    {
        transform.position = Vector3.MoveTowards(transform.position, lastPos, Time.deltaTime * 50f);
        if(transform.position == lastPos)
        {
            transform.position = lastPos;
            isExceed = false;
        }
    }
    private void RotateZ()
    {
        pointB = Input.mousePosition;
        if (pointB != checkMousePosition && isArm)
        {
            if (pointB.x - pointA.x > 5 && Elbow.transform.localEulerAngles.z < 90)
            {
                Elbow.transform.localEulerAngles += Vector3.forward * 3 * armDirection;
                checkMousePosition = Input.mousePosition;
            }
            else if (pointB.x - pointA.x > -5 && Elbow.transform.localEulerAngles.z > 0)
            {
                Elbow.transform.localEulerAngles += Vector3.forward * -3 * armDirection;
                checkMousePosition = Input.mousePosition;
            }
        }
    }
}
