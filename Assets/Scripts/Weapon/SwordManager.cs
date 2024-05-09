using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordManager : MonoBehaviour
{
    [HideInInspector] public Animator animator;
    // Start is called before the first frame update

    private float lastClickedTime = 0;
    public static int noOfClicks = 0;

    
    void Start()
    {
        animator = FindParentObjectByName(transform, "PlayerObject").GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            animator.SetBool("isSwing", false);
        }
        
    }

    private void Attack()
    {
        // lastClickedTime = Time.time;
        // noOfClicks++;
        //
        // // combo 1
        // if (noOfClicks == 1)
        // {
        //     animator.SetBool("hit1", true);
        // }
        // noOfClicks = Mathf.Clamp(noOfClicks, 0, 3);
        //
        // // combo 2
        // if (noOfClicks >= 2 && animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f )
        // {
        //     animator.SetBool("hit1", false);
        //     animator.SetBool("hit2", true);
        // }
        //
        // // combo 3
        // if (noOfClicks >= 3 && animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f )
        // {
        //     animator.SetBool("hit2", false);
        //     animator.SetBool("hit3", true);
        // }
        animator.SetBool("isSwing", true);
        // if (animator.GetCurrentAnimatorStateInfo(animator.GetLayerIndex("Sword")).normalizedTime > 1f)
        // {
        //     animator.SetBool("isSwing", false);
        // }
    }
    
    private GameObject FindParentObjectByName(Transform child, string parentName)
    {
        // Start from the child's parent
        Transform parent = child.parent;

        // Iterate through the hierarchy to find the parent object by name
        while (parent != null)
        {
            if (parent.name == parentName)
            {
                // Return the parent object if its name matches
                return parent.gameObject;
            }

            // Move to the next parent
            parent = parent.parent;
        }

        // If the parent object is not found, return null
        return null;
    }
}
