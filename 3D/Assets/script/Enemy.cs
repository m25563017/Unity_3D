using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private Transform player;
    private NavMeshAgent nav;
    private Animator ani;
    private float timer;
    [Header("移動速度"), Range(0, 50)]
    public float speed = 3;
    [Header("停止距離"), Range(0, 50)]
    public float stopDistance = 2.5f;
    [Header("攻擊冷卻時間"), Range(0, 50)]
    private float CD = 2f;


    private void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        ani = GetComponent<Animator>();
        player = GameObject.Find("小名").transform;
        nav.speed = speed;
        nav.stoppingDistance = stopDistance;
    }

    private void Update()
    {
        Track();
        Attack();
    }

    private void Track()
    {
        nav.SetDestination(player.position);
        print("剩餘的距離：" + nav.remainingDistance);
        ani.SetBool("走路開關", nav.remainingDistance>stopDistance);
    }
    private void Attack()
    {
        if (nav.remainingDistance<stopDistance)
        {
            timer += Time.deltaTime;

            Vector3 pos = player.position;
            pos.y = transform.position.y;

            transform.LookAt(pos);

            if (timer>CD)
            {
                ani.SetTrigger("攻擊");
                timer = 0;
            }
            
            
        }
    }
    
}
