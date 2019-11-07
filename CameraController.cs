using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Player;

    private Vector3 OffVT;

    private void Start()
    {
        OffVT = transform.position - Player.transform.position;
    }

    private void LateUpdate()
    {
        transform.position = Player.transform.position + OffVT;
    }
}