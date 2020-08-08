using UnityEngine;
using System.Collections;

public class BouncePad : MonoBehaviour
{
    public Vector3 MinImpulse;
    private void OnCollisionEnter(Collision collision)
    {
        var impulse = MinImpulse.magnitude > collision.impulse.magnitude ? MinImpulse : collision.impulse;
        collision.rigidbody?.AddForce(impulse, ForceMode.Impulse);
     
    }
}
