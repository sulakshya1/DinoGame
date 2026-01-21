using UnityEngine;

public class RandomYoffset : MonoBehaviour
{
    public int minHeight = 0;
    public int maxHeigth = 2;

    private void Start()
    {
        float RandomY = Random.Range(minHeight, maxHeigth);
        transform.position = new Vector3(transform.position.x, transform.position.y + RandomY, 0);
    }
}
