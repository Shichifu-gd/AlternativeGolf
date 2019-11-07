using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] new Rigidbody rigidbody;
    [SerializeField] LevelManager levelManager;

    [SerializeField]
    float Force = 0;
    float ForceFJ = 0;
    float MaxForce = 800;
    float CurrentScale = 1f;
    float OldCoordinatesY;
    int NumberOfAttempts;
    [SerializeField]
    bool ImmortalityRegime;

    private void Start()
    {
        transform.localScale = new Vector3(CurrentScale, CurrentScale, CurrentScale);
        OldCoordinatesY = transform.position.y;
    }

    private void FixedUpdate()
    {
        if (OldCoordinatesY == transform.position.y)
        {
            if (Input.GetMouseButton(0))
            {
                Force += 50;
                if (Force > MaxForce) Force = MaxForce;
            }
            if (Input.GetMouseButtonUp(0)) HitTheBall();
        }
        OldCoordinatesY = transform.position.y;
    }

    private void HitTheBall()
    {
        DenoteTheDirection();
        ForceFJ = Force / 5;
        rigidbody.AddRelativeForce(0, ForceFJ, Force);
        if (ImmortalityRegime == false) SizePlayer();
        Force = 0;
    }

    void SizePlayer()
    {
        if (NumberOfAttempts != 0)
        {
            if (Force > 400) CurrentScale -= (Force / MaxForce) / 10;
            else CurrentScale -= 0.02f;
            transform.localScale = new Vector3(CurrentScale, CurrentScale, CurrentScale);
            if (CurrentScale <= 0.20f) levelManager.LevelRestart();
        }
        NumberOfAttempts++;
    }

    private void DenoteTheDirection()
    {
        Ray MousePosition = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, Vector3.zero);
        float rayLenght;
        if (plane.Raycast(MousePosition, out rayLenght))
        {
            Vector3 point = MousePosition.GetPoint(rayLenght);
            transform.LookAt(new Vector3(point.x, transform.position.y, point.z));
            // Debug.DrawLine(MousePosition.origin, point, Color.blue);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick up"))
        {
            levelManager.TaskPerformance();
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Finish")) levelManager.NextLevel();
    }
}