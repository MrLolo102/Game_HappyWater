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

    public Collider2D foot1;
    public Collider2D foot2;
    public GameObject popupEndGame;

    void Update()
    {
        List<GameObject> currentCollisions = new List<GameObject>();

        void OnCollisionEnter(Collision col)
        {

            // Add the GameObject collided with to the list.
            currentCollisions.Add(col.gameObject);

            // Print the entire list to the console.
            foreach (GameObject gObject in currentCollisions)
            {
                print(gObject.name);
            }
        }

        void OnCollisionExit(Collision col)
        {

            // Remove the GameObject collided with from the list.
            currentCollisions.Remove(col.gameObject);

            // Print the entire list to the console.
            foreach (GameObject gObject in currentCollisions)
            {
                print(gObject.name);
            }
        }

        //if (foot1.IsTouching(foot2))
        //{

        //    ShowPopupGameOver();
        //}
        //else
        //{
        //    Debug.Log("leg1 and leg2 NOT touching");
        //}
    }
    public void ShowPopupGameOver()
    {
        popupEndGame.SetActive(true);
    }
}
