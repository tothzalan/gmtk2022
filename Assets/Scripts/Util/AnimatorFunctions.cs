using System.Collections;
using UnityEngine;

namespace Util
{
    public static class AnimatorFunctions
    {
        public static IEnumerator WaitForAnimation ( Animation animation )
        {
            do
            {
                yield return null;
            } while ( animation.isPlaying );
        }
    }
}