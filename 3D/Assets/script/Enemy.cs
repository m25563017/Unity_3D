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
    [Header("攻擊中心點")]
    public Transform atkPoint;
    [Header("攻擊長度"), Range(0f, 5f)]
    public float atkLength;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(atkPoint.position, atkPoint.forward  *atkLength);
    }



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
        //print("剩餘的距離：" + nav.remainingDistance);
        ani.SetBool("走路開關", nav.remainingDistance>stopDistance);
    }
    private RaycastHit hit;
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
                if(Physics.Raycast(atkPoint.position, atkPoint.forward,out hit, atkLength, 1 << 8));
                {
                    hit.collider.GetComponent<Player>().Damage();
                } 
            }
            
            
            
        }
    }
    
}
