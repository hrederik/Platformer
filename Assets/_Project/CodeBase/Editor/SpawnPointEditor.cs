using CodeBase.Spawn;
using UnityEditor;
using UnityEngine;

namespace _Project.CodeBase.Editor
{
    [CustomEditor(typeof(SpawnPoint))]
    public class SpawnPointEditor : UnityEditor.Editor
    {
        [DrawGizmo(GizmoType.Active | GizmoType.Pickable | GizmoType.NonSelected)]
        public static void RenderGizmo(SpawnPoint point, GizmoType type)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(point.Position, radius: 0.5f);
        }
    }
}