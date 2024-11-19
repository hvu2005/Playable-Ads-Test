using DG.Tweening;
using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase3 : MonoBehaviour
{
    private PlayerBehave player;
    private SkeletonAnimation sa;
    private Rigidbody2D rb;
    [SerializeField] private GameObject standPoint;
    [SerializeField] private float moveSpeed;
    [SerializeField] private string[] attack;
    [SerializeField] private float attackTime;
    private float attackTimeCounter;
    private int attackIndex;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
        sa = GetComponent<SkeletonAnimation>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehave>();
        attackTimeCounter = attackTime;
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        attackTimeCounter -= Time.deltaTime; 
        if(attackTimeCounter < 0f)
        {
            attackIndex += attackIndex == 1 ? -1 : 1;
            StartCoroutine(Attack(attackIndex));
            attackTimeCounter = attackTime;
        }
    }
    #region Boss
    private IEnumerator Attack(int i)
    {
        sa.AnimationState.SetAnimation(0, attack[i] , false);
        rb.velocity = new Vector2(0f, -moveSpeed);
        yield return new WaitForSeconds(0.25f);
        rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(0.75f);
        sa.AnimationState.SetAnimation(0, "idle_offset", true);
        rb.velocity = new Vector2(0f, moveSpeed);
        yield return new WaitForSeconds(0.25f);
        rb.velocity = Vector2.zero;
    }
    private IEnumerator Spawn()
    {
        InputManager.instance.canAction = false;
        player.transform.DOMove(standPoint.transform.position,0.65f);
        rb.velocity = new Vector2 (0f, -moveSpeed);
        yield return new WaitForSeconds(0.65f);
        rb.velocity = Vector2.zero;
    }
    #endregion
}
