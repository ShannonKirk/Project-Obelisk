using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EnemyAI : MonoBehaviour{

    public Transform target;
    [SerializeField] bool isInView;
    float viewRadius = 10;
    float viewAngle = 110;
    int cycle = 10;
    int counter = 0;

    private void Start() {
        counter = Random.Range(0, 10);
    }

    public void Update() {
        FieldOfView();
    }

    void FieldOfView() {
        if (target == null) {
            isInView = false;
            return;
        }
        float distance = Vector3.Distance(target.position, transform.position);
        isInView = (distance < viewRadius);
        if (isInView) {
            Vector3 direction = target.position - transform.position;
            Vector3 rotDirection = direction;
            rotDirection.y = 0;
            if (rotDirection == Vector3.zero)
                rotDirection = transform.forward;
            float angle = Vector3.Angle(transform.forward, rotDirection);
            if (angle < viewAngle / 2) {
                RaycastHit hit;
                Vector3 origin = transform.position + Vector3.up;
                Debug.DrawRay(origin, direction * viewRadius);
                if (Physics.Raycast(origin, direction, out hit, viewRadius)) {
                    if (hit.transform.CompareTag(Tags.PLAYER)) {
                        Quaternion targetRotation = Quaternion.LookRotation(direction);
                        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 20);
                    }
                }
            }
        }
    }
}
