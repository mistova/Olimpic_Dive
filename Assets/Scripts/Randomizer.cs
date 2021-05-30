using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomizer : MonoBehaviour
{
    public List<GameObject> buttonPositionObjects;
    private List<GameObject> cloneButtonPositionObjects;
    public List<GameObject> buttonObjects;
    private List<GameObject> cloneButtonObjects;
    [SerializeField] private GameObject[] tranparenPoses;

    private List<int> numberOfPosition;

    private bool generateCorrectButton;
    private int placed = 0;
    public int level = 0;
    void Start()
    {
        tranparenPoses = GameObject.FindGameObjectsWithTag("TransparentPose");
        GenerateNumber();
        ResetList();
        CreateRandom();
    }
    public void CreateRandom()
    {
        int position = Random.Range(0, numberOfPosition.Count);
        if (!generateCorrectButton)
        {
            cloneButtonObjects[tranparenPoses[level].GetComponent<TransparentObject>().poseNumber - 1].GetComponent<RectTransform>().position = cloneButtonPositionObjects[numberOfPosition[position]].GetComponent<RectTransform>().position;
            cloneButtonObjects[tranparenPoses[level].GetComponent<TransparentObject>().poseNumber - 1].SetActive(true);
            cloneButtonObjects.Remove(cloneButtonObjects[tranparenPoses[level].GetComponent<TransparentObject>().poseNumber - 1]);
            generateCorrectButton = true;
        }
        else
        {
            int clone = Random.Range(0, cloneButtonObjects.Count);
            cloneButtonObjects[clone].GetComponent<RectTransform>().position = cloneButtonPositionObjects[numberOfPosition[position]].GetComponent<RectTransform>().position;
            cloneButtonObjects[clone].SetActive(true);
            cloneButtonObjects.Remove(cloneButtonObjects[clone]);
        }
        numberOfPosition.Remove(numberOfPosition[position]);
        placed++;
        if (placed != 3)
            CreateRandom();
        else
        { 
            placed = 0;
            level++;
            ResetList();
            GenerateNumber();
        }                
    }
    private void ResetList()
    {
        cloneButtonObjects = new List<GameObject>(buttonObjects);
        cloneButtonPositionObjects = new List<GameObject>(buttonPositionObjects);
    }
    private void GenerateNumber()
    {
        numberOfPosition = new List<int>();
        for (int i = 0; i < 3; i++)
        {
            numberOfPosition.Add(i);
        }
    }
}
