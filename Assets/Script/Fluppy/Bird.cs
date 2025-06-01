using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] private float m_jumpPower = 300f; 
    private Rigidbody2D m_Rigidbody = null;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
    }

    private void UpdateJumpBird()
    {
        if(Input.GetMouseButtonDown(0))
        {
            m_Rigidbody.linearVelocity = Vector2.zero;
            m_Rigidbody.AddForce(Vector2.up * m_jumpPower);
        }
    }

    private void Update()
    {
        //if(FluppyBirdManager.Instance.CurrentGameState != GameState.Play) return;

        if (m_Rigidbody == null)
        {
            return;
        }

        UpdateJumpBird();
    }
}
