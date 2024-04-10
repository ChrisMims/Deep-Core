using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class ShotPreview : MonoBehaviour
{
    public float raycastDistance = 10f;
    public int maxReflections = 3;

    void Update()
    {
        CastRay(transform.position, transform.up, maxReflections);
    }

    void CastRay(Vector2 origin, Vector2 direction, int remainingReflections)
    {
        if (remainingReflections <= 0)
            return;

        // Cast a ray from the origin in the given direction
        RaycastHit2D hit = Physics2D.Raycast(origin, direction, raycastDistance);

        // Check if the ray hits something
        if (hit.collider != null)
        {
            Debug.Log("Raycast hit: " + hit.collider.gameObject.name);

            // Calculate the reflection direction based on the surface normal
            Vector2 reflectionDirection = Vector2.Reflect(direction, hit.normal);

            // Draw the reflection ray in the Scene view for debugging purposes
            Debug.DrawRay(hit.point, reflectionDirection * raycastDistance, Color.blue);

            // Recursive call for next reflection
            CastRay(hit.point, reflectionDirection, remainingReflections - 1);
        }

        // Draw the initial ray in the Scene view for debugging purposes
        Debug.DrawRay(origin, direction * raycastDistance, Color.green);
    }
}