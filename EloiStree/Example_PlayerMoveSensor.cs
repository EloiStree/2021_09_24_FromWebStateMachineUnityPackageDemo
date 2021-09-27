using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example_PlayerMoveSensor : MonoBehaviour
{

    public Transform m_groundRaycheck;
    public Rigidbody m_rigidBody;
    public float m_hasGroundDistance=0.1f;
    public LayerMask m_groundCollisionLayer;

    //public bool m_hasGround;
    //public bool m_isFalling;

    //public void Update()
    //{
    //    m_isFalling = IsFalling_Velocity();
    //    m_hasGround = HasGround_Raycast();
    //}
    public bool HasGround_Raycast() {
        Debug.DrawLine(m_groundRaycheck.position, m_groundRaycheck.position + -m_groundRaycheck.up* m_hasGroundDistance, Color.red);
        if(Physics.Raycast(m_groundRaycheck.position, -m_groundRaycheck.up, out RaycastHit hit, m_hasGroundDistance, m_groundCollisionLayer, QueryTriggerInteraction.Collide))
        {
            Debug.DrawLine(m_groundRaycheck.position, hit.point, Color.green);

            return true;

        }
            return false;

    }
    public bool IsFalling_Velocity() {
        return m_rigidBody.velocity.y <= 0f;
    }
}
