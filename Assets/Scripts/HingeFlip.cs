using UnityEngine;

public class HingeFlip : MonoBehaviour
{
    [SerializeField] private HingeJoint2D[] joints;
    public void Flip()
    {
        foreach (HingeJoint2D joint in joints)
        {
            JointAngleLimits2D limits = joint.limits;

            float oldMin = limits.min;
            float oldMax = limits.max;

            limits.min = -oldMax;
            limits.max = -oldMin;

            joint.limits = limits;
        }
    }
}
