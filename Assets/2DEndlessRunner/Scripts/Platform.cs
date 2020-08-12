using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private Vector3 m_MoveDirection;
    [SerializeField] private float m_MovementSpeed;
    [SerializeField] private Transform m_EndPosition;
    [SerializeField] private bool canPool;
    private bool _canTranslate = true;
    private bool _addedToPool = false;
    private Vector2 _screenBounds;

    private void Start()
    {
        Camera mainCamera = Camera.main;
        _screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        _screenBounds *= -1;
    }
    // Update is called once per frame
    private void Update()
    {
        if (_canTranslate && GameManager.Instance.IsGameStarted() && !GameManager.Instance.IsGameOver())
        {
            if (m_EndPosition.position.x > _screenBounds.x)
            {
                transform.Translate(m_MoveDirection * m_MovementSpeed * Time.deltaTime);
            }
            else
            {
                _canTranslate = false;
                transform.position = new Vector3(transform.position.x, -_screenBounds.y + 20, 0);
                if (canPool)
                {
                    SpawnManager.Instance.AddToPool(gameObject);
                }
            }
        }
    }
    public Vector3 GetEndPosition()
    {
        return m_EndPosition.position;
    }

    public void StartTranslate() => _canTranslate = true;
}
