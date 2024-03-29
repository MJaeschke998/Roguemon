using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float Movespeed;
    private bool isMoving;

    private Vector2 input;
    private Animator animator;
    public LayerMask solidObjects;
    public LayerMask grasslayer;
    public Canvas Canvas;
    public event Action onEncounterd;


    private void Awake() {
        animator = GetComponent<Animator>();
    }



    // Update is called once per frame
    public void HandleUpdate()
    {
        if(!isMoving){

            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");
            if (input.x != 0) input.y = 0;

            if(input != Vector2.zero){
                animator.SetFloat("moveX",input.x);
                animator.SetFloat("moveY",input.y);
                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                if(IsWalkable(targetPos))
                StartCoroutine(Move(targetPos));
            }

        }

        animator.SetBool("isMoving", isMoving);
        
    }

    IEnumerator Move(Vector3 targetPos){
         isMoving = true;
        while((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon){
            transform.position = Vector3.MoveTowards(transform.position, targetPos, Movespeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;
        isMoving = false;
        CheckForEncounters();
    }
    private bool IsWalkable(Vector3 targetPos){
        if(Physics2D.OverlapCircle(targetPos,0.2f, solidObjects) != null){
            return false;
        }
        return true;
    }

    private void CheckForEncounters(){
        if(Physics2D.OverlapCircle(transform.position, 0.2f,grasslayer)!=null){
           if (UnityEngine.Random.Range(1,101) <= 10){
                Debug.Log("Encountered a pokemon!");
                animator.SetBool("isMoving", false);
                onEncounterd();
                //GetComponent<Canvas>().enabled = true;
            }
        }
    }
}


