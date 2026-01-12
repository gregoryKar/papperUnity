using UnityEngine;


namespace my3dtest
{
    public class my3DGizmo : MonoBehaviour
    {

        [SerializeField] Vector3 _gizmoSize;
        [SerializeField] bool _wire;


        [SerializeField] Color _gizmoColor;

        void OnDrawGizmos()
        {
            Gizmos.color = _gizmoColor;
            if (_wire) Gizmos.DrawWireCube(transform.position, _gizmoSize);
            else Gizmos.DrawCube(transform.position, _gizmoSize);

        }
    }
}