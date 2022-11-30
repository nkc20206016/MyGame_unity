using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    Animator animator;
    string state;
    // Start is called before the first frame update
    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case "Idle":
                animator.SetBool("JumpDown", false);
                animator.SetBool("Idle",true);
                break;
            case "Jump":
                animator.SetBool("JumpDown", true);
                animator.SetBool("Idle", false);
                break;
            default:
                animator.SetBool("JumpDown", false);
                animator.SetBool("Idle", true);
                break;
        }
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Slime")
        {
            state = "Jump";
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Slime")
        {
            state = "Idle";
        }
    }

}
