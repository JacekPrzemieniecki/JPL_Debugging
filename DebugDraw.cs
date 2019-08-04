using UnityEngine;

namespace JPL.Debugging
{
    public static class JPLDebug
    {
        public static void DrawBox(Vector3 center, Vector3 extent, Quaternion rotation, Color color, float time = 0)
        {
            //    v3 --- v2   y  z
            //   /|     /|    | /
            // v0 --- v1 |    |/
            // |  v7--|- v6   -----x
            // | /    | /   
            // v4 --- v5   
            //
            // extent goes fromt center to v2
            var x = extent.x;
            var y = extent.y;
            var z = extent.z;

            var v0 = center + rotation * new Vector3(-x, y, -z);
            var v1 = center + rotation * new Vector3(x, y, -z);
            var v2 = center + rotation * new Vector3(x, y, z);
            var v3 = center + rotation * new Vector3(-x, y, z);
            var v4 = center + rotation * new Vector3(-x, -y, -z);
            var v5 = center + rotation * new Vector3(x, -y, -z);
            var v6 = center + rotation * new Vector3(x, -y, z);
            var v7 = center + rotation * new Vector3(-x, -y, z);

            Debug.DrawLine(v0, v1, color, time);
            Debug.DrawLine(v1, v5, color, time);
            Debug.DrawLine(v5, v4, color, time);
            Debug.DrawLine(v4, v0, color, time);
            Debug.DrawLine(v0, v3, color, time);
            Debug.DrawLine(v1, v2, color, time);
            Debug.DrawLine(v5, v6, color, time);
            Debug.DrawLine(v4, v7, color, time);
            Debug.DrawLine(v3, v2, color, time);
            Debug.DrawLine(v2, v6, color, time);
            Debug.DrawLine(v6, v7, color, time);
            Debug.DrawLine(v7, v3, color, time);
        }

        public static void DrawBox(Vector3 center, Vector3 extent, Color color) 
            => DrawBox(center, extent, Quaternion.identity, color);

        public static void DrawBox(Vector3 center, Vector3 extent) 
            => DrawBox(center, extent, Quaternion.identity, Color.white);

        public static void DrawSphere(Vector3 center, float radius, Color color, float time = 0)
        {
            DrawCircle(center, Vector3.up, radius, color, time);
            DrawCircle(center, Vector3.right, radius, color, time);
            DrawCircle(center, Vector3.forward, radius, color, time);
        }

        public static void DrawCircle(Vector3 center, Vector3 axis, float radius, Color color, float time = 0)
        {
            const int NumVerts = 32;
            var rotStep = Quaternion.AngleAxis(360.0f / NumVerts, axis);
            var current = radius *
                (Mathf.Approximately(
                Vector3.Dot(Vector3.up, axis), 1)
                ? Vector3.Cross(axis, Vector3.left)
                : Vector3.Cross(axis, Vector3.up));

            for (int i = 0; i < 32; i++)
            {
                var next = rotStep * current;
                var from = center + current;
                var to = center + next;
                Debug.DrawLine(from, to, color, time);
            }
        }
    }
}