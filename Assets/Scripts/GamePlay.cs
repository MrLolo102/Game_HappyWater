using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.Android.Gradle;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class GamePlay : MonoBehaviour
{

    bool isOn;
    [SerializeField]  GameObject onStateObj;
    [SerializeField]  GameObject offStateObj;

    private void OnEnable()
    {
        isOn = false;
        onStateObj.SetActive(false);
        offStateObj.SetActive(true);
    }

    public void OnToggleButtonClick()
    {
        if (isOn)
        {
            isOn = false;
            onStateObj.SetActive(false);
            offStateObj.SetActive(true);
        }
        else
        {
            isOn = true;
            onStateObj.SetActive(true);
            offStateObj.SetActive(false);
        }
    }

    public List<GameObject> currentCollisions = new List<GameObject>();
    public Collider2D goal;
    public GameObject popupEndGame;
    public Collider2D objWaterTest;

     void Update()
    {
        foreach (GameObject gObject in currentCollisions)
        {
            if (gObject.GetComponent<Collider2D>().IsTouching(goal))
            {
                ShowPopupGameOver();
            }
        }
    }
    public void ShowPopupGameOver()
    {
        popupEndGame.SetActive(true);
        onStateObj.SetActive(true);

    }
}
