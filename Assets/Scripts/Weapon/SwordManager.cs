using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SwordManager : MonoBehaviour
{
    [HideInInspector] public Animator animator;
    // Start is called before the first frame update
    [SerializeField] public PlayerSword sword;
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
            sword.SetDamage(0);
        }
        
    }

    private void Attack()
    {
        animator.SetBool("isSwing", true);
        sword.SetDamage(50);
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
