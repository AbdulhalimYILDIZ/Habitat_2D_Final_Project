using UnityEngine;

public class GroundTextureOffset : MonoBehaviour
{
    public float textureSpeed = 1f; // Texture hızı
    Renderer groundRenderer; // Zemin Renderer bileşeni
    Vector2 offset; // Texture ofseti

    void Start()
    {
        groundRenderer = GetComponent<Renderer>(); // Zemin Renderer bileşenini al
    }

    void Update()
    {
        // Karakterin x ekseni hareketini al
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        // Texture ofsetini güncelle
        offset += new Vector2(horizontalInput * textureSpeed * Time.deltaTime, 0f);

        // Zemin materyaline ofseti uygula
        groundRenderer.material.mainTextureOffset = offset;
    }
}
