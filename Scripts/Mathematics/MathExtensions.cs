using UnityEngine;

namespace CDI.Toolkit.Mathematics
{
    /// <summary>
    /// Extensions for mathematical operations.
    /// </summary>
    public static class MathExtensions
    {
        /// <summary>
        /// Clamp an angle between a minimum and maximum value.
        /// </summary>
        /// <param name="angle">The angle to clamp.</param>
        /// <param name="min">The minimum angle</param>
        /// <param name="max">The maximum angle.</param>
        /// <returns>The clamped angle.</returns>
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