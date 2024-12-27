using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public void ChangeColor(Renderer renderer)
    {
        renderer.material.color = UnityEngine.Random.ColorHSV();
    }
}
