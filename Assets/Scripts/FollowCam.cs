using UnityEngine;

namespace DefaultNamespace
{
    public class FollowCam : MonoBehaviour
    {
        public Transform target;
        public float xDistance = -10.0f;
        public float zDistance = -10.0f;
        public float height = 5.0f;
        public float damping = 5.0f;
        
        private void LateUpdate()
        {
            Vector3 wantedPosition = target.transform.position + new Vector3(xDistance, height, zDistance);
            transform.position = Vector3.Lerp(transform.position, wantedPosition, Time.deltaTime * damping);
            transform.LookAt(target);
        }
    }
}