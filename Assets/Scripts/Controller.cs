using UnityEngine;
using UnityEngine.AI;

namespace DefaultNamespace
{
    public class Controller : MonoBehaviour
    {
        // Gets a navmesh agent and moves into a clicked position on a navmesh
        public NavMeshAgent agent;
        
        private Camera cam;
        
        void Start()
        {
            cam = GetComponent<Camera>();
        }
        
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    agent.SetDestination(hit.point);
                }
            }
        }
        
    }
}