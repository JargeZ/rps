using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CharHands
{
    public static string Rock = "rock";
    public static string Paper = "paper";
    public static string Scissors = "scissors";
    public static string Idle = "idle";
}

public class CharController : MonoBehaviour
{
    private Animator _animator;
    private SpriteSwapper _spriteSwapper;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _spriteSwapper = GetComponentInChildren<SpriteSwapper>();
    }

    public Animator GetAnimator()
    {
        return _animator;
    }

    public void SetAnimation(string animation)
    {
        Debug.Log("Set animation: " + animation);
        if (_animator == null)
        {
            Debug.LogWarning(
                "Animator is null, this is костыль to quick fix but it should not be called unless anumator is available"
            );
            return;
        }

        _animator.SetTrigger(animation);
    }

    public void SetHand(string hand)
    {
        if (_spriteSwapper == null)
        {
            Debug.LogWarning( "No sprite swapper found, ignoring hand change." );
            return;
        }
        _spriteSwapper.SetHand(hand);
    }


}
