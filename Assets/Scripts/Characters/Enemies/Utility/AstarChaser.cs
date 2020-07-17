using Characters.Enemies.Interfaces;
using Characters.Player.Interfaces;
using Pathfinding;
using UnityEngine;

namespace Characters.Enemies.Utility
{
    public class AstarChaser : Seeker, IChaser
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private float minChaseDistance;
        [SerializeField] private float targetReachDistanceThreshold;
        [SerializeField] private new Rigidbody2D rigidbody;

        private bool canChase;
        private Path currentPath;
        private int currentWaypointIndex;
        private ITargetable currentTarget;
        private const float WaypointReachDistanceThreshold = 0.05f;

        public float TargetDirection => currentTarget.Position.x - transform.position.x;
        public bool ReachedTarget => DistanceToCurrentTarget() <= targetReachDistanceThreshold;

        private void Start()
        {
            InvokeRepeating(nameof(SetupSeeker), 0.5f, 0.5f);
        }

        private void FixedUpdate()
        {
            if (currentPath == null)
            {
                return;
            }
            
            UpdateCurrentPath();
            TryMoving();
        }

        public void StartChasing(ITargetable targetToChase)
        {
            currentTarget = targetToChase;
            canChase = true;
        }

        public void StopChasing()
        {
            rigidbody.velocity = Vector2.zero;
            currentPath = null;
            canChase = false;
            
            CancelCurrentPathRequest();
            ReleaseClaimedPath();
        }
        
        private void SetupSeeker()
        {
            if (!canChase || ((Vector2) transform.position - currentTarget.Position).magnitude > minChaseDistance)
            {
                return;
            }
            
            StartPath(transform.position, currentTarget.Position, SetupNextPath);
        }

        private void SetupNextPath(Path nextPath)
        {
            if (nextPath.error)
            {
                return;
            }

            currentWaypointIndex = 0;
            currentPath = nextPath;
        }

        private void UpdateCurrentPath()
        {
            if (DistanceToCurrentWaypoint() > WaypointReachDistanceThreshold)
            {
                return;
            }

            if (++currentWaypointIndex < currentPath.vectorPath.Count)
            {
                return;
            }

            currentPath = null;
        }

        private void TryMoving()
        {
            if (currentPath == null)
            {
                return;
            }

            Vector2 moveDirection = DirectionToCurrentWaypoint();
            rigidbody.velocity = moveSpeed * moveDirection;
        }

        private float DistanceToCurrentTarget()
        {
            Vector2 reposition = currentTarget.Position - (Vector2) transform.position;
            return reposition.magnitude;
        }

        private float DistanceToCurrentWaypoint()
        {
            Vector2 reposition = (Vector2) currentPath.vectorPath[currentWaypointIndex] - (Vector2) transform.position;
            return reposition.magnitude;
        }
        
        private Vector2 DirectionToCurrentWaypoint()
        {
            Vector2 reposition = (Vector2) currentPath.vectorPath[currentWaypointIndex] - (Vector2) transform.position;
            return reposition.normalized;
        }
    }
}