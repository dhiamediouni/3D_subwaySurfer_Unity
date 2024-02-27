using UnityEngine;

public class InputTouch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                Vector2 pos = touch.position;

                // Check for division by zero
                float screenWidth = Mathf.Max(1f, Screen.width);
                float screenHeight = Mathf.Max(1f, Screen.height);

                // Map touch position to screen center
                float halfScreenWidth = screenWidth / 2.0f;
                float halfScreenHeight = screenHeight / 2.0f;

                pos.x = (pos.x - halfScreenWidth) / halfScreenWidth;
                pos.y = (pos.y - halfScreenHeight) / halfScreenHeight;

                // Optionally, adjust sensitivity
                float sensitivity = 1.0f;
                pos *= sensitivity;

                // Update object's position
                Vector3 newPosition = new Vector3(pos.x, transform.position.y, pos.y);
                transform.position = newPosition;
            }
        }
    }
}
