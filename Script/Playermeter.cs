using TMPro;
using UnityEngine;

public class Playermeter : MonoBehaviour
{
    public Transform player;                  // Player reference
    public TextMeshProUGUI heightText;        // UI Text for showing height

    private float startingY;                  // Initial Y position
    private float displayedHeight = 0f;       // Value shown on screen
    private float speed = 5f;                 // Smooth speed

    void Start()
    {
        if (player != null)
            startingY = player.position.y;    // Set starting height
    }

    void Update()
    {
        if (player == null || heightText == null) return;

        float targetHeight = player.position.y - startingY;

        targetHeight = Mathf.Max(0f, targetHeight);

        displayedHeight = Mathf.Lerp(displayedHeight, targetHeight, Time.deltaTime * speed);

        heightText.text = Mathf.FloorToInt(displayedHeight).ToString() + "m";
    }
}