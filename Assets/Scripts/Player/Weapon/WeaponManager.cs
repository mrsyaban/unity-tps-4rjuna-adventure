using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [HideInInspector] public Animator animator;
    public float scrollSensitivity = 4f;
    public int selectedWeapon = 1;
    private GameObject _leftHand;
    private GameObject _rightHand;
    private UnityEngine.Animations.Rigging.TwoBoneIKConstraint _twoBoneIKLeft;
    private UnityEngine.Animations.Rigging.MultiAimConstraint _twoBoneIKRight;
    
    // Start is called before the first frame update
    void Start()
    {
        _leftHand = GameObject.Find("JammoPlayer/Rig 1/LeftHandK");
        _rightHand = GameObject.Find("JammoPlayer/Rig 1/RightHandAim");
        _twoBoneIKLeft = _leftHand.GetComponent<UnityEngine.Animations.Rigging.TwoBoneIKConstraint>();
        _twoBoneIKRight = _rightHand.GetComponent<UnityEngine.Animations.Rigging.MultiAimConstraint>();
        animator = FindParentObjectByName(transform, "PlayerCapsule").GetComponent<Animator>();
        SelectWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel") * scrollSensitivity;
        int previousSelectedWeapon = selectedWeapon;
        if (scrollInput > 0f)
        {
            if (selectedWeapon >= transform.childCount)
            {
                selectedWeapon = 1;
            }
            else
            {
                selectedWeapon++;
            }
        }

        if (scrollInput < 0f)
        {
            if (selectedWeapon <= 1)
            {
                selectedWeapon = transform.childCount;
            }
            else
            {
                selectedWeapon--;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedWeapon = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedWeapon = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            selectedWeapon = 3;
        }

        if (previousSelectedWeapon != selectedWeapon)
        {
            SelectWeapon();
        }
    }

    private void SelectWeapon()
    {
        int i = 1;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }

            i++;
        }

        if (selectedWeapon == 1)
        {
            _twoBoneIKLeft.weight = 1f;
            _twoBoneIKRight.weight = 1f;
            animator.SetBool("isShotGun", false);
            animator.SetBool("isSword", false);
        }

        if (selectedWeapon == 2)
        {
            _twoBoneIKLeft.weight = 0f;
            _twoBoneIKRight.weight = 0f;
            animator.SetBool("isSword", true);
            animator.SetBool("isShotGun", false);
        }

        if (selectedWeapon == 3)
        {
            _twoBoneIKLeft.weight = 0f;
            _twoBoneIKRight.weight = 0f;
            animator.SetBool("isShotGun", true);
            animator.SetBool("isSword", false);
        }
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
