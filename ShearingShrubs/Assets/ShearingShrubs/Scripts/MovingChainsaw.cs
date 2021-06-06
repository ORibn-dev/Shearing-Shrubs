using UnityEngine;

public class MovingChainsaw : MonoBehaviour
{
    [Header("Chainsaw movement borders")]
    [SerializeField] private float borderX1;
    [SerializeField] private float borderX2;
    [SerializeField] private float borderY1;
    [SerializeField] private float borderY2;
    [Space]
    [SerializeField] private float speed;

    private Touch touch;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(
                Mathf.Clamp(transform.position.x + touch.deltaPosition.x * speed, borderX1, borderX2),
                Mathf.Clamp(transform.position.y + touch.deltaPosition.y * speed, borderY1, borderY2),
                transform.position.z);
            }
        }
    }
}
