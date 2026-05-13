using UnityEngine;

public class Ground : MonoBehaviour
{
    private MeshRenderer meshrenderer;

    private void Awake()
    {
        meshrenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        float speed = GameManager.Instance.gamespeed / transform.localScale.x;
        meshrenderer.material.mainTextureOffset += Vector2.right * speed * Time.deltaTime;
    }
}