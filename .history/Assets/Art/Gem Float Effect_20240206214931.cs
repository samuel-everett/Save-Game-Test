using UnityEngine;

public class BobAndSpin : MonoBehaviour
{
    public float bobSpeed = 1f; // Speed of bobbing
    public float bobHeight = 0.5f; // Height of bobbing motion
    public float spinSpeed = 50f; // Speed of spinning

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Bobbing motion along the y-axis
        Vector3 bobbingMotion = startPosition;
        bobbingMotion.y += Mathf.Sin(Time.time * bobSpeed) * bobHeight;
        transform.position = bobbingMotion;

        // Spinning motion around the y-axis
        transform.Rotate(new Vector3(0, 1, 0), spinSpeed * Time.deltaTime);
    }
}
