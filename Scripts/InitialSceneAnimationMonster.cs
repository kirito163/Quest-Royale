using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialSceneAnimationMonster : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
        animator.SetBool("isInitial", true);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
