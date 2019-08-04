using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using System.Diagnostics;
using UnityEngine.Assertions;

namespace JPL.Debugging
{
    [DebuggerStepThrough]
    public static class Assertion
    {
        const string symbol = "UNITY_ASSERTIONS";


        [Conditional(symbol)]
        public static void IsSane(float f)
        {
            Assert.IsFalse(float.IsNaN(f));
            Assert.IsFalse(float.IsInfinity(f));
        }

        [Conditional(symbol)]
        public static void IsSane(float f, string msg)
        {
            Assert.IsFalse(float.IsNaN(f), msg);
            Assert.IsFalse(float.IsInfinity(f), msg);
        }

        [Conditional(symbol)]
        public static void IsSane(float2 f)
        {
            IsSane(f.x);
            IsSane(f.y);
        }

        [Conditional(symbol)]
        public static void IsSane(float2 f, string msg)
        {
            IsSane(f.x, msg);
            IsSane(f.y, msg);
        }

        [Conditional(symbol)]
        public static void IsSane(float3 f)
        {
            IsSane(f.x);
            IsSane(f.y);
            IsSane(f.z);
        }

        [Conditional(symbol)]
        public static void IsSane(float3 f, string msg)
        {
            IsSane(f.x, msg);
            IsSane(f.y, msg);
            IsSane(f.z, msg);
        }
    }
}
