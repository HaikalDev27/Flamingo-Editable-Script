using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [Header("Movement")]
    public float ms;
    public float jf;
    Rigidbody2D rb;
    Animator anim;
    private BoxCollider2D boxcolider2d;
    [SerializeField] private LayerMask gdLayerMask;
    public bool canMove;
    bool isMoving;
    public AudioSource walkSfx;

    [Header("Input")]
    [SerializeField] KeyCode pause;
    [SerializeField] Interactable interactable;

    [Header("UI")]
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject QuestionBar;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxcolider2d = transform.GetComponent<BoxCollider2D>();
    }

    void Update(){
        float horiz = Input.GetAxisRaw("Horizontal");

        if (canMove)
        {
            rb.linearVelocity = new Vector2(horiz * ms, rb.linearVelocity.y);
            anim.SetFloat ("speed", Mathf.Abs (horiz), 0.1f, Time.deltaTime);    

		    if (horiz > 0 || horiz < 0) {
			    transform.localScale = new Vector2 (0.2f * horiz, 0.2f);
    		}

            if (IsGrounded () && Input.GetKeyDown (KeyCode.Space)) {
	    		rb.linearVelocity = Vector2.up * jf;
                FindFirstObjectByType<AudioManager>().Play("Jump");
		    }
        }

        if (rb.linearVelocity.x != 0)
        {
            isMoving = true;
        } else {
            isMoving = false;
        }

        if (isMoving)
        {
            if (!walkSfx.isPlaying)
            {
                walkSfx.Play();
            }
        } else
        {
            walkSfx.Stop();
        }
    }
    
    //this code is to check which one is defined as ground
    private bool IsGrounded(){
		RaycastHit2D raycast = Physics2D.BoxCast (boxcolider2d.bounds.center, boxcolider2d.bounds.size, 0f, Vector2.down, 1f, gdLayerMask);
		return raycast.collider != null;
	}
}
