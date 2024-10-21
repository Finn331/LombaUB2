using UnityEngine;

public class PlayerDepth : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Mengubah order rendering berdasarkan posisi Y player
        spriteRenderer.sortingOrder = -(int)(transform.position.y * 100);
    }
}
