using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 target;
    private Vector3 lastPos;
    public static bool _canMove = true;
    public GameObject inventory;
    private Animator animator;
    private Rigidbody2D rb2d;
    private SpriteRenderer _spriteRenderer;

    public SoundManager SoundManager;
    private void Start()
    {
        target = transform.position;
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    
    // Update is called once per frame
    void Update()
    {
       
        if (inventory.activeInHierarchy || dialoguesWindow.activeInHierarchy)
        {
            _canMove = false;
            SoundManager.MuteSounds();
            animator.SetBool("isWalking", false);
        }
        else
        {
            _canMove = true;
        }
        if (_canMove && !wallCheck())
        { 
           Vector3 mousPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

           if(Input.GetMouseButtonDown(0))
           {
               
               target = new Vector3(mousPos.x, transform.position.y,transform.position.z);
               
           }

           lastPos = transform.position;
           transform.position = Vector3.MoveTowards(transform.position, target, 5 * Time.deltaTime);
           _SetOrient(lastPos, transform.position);
           
           if (lastPos != transform.position)
           {
               animator.SetBool("isWalking", true);
               SoundManager.UnmuteSounds();
           }
           else
           {
               animator.SetBool("isWalking", false);
               SoundManager.MuteSounds();
           }
        }
    }

    public void PlayerCantMove()
    {
        _canMove = false;
        target = new Vector3(transform.position.x, transform.position.y,transform.position.z);
    }

    public void PlayerCanMove()
    {
        _canMove = true;
    }
    
    private void _SetOrient(Vector3 lastPosition, Vector3 currentPosition)
    {
        if (lastPosition.x < currentPosition.x)
        {
            _spriteRenderer.flipX = false;
        }

        if (lastPosition.x > currentPosition.x)
        {
            _spriteRenderer.flipX = true;
        }
    }

    public Transform wallChecker;
    public LayerMask wallLayerMask;
    private bool wallCheck()
    {
        RaycastHit2D hitResult = Physics2D.Raycast(
            wallChecker.position,
            Vector2.right,
            0.2f,
            wallLayerMask);
        if(hitResult.collider != null)
        {
            return true;
        }
        return false;
    }

    public GameObject dialoguesWindow;
    private void checkDialogue()
    {
        if (dialoguesWindow.activeInHierarchy)
        {
            _canMove = false;
            
        }
        else
        {
            _canMove = true;
        }
    }
}