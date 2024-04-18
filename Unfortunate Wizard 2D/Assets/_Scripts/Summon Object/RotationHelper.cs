using System;
using UnityEngine;

public static class RotationHelper
{
    public static Rotations currentRotation = Rotations.Zero;
    
    public static void ChangeRotation()
    {
        currentRotation = (Rotations)(((int)currentRotation + 1) % 4);
    }
    
    public static Quaternion RotationToQuaternion(Rotations rotation)
    {
        switch (rotation)
        {
            case Rotations.Zero:
                return Quaternion.identity;
            case Rotations.Ninety:
                return Quaternion.Euler(0, 90, 0);
            case Rotations.OneEighty:
                return Quaternion.Euler(0, 180, 0);
            case Rotations.TwoSeventy:
                return Quaternion.Euler(0, 270, 0);
            default:
                throw new ArgumentOutOfRangeException(nameof(rotation), rotation, null);
        }
    }

    public static Quaternion RotationToQuaternion()
    {
        return RotationToQuaternion(currentRotation);
    }
    public enum Rotations
    {
        Zero,
        Ninety,
        OneEighty,
        TwoSeventy
    }
}