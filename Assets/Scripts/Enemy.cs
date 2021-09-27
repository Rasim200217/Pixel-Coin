using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _attackRange;
    [SerializeField] private float _walkDistance;

    private NavMeshAgent _agent;
    private LayerMask _layerPlayer;
    private LayerMask _layerGround;
    private Transform _playerPos;
    private Vector3 _walkPoint;
   
    private bool _playerInView;
    private bool _walkPoinSet;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _layerPlayer = LayerMask.GetMask("Player");
        _layerGround = LayerMask.GetMask("Ground");
        _playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        _playerInView = Physics.CheckSphere(transform.position, _attackRange, _layerPlayer);

        if (_playerInView) 
        {
            Attack();
         }
        else if (!_playerInView)
        {
            Patrolling();
        }
    }

    private void Attack()
    {
        _agent.SetDestination(_playerPos.position);
        transform.LookAt(_playerPos);
    }

    private void Patrolling()
    {
        if (!_walkPoinSet) SearchWalkPoint();

        if (_walkPoinSet) _agent.SetDestination(_walkPoint);

        Vector3 distance = transform.position - _walkPoint;
        if (distance.magnitude < 2f) _walkPoinSet = false;
    }

    private void SearchWalkPoint()
    {
        float x = Random.Range(-_walkDistance, _walkDistance);
        float z = Random.Range(-_walkDistance, _walkDistance);

        _walkPoint = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);

        if(Physics.Raycast(_walkPoint, -transform.up, 2f, _layerGround)) _walkPoinSet = true;
    }


}
