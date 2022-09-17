using UnityEngine;

namespace Scripts
{
    public static class TransformExtension
    {
        public static Vector3 GetNormalizeDirection(this Transform self, Transform to)
        {
            return (to.position - self.position).normalized;
        }
    }
}
