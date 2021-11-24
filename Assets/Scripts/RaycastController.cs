using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RaycastController : MonoBehaviour
{
    public float rayLenght;
    public LayerMask layermask;

    public GameObject textDisplay;
    public int secondsLeft = 5;
    public bool takingAway = false;

    public GameObject canvas;
    public int totalTime;

    private void Update()
    {

        totalTime = secondsLeft;
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin,ray.direction*100, Color.cyan);

            if (Physics.Raycast(ray, out hit, rayLenght, layermask))
            { 
                var selection=hit.transform;
                if(selection.CompareTag("Scene1"))
                {
                    textDisplay.GetComponent<Text>().text = "00:" + secondsLeft;
                    if (takingAway == false && secondsLeft > 0)
                    {
                        StartCoroutine(TimerTake());
                    }
                    Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red);
                    Debug.Log(hit.collider.name);
                    SceneManager.LoadScene("Scene1 1");
                }

                if(selection.CompareTag("Scene2"))
                {
                    if (takingAway == false && secondsLeft > 0)
                    {
                        StartCoroutine(TimerTake());
                    }
                    textDisplay.GetComponent<Text>().text = "00:" + secondsLeft;
                    Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red);
                    Debug.Log(hit.collider.name);
                    SceneManager.LoadScene("Scene1 2");
                }

                if(selection.CompareTag("Scene3"))
                {
                    if (takingAway == false && secondsLeft > 0)
                    {
                        StartCoroutine(TimerTake());
                    }
                    textDisplay.GetComponent<Text>().text = "00:" + secondsLeft;
                    Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red);
                    Debug.Log(hit.collider.name);
                    SceneManager.LoadScene("Scene1 3");
                }
            }
        }

    }

    IEnumerator TimerTake()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        secondsLeft -= 1;
        if (secondsLeft < 10)
        {
            textDisplay.GetComponent<Text>().text = "00:0" + secondsLeft;
        }
        else
        {
            textDisplay.GetComponent<Text>().text = "00:" + secondsLeft;
        }
        takingAway = false;
        
    }
}
