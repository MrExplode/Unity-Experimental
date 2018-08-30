using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour {

    public ZombieSettings settings;

    private Animator _animator;
    private NavMeshAgent _navMeshAgent;
    private Transform _player;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, _player.position) < settings.ChaseDistance)
        {
            _navMeshAgent.speed = settings.ChaseSpeed;
        } else { 
            _navMeshAgent.speed = settings.NormalSpeed;
        }

        _navMeshAgent.SetDestination(_player.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.gameObject.GetComponent<PlayerInventory>().PickupCount > 0)
            {
                other.gameObject.GetComponent<PlayerInventory>().PickupCount--;
            }
            _animator.SetBool("Attack", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _animator.SetBool("Attack", false);
        }
    }
}
