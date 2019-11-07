using UnityEngine;

public class MovingCapsules : MonoBehaviour
{
    Vector3 moveDirection;
    float currentTransform;
    bool SwitchingBetweenClimbs;

    private void Start()
    {
        currentTransform = Random.Range(1.5f, 1.8f);
        transform.position = new Vector3(transform.position.x, currentTransform, transform.position.z);
    }

    void FixedUpdate()
    {
        if (transform.position.y <= 1.8f && SwitchingBetweenClimbs == false) currentTransform += Time.deltaTime * 0.2f;
        else SwitchingBetweenClimbs = true;
        if (transform.position.y >= 1.4f && SwitchingBetweenClimbs == true) currentTransform -= Time.deltaTime * 0.2f;
        else SwitchingBetweenClimbs = false;
        transform.position = new Vector3(transform.position.x, currentTransform, transform.position.z);
    }
}