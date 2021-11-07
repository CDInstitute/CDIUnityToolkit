using UnityEngine;

namespace CDI.Toolkit.Mathematics
{
    public static class MathExtensions
    {
        public static float ClampAngle(float angle, float min, float max)
        {
            if (angle < -MathConstants.MaxAngleDegrees)
                angle += MathConstants.MaxAngleDegrees;
            if (angle > MathConstants.MaxAngleDegrees)
                angle -= MathConstants.MaxAngleDegrees;
            return Mathf.Clamp(angle, min, max);
        }
    }
}