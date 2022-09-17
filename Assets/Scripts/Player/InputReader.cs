using System;
using UnityEngine;

namespace Scripts
{
    public static class InputReader
    {
        private static Camera Camera => Lazy.Value;
        private static readonly Lazy<Camera> Lazy = new Lazy<Camera>(() => Camera.main);

        public static Vector2 ReadDirection()
        {
            var forward = Input.GetKey(KeyCode.W) ? 1 : 0;
            var right = Input.GetKey(KeyCode.D) ? 1 : 0;
            var left = Input.GetKey(KeyCode.A) ? -1 : 0;
            return new Vector2(forward, right + left);
        }

        public static bool ClickOn<T>(out T target)
        {
            if (ClickOn(out var hit) && hit.collider.gameObject.TryGetComponent(out T findObject))
            {
                target = findObject;
                return true;
            }

            target = default;
            return false;
        }

        public static bool ClickOn(out RaycastHit hit)
        {
            if (Physics.Raycast(Camera.ScreenPointToRay(Input.mousePosition), out var raycastHit))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    hit = raycastHit;
                    return true;
                }
            }

            hit = default;
            return false;
        }
    }
}
