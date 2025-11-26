using UnityEngine;

public class EnemyFollow2D : MonoBehaviour
{
    public float speed = 3f;
    public Transform target;
    public bool isChasing = false;

    private void Update()
    {
        if (isChasing && target != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
            transform.LookAt(target);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            SetTarget(other.transform);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            ClearTarget();
        }
    }
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
        isChasing = true;
    }
    public void ClearTarget()
    {
        isChasing = false;
        target = null;
    }
}
