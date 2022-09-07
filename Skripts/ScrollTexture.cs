using UnityEngine;


// scrolling the texture on the object

public class ScrollTexture : MonoBehaviour
{
    public float scrollSpeed = 0.5f;
    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        // give speed
        float offset = Time.time * scrollSpeed;

        // change the position of the texture
        rend.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
