using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

[CreateAssetMenu(menuName = "ScriptableObjects/RouteVideo")]
public class RouteVideo : ScriptableObject
{
        public VideoClip clip;
        public List<RouteChoice> possibilities;
        [Header("Optional")]
        public string videoPath = "../Ressources/Video/";

}