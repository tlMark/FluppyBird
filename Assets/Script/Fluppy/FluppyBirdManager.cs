using System;
using UnityEngine;

public enum GameState
{
    Wait,
    Ready,
    Play,
    GameOver,
}


public class FluppyBirdManager : Singleton<FluppyBirdManager>
{
    [SerializeField] private float m_createSpeed = 2f;

    private Pipe m_pipeObject = null;
    private float m_createTime = 0f;
    private GameState m_gameState = GameState.Wait;

    public static event Action<GameState> OnChangeGameState = null;
    public GameState CurrentGameState => m_gameState;

    private void Start()
    {
        m_pipeObject = Resources.Load<GameObject>("Prefabs/Gwan").GetComponent<Pipe>();
    }

    private void OnDestroy()
    {
        OnChangeGameState = null;
    }

    public void CreatePipe()
    {
        Instantiate(m_pipeObject);
    }

    public void ChangeCreateSpeed(float time)
    {
        m_createSpeed = time;
    }

    public void ChangeState(GameState state)
    {
        switch (state)
        {
            case GameState.Wait:
                break;
            case GameState.Ready:
                break;
            case GameState.Play:
                m_createTime = 0f;
                break;
            case GameState.GameOver:
                break;
        }

        OnChangeGameState?.Invoke(m_gameState);
    }

    private void UpdateCreatePipe()
    {
        /*if (CurrentGameState != GameState.Play)
        {
            return;
        }
        */
        m_createTime += Time.deltaTime;

        if (m_createTime >= m_createSpeed)
        {
            m_createTime = 0f;
            CreatePipe();
        }
    }

    private void Update()
    {
        UpdateCreatePipe();
    }
}
