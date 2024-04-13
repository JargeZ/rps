using UnityEngine;
using UnityEngine.U2D.Animation;

public class SpriteSwapper : MonoBehaviour
{
    private SpriteResolver spriteResolver;

    void Start()
    {
        spriteResolver = GetComponent<SpriteResolver>();
    }

    public void SetHand(string hand)
    {
        spriteResolver.SetCategoryAndLabel("hands", hand);
    }
    public void SetFace(string body)
    {
        spriteResolver.SetCategoryAndLabel("hands", body);
    }
}