using UnityEngine;

public class AnimatedSprite : MonoBehaviour
{
    public Sprite[] sprites;
    private SpriteRenderer spriteRenderer;
    private int frame;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnEnable()
    {
        Invoke(nameof(Animate), 0f);
    }
    private void OnDisable()
    {
        CancelInvoke();
    }
    private void Animate()
    {
        if (GameManager.instance == null || GameManager.instance.gameSpeed <= 0)
        {
            // Try again later (wait for game to start)
            Invoke(nameof(Animate), 0.1f);
            return;
        }

        frame++;
        if (frame >= sprites.Length)
        {
            frame = 0;
        }
        if (frame >= 0 && frame < sprites.Length)
        {
            spriteRenderer.sprite = sprites[frame];
        }
        Invoke(nameof(Animate), 1f / GameManager.instance.gameSpeed);
    }
}
