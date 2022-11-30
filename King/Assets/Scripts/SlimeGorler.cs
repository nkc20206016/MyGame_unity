using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeGorler : MonoBehaviour
{
    public bool gorl;
    bool soundTrigger = false;
    Animator animator;

    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Slime")
        {
            gorl = true;
            animator.SetBool("hory", true);
            if (soundTrigger == false)
            {
                audioSource.Play();

                soundTrigger = true;
            }
        }
    }
}
