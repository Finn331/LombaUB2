using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerBillboard : MonoBehaviour
{
    public GameObject billboard;
    public Button buttonClose;
    public GameObject popup;

    bool isOpen = false;
    bool isPlayerNearby = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            popup.SetActive(true);
            isPlayerNearby = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            popup.SetActive(false);
            isPlayerNearby = false;
        }
    }
    void Start()
    {
        billboard.SetActive(false);
        popup.SetActive(false);
        buttonClose.onClick.AddListener(HideMap);
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            ShowMap();
        }
        
    }

    void ShowMap()
    {
        billboard.SetActive(true);
    }

    void HideMap()
    {
        billboard.SetActive(false);
    }
}
