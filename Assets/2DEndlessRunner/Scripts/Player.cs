using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private LayerMask platformsLayerMask;
    [SerializeField] private Animator m_Animator;
    [SerializeField] private BoxCollider2D m_BoxCollider2D;
    [SerializeField] private Rigidbody2D m_Rigidbody2D;
    [SerializeField] private float m_JumpVelocity;
    [SerializeField] private AudioSource m_AudioSource;
    [SerializeField] AudioClip m_JumpAudio;
    [SerializeField] AudioClip m_DieAudio;
    private void Start()
    {
        m_Animator.SetBool("grounded", true);
    }
    private void Update()
    {
        if (GameManager.Instance.IsGameStarted() && !GameManager.Instance.IsGameOver())
        {
            if (IsGrounded())
            {
                m_Animator.SetFloat("velocityX", 1);
                m_Animator.SetBool("grounded", true);
                if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
                {
                    m_Animator.SetBool("grounded", false);
                    m_Rigidbody2D.velocity = Vector2.up * m_JumpVelocity;
                    m_AudioSource.PlayOneShot(m_JumpAudio);
                }
            }
        }
    }
    private bool IsGrounded()
    {
        RaycastHit2D _raycastGroundHit2d = Physics2D.BoxCast(m_BoxCollider2D.bounds.center, m_BoxCollider2D.bounds.size, 0f, Vector2.down, 0.1f, platformsLayerMask);
        RaycastHit2D _raycastFrontHit2d = Physics2D.BoxCast(m_BoxCollider2D.bounds.center, new Vector2(m_BoxCollider2D.bounds.size.x, m_BoxCollider2D.bounds.size.y / 2), 0f, Vector2.right, 0.01f, platformsLayerMask);
        Debug.DrawLine(m_BoxCollider2D.bounds.center, _raycastGroundHit2d.point, Color.green);
        Debug.DrawLine(m_BoxCollider2D.bounds.center, _raycastFrontHit2d.point, Color.red);
        if (_raycastFrontHit2d.transform)
        {
            PlayerDead();
        }
        return _raycastGroundHit2d.collider != null;
    }
    public void PlayerDead()
    {
        m_Animator.SetTrigger("hurt");
        m_Animator.SetBool("dead", true);
        m_AudioSource.PlayOneShot(m_DieAudio);
        GameManager.Instance.GameOver();
    }
}
