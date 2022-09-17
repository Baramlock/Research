using UnityEngine;

public class LaserWeaponDrawer
{
    private readonly Transform _transform;
    private readonly LineRenderer _lineRenderer;
    public Color CurrentColor = Color.blue;

    public LaserWeaponDrawer(LineRenderer lineRenderer, Transform transform)
    {
        _lineRenderer = lineRenderer;
        _transform = transform;
    }

    public void Clear()
    {
        _lineRenderer.positionCount = 0;
    }

    public void DrawLine(Enemy target)
    {
        _lineRenderer.startColor = CurrentColor;
        _lineRenderer.endColor = CurrentColor;

        if (Physics.Raycast(new Ray(_transform.position, target.transform.position - _transform.position), out var hit))
        {
            if (hit.collider.TryGetComponent(out Enemy enemy))
            {
                if (enemy == target)
                {
                    _lineRenderer.positionCount = 2;

                    _lineRenderer.SetPositions(new[]
                        {Vector3.zero, _transform.InverseTransformPoint(target.transform.position)});
                }
                else
                {
                    _lineRenderer.positionCount = 3;

                    var enemyTransform = enemy.transform;

                    var hightPosition =
                        _transform.InverseTransformPoint(enemyTransform.position +
                                                         enemyTransform.localScale.y * 1.5f * Vector3.up);

                    var positions = new[]
                    {
                        Vector3.zero,
                        hightPosition,
                        _transform.InverseTransformPoint(target.transform.position)
                    };
                    _lineRenderer.SetPositions(positions);
                }
            }
        }
    }
}
