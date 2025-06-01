using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField] private float m_Speed = 5f;
    private Transform m_transform = null;
    private Camera m_mainCamera = null;

    private float Aspect => m_mainCamera.aspect;
    private float CameraSize => m_mainCamera.orthographicSize;

    private void Awake()
    {
        m_transform = GetComponent<Transform>();
        m_mainCamera = Camera.main;
    }

    private void Start()
    {
        m_transform.position = new Vector2(Aspect * CameraSize + 1f, Random.Range(-CameraSize / 2 + 1f, CameraSize / 2));
    }

    private void Update()
    {
        //if(FluppyBirdManager.Instance.CurrentGameState != GameState.Play) return;

        float xPosition = -Aspect * CameraSize - 1f;
        m_transform.position = Vector2.MoveTowards(m_transform.position, new Vector2(xPosition, m_transform.position.y), m_Speed * Time.deltaTime);

        if(m_transform.position.x <= xPosition)
        {
            Destroy(gameObject); 
        }
    }
}
