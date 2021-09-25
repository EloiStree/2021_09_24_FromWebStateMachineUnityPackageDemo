using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteMe_MirrorStateToPlayer : MonoBehaviour
{
    public BooleanStringStateMachineMono m_source;
    public Transform m_direction;
    public Rigidbody m_body;

    public string m_stateIdle="idle";
    public string m_stateWalk="walk";
    public string m_stateRun="run";
    public string m_stateJump="jump";
    public string m_stateDoubleJump="doublejump";
    public string m_stateFalling="falling";


    public Vector3 m_upForce = Vector3.up;
    public float m_jumpForce = 10;
    public float m_doubleJumpforce = 2;
    public float m_walkForce = 2;
    public float m_runForce = 5;
    public string m_current;
    void Update()
    {
        m_source.GetCurrentState(out string state);
        if (m_current != state)
        {
            if (state == m_stateJump)
                m_body.AddForce(Vector3.up * m_jumpForce, ForceMode.Impulse);
            if (state == m_stateDoubleJump)
                m_body.AddForce(Vector3.up * m_doubleJumpforce, ForceMode.Impulse);
        }

        if (state == m_stateWalk)
            m_body.AddForce(Vector3.forward * m_walkForce * Time.deltaTime, ForceMode.Acceleration);
        if (state == m_stateRun)
            m_body.AddForce(Vector3.forward * m_runForce * Time.deltaTime, ForceMode.Acceleration);

        m_current = state;
    }
}
