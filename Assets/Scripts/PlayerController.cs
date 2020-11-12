using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D m_Rigidbody2D;

    [SerializeField]
    private float m_JumpForce = 500f;

    [SerializeField]
    private float m_MovementSpeed = 3f;

    private float m_Movement = 0f;

    private bool m_Jump = false;

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    private void FixedUpdate()
    {
        UpdatePosition();
    }

    private void GetInput()
    {
        m_Movement = Input.GetAxis("Horizontal") * m_MovementSpeed;

        m_Jump = Input.GetButtonDown("Jump");
    }

    private void UpdatePosition()
    {
        m_Rigidbody2D.velocity = new Vector2(m_Movement, m_Rigidbody2D.velocity.y);

        if (m_Jump)
        {
            m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
        }
    }
}
