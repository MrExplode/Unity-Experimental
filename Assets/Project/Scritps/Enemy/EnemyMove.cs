using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Networking;

public class EnemyMove : NetworkBehaviour {

    private Animator _animator;
    private NavMeshAgent _navMeshAgent;
    public List<GameObject> Players = new List<GameObject>();

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (isServer && Players.Count > 0)
        {
            var minDistance = Players.Min(p => Vector3.Distance(p.transform.position, transform.position));
            var target = Players.FirstOrDefault(p => Vector3.Distance(p.transform.position, transform.position) == minDistance);
            if (target != null)
            {
                _navMeshAgent.SetDestination(target.transform.position);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isServer && other.CompareTag("Player"))
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
        if (isServer && other.CompareTag("Player"))
        {
            _animator.SetBool("Attack", false);
        }
    }
}
