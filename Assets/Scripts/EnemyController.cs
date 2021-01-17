using System;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer m_SpriteRenderer;

    [SerializeField]
    private Animator m_Animator;

    [SerializeField]
    private Rigidbody2D m_Rigidbody2D;

    [SerializeField]
    private float m_crouchTime = 20.0f;

    [SerializeField]
    private float m_ForceModifier = 5000f;

    private float timer;
    private float m_lastCrouch;
    private bool m_crouch = false;


    public Rigidbody2D Rigidbody => m_Rigidbody2D;   

    
    private int m_GroundAnimatorId = Animator.StringToHash("Ground");
    private int m_CrouchAnimatorId = Animator.StringToHash("Crouch");

    private void Start()
    {
        timer = 0.0f;
        m_lastCrouch = 0.0f;
        m_crouch = false;
    }

    void Update()
    {
        UpdateAnimator();

        timer += Time.deltaTime;
        if (timer - m_lastCrouch > m_crouchTime)
        {
            m_lastCrouch = timer;
            m_crouch ^= true;
        }
    }


    private void UpdateAnimator()
    {
        m_Animator.SetBool(m_GroundAnimatorId, true);
        m_Animator.SetBool(m_CrouchAnimatorId, m_crouch);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        if (player != null)
        {
            player.Kill();
            player.Rigidbody.AddForce(Vector3.up * m_ForceModifier);
        }
    }
}