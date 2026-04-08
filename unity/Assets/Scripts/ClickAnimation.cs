using UnityEngine;

public class ClickAnimation : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnMouseDown()
    {
        animator.SetTrigger("PlayAnim");
    }
}
