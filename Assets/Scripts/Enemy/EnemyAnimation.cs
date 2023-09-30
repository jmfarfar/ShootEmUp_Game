using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    public Animator enemyAnimator;
    private int flyingAnimationHash = Animator.StringToHash("Flying");

    // Start is called before the first frame update
    void Start()
    {

        enemyAnimator.Play(flyingAnimationHash, 0, Random.value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
