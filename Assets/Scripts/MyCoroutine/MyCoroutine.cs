using UnityEngine;
using System.Collections;

/*Here time = the wait time in the game.
 Time.realtimeSinceStartup = the time for which the game is being played(like 15mins).
  */
public static class MyCoroutine  {
    
    public static IEnumerator WaitForRealSeconds(float time)
    {
        float start = Time.realtimeSinceStartup;

        while (Time.realtimeSinceStartup < start + time)
            yield return null;
    }
}
