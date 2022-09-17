using UnityEngine;

namespace Scripts
{
    public class InputKeyReader
    {
        public Vector2 ReadDirection()
        {
            var forward = Input.GetKey(KeyCode.W) ? 1 : 0;
            var right = Input.GetKey(KeyCode.D) ? 1 : 0;
            var left = Input.GetKey(KeyCode.A) ? -1 : 0;
            return new Vector2(forward, right + left);
        }
    }
}
