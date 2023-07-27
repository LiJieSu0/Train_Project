using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventObserver
{
    public static GameObject currObj { get; set; }
    public static List<GameObject> FullProgress=new List<GameObject>();
    public static bool ProgressPaused = false;
}
