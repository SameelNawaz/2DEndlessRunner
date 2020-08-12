using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    [SerializeField] private int m_ScoreAmount;
    [SerializeField] private AudioClip m_CollectionClip;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            ScoreManager.Instance.UpdateScore(m_ScoreAmount);
            AudioSource.PlayClipAtPoint(m_CollectionClip,transform.localPosition);
            Destroy(gameObject);
        }
    }
}
