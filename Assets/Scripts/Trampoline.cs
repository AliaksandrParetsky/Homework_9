using System;
using System.Collections;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    private Animator animator;
    public Animator Animator { get { if (animator == null) animator = GetComponent<Animator>(); return animator; } }

    private float timeStopAnim = 0.5f;

    private IEnumerator StopAnim()
    {
        yield return new WaitForSeconds(timeStopAnim);
        Animator.SetBool("isCollision", false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Animator.SetBool("isCollision", true);

        StartCoroutine(StopAnim());
    }
}
