using UnityEngine;
using System.Collections;

public class BouncePad : MonoBehaviour
{
    public Vector3 MinImpulse;
    public float ExtraJumpPower;
    private void OnCollisionEnter(Collision collision)
    {
        var impulse = MinImpulse.magnitude > collision.impulse.magnitude ? MinImpulse : collision.impulse;
        var impulseToApply = impulse * ExtraJumpPower;
        collision.rigidbody?.AddForce(impulseToApply, ForceMode.Impulse);
     
    }
}
