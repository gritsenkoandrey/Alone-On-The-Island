using UnityEngine;


public class ExampleIKAnim : MonoBehaviour
{
    public Animator animator;

    public bool isActive = false;
    public Transform rightHandObj = null;
    public Transform leftHandObj = null;
    public Transform LookObj = null;

    private void OnValidate()
    {
        animator = GetComponent<Animator>();
    }

    //a callback for calculating IK
    private void OnAnimatorIK()
    {
        //if the IK is active, set the position and rotation directly to the goal. 
        if (isActive)
        {
            //Set the look target position, if one has been assigned
            if (LookObj != null)
            {
                animator.SetLookAtWeight(1);
                animator.SetLookAtPosition(LookObj.position);
            }

            if (rightHandObj || leftHandObj)
            {
                animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
                animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
                animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandObj.position);
                animator.SetIKRotation(AvatarIKGoal.RightHand, rightHandObj.rotation);

                animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
                animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
                animator.SetIKPosition(AvatarIKGoal.LeftHand, leftHandObj.position);
                animator.SetIKRotation(AvatarIKGoal.LeftHand, leftHandObj.rotation);
            }
        }
        else
        {
            animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
            animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);
            animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0);
            animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0);

            animator.SetLookAtWeight(0);
        }
    }
}