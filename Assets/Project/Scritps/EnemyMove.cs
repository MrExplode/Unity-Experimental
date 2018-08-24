using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour {

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
        _navMeshAgent.SetDestination(_player.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _animator.SetBool("Attack", true);
            Debug.Log("DAAAAAAA");
        }
    }
}
