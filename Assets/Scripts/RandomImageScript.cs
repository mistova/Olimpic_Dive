using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomImageScript : MonoBehaviour
{
    public List<Sprite> texture2Ds;
    public List<Sprite> cloneTexture2Ds;
    public List<int> numbers;
    public GameObject[] buttons;
    public GameObject[] tranparenPoses;
    private int textureCount;
    private int correctButton;
    public int generation;
    void Start()
    {
        generation = 0;
        buttons = GameObject.FindGameObjectsWithTag("Button");
        tranparenPoses = GameObject.FindGameObjectsWithTag("TransparentPose");
        textureCount = texture2Ds.Count;

        
        CloneTexture();
        GenerateImage();

    }
    public void GenerateImage()
    {
        correctButton = Random.Range(0, 3);
        //Debug.Log(correctButton);
        buttons[correctButton].GetComponent<Image>().sprite = texture2Ds[tranparenPoses[generation].GetComponent<TransparentObject>().poseNumber - 1];
        buttons[correctButton].GetComponent<Buttons>().poses = tranparenPoses[generation].GetComponent<TransparentObject>().poseNumber;
        //cloneTexture2Ds.RemoveAt(tranparenPoses[generation].GetComponent<TransparentObject>().poseNumber - 1);
        numbers.Remove(tranparenPoses[generation].GetComponent<TransparentObject>().poseNumber - 1);
        for (int i = 0; i < 3; i++)
        {
            if (i != correctButton)
            {
                int number = numbers[Random.Range(0, numbers.Count)];
                buttons[i].GetComponent<Image>().sprite = texture2Ds[number];
                Debug.Log(number);
                buttons[correctButton].GetComponent<Buttons>().poses = number+1;
                //Debug.Log("number = " + number);
                //Debug.Log("button" + i + " = " + cloneTexture2Ds[number].name);

                //cloneTexture2Ds.RemoveAt(number);
                numbers.Remove(number);
            }
        }
        generation++;
        CloneTexture();
    }
    private void CloneTexture()
    {
        numbers = new List<int>();
        for (int i = 0; i < textureCount; i++)
        {
            numbers.Add(i);
        }
        //cloneTexture2Ds = new List<Sprite>(texture2Ds);
    }
}
