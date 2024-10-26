using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    public Transform[] waypoints; // Array untuk menyimpan waypoints
    public float moveSpeed = 2.0f; // Kecepatan gerak NPC
    private int currentWaypointIndex = 0; // Indeks waypoint saat ini

    void Update()
    {
        // Pastikan waypoint diisi
        if (waypoints.Length == 0) return;

        // Tentukan waypoint tujuan
        Transform targetWaypoint = waypoints[currentWaypointIndex];
        
        // Tentukan arah ke waypoint
        Vector2 direction = (targetWaypoint.position - transform.position).normalized;
        transform.position = Vector2.MoveTowards(transform.position, targetWaypoint.position, moveSpeed * Time.deltaTime);
        
        // Jika NPC mencapai waypoint
        if (Vector2.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            // Pergi ke waypoint berikutnya
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                // NPC berhenti di waypoint terakhir
                currentWaypointIndex = waypoints.Length - 1;
            }
        }
    }
}
