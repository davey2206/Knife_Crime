using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class KnifeIK : MonoBehaviour
{

    protected Animator m_Animator;
    
    public bool ikActive;
    public Transform rightHandObj = null;
    public Transform lookObj = null;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
    }

    private void OnAnimatorIK(int layerIndex)
    {
        if (m_Animator)
        {
            if (ikActive)
            {
                if (rightHandObj != null)
                {
                    m_Animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
                    m_Animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
                    m_Animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandObj.position);
                    m_Animator.SetIKRotation(AvatarIKGoal.RightHand, rightHandObj.rotation);

                }

                if (lookObj != null)
                {
                    m_Animator.SetLookAtWeight(1);
                    m_Animator.SetLookAtPosition(lookObj.position);
                }
            }
            else
            {
                m_Animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
                m_Animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);
                m_Animator.SetLookAtWeight(0);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
