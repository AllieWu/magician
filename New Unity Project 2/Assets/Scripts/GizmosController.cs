using UnityEngine;
using System.Collections;

public class GizmosController : MonoBehaviour
{
    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;

        if (GetComponent<EnemySpawner>() != null)
        {
            Gizmos.DrawSphere(transform.position, GetComponent<EnemySpawner>().spawnRadius);
        }
        
    }

    /*
    private void OnDrawGizmos()
    {
        UnityEditor.Handles.color = Color.yellow;
        CircleCollider2D[] colliders = FindObjectsOfType(typeof(CircleCollider2D)) as Collider2D[];
        foreach (CircleCollider2D collider in colliders)
        {
            UnityEditor.Handles.DrawWireDisc(collider.transform.position, Vector3.back, collider.radius);
        }
    }
    */
    
}