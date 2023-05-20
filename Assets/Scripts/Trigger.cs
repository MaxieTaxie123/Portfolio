using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Trigger : MonoBehaviour
{
    private bool triggerActive = false;
    public string URL;
    public TextMeshProUGUI interactionText;

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            triggerActive = true;
            Debug.Log("Player entered collider");
            interactionText.gameObject.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            triggerActive = false;
            Debug.Log("Player exited collider");
            interactionText.gameObject.SetActive(false);
        }
    }

    void Start()
    {
        interactionText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (triggerActive && Input.GetKeyDown(KeyCode.E))
        {
            LoadPage();
        }        
    }

    void LoadPage()
    {
        Application.OpenURL(URL);
    }
}
