using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    [SerializeField] private GameObject cameraPos;
    [Range(0, 1)] [SerializeField] private float lerpSmooth = 0;
    [SerializeField] private float slowness = 0.5f;
    [SerializeField] private float afterSecond = 7;
    [SerializeField] private bool gameHasFinished;

    private float timer;
    private int childCount = 0;
    private void LateUpdate()
    {
        //Debug.Log(cameraPos.transform.GetChild(0).transform.localPosition);
        if (gameHasFinished)
        {
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, cameraPos.transform.GetChild(childCount).position, lerpSmooth);
            Camera.main.transform.rotation = Quaternion.Lerp(Camera.main.transform.rotation, cameraPos.transform.GetChild(childCount).rotation, lerpSmooth);
            lerpSmooth += Time.deltaTime * slowness;
            timer += Time.deltaTime;
        }
        if (timer > afterSecond && childCount==0)
        {
            Debug.Log("S");
            childCount=1;
            lerpSmooth = 0;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Camera.main.GetComponent<CameraFollow>().enabled = false;
            gameHasFinished = true;
        }
    }
}
