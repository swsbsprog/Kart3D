using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureAnimationController : MonoBehaviour
{
    public Texture2D[] textures;
    public float interval = 0.1f;
    public new Renderer renderer;
    private IEnumerator Start()
    {
        renderer = GetComponent<Renderer>();
        int index = 0;
        while (true)
        {
            renderer.material.mainTexture = textures[index];
            yield return new WaitForSeconds(interval);
            index++;
            if (index >= textures.Length)
                index = 0;
        }
    }
}
