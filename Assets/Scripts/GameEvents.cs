using System;
using UnityEngine.Video;

public struct GameEvents
{
        public Action<RouteChoice> OnChoiceMade;
        public Action<VideoClip> OnVideoSelected;
        public Action OnVideoEnd;
        public Action OnStartProj;
}