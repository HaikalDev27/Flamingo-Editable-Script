using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public bool isRange;
    public KeyCode interactKey;
    public UnityEvent Action;
    public Animator indicator;
    public GameObject canInteract;

    // Start is called before the first frame update
    void Start()
    {
        indicator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isRange && Input.GetKeyDown(interactKey))
        {
            Action.Invoke();
            canInteract.SetActive(false);
            FindFirstObjectByType<AudioManager>().Play("Interact");        
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player"))
        {
            isRange = true;
            indicator.SetBool("isRange", true);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player"))
        {
            isRange = false;
            indicator.SetBool("isRange", false);
        }
    }
}