using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameplayHUD : MonoBehaviour
{
    public static GameplayHUD instance;
    public Slider timeSlider;
    public TextMeshProUGUI timeText;
    public GameObject heartsContainer;
    public GameObject lifeIconPrefab;
    public GameObject failedScreen;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            failedScreen.SetActive(false);
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }
    }

    // Update is called once per frame
    public void UpdateRemaningTime(float remaingTime)
    {
        timeSlider.value = remaingTime;
        timeText.text = ((int)remaingTime + 1).ToString();
    }

    public void RemoveAllHearts()
    {
        foreach (Transform child in heartsContainer.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    public void RemoveOneHeart()
    {
        if (heartsContainer.transform.childCount != 0)
        {
            heartsContainer.transform.GetChild(heartsContainer.transform.childCount - 1).GetComponent<ShakeScript>().ShakeObject();
            LeanTween.scale(heartsContainer.transform.GetChild(heartsContainer.transform.childCount-1).gameObject, Vector3.zero, 0.5f);
            Destroy(heartsContainer.transform.GetChild(heartsContainer.transform.childCount - 1).gameObject, 0.5f);
        }
    }

    public void InstantiateHearts(int amount)
    {
        for(int heartsCreated = 0; heartsCreated < amount; heartsCreated++)
        { 
            GameObject.Instantiate(lifeIconPrefab, heartsContainer.transform);
        }
    }

    public void ShowFailedScreen()
    {
        failedScreen.SetActive(true);
        RemoveOneHeart();


    }
}
