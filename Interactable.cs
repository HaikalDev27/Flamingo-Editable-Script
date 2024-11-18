using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public bool isRange;
    public KeyCode interactKey;
    public UnityEvent Action;
    public GameObject indicator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isRange && Input.GetKeyDown(interactKey))
        {
            Action.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player"))
        {
            isRange = true;
            indicator.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player"))
        {
            isRange = false;
            indicator.SetActive(false);
        }
    }
}