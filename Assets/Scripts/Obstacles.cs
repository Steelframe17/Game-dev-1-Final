using UnityEngine;

public class Obstacles : MonoBehaviour
{
    private float leftEdge;

    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }

    private void Update()
    {
        transform.position += GameManager.Instance.gamespeed * Time.deltaTime * Vector3.left;

        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
    }

}
