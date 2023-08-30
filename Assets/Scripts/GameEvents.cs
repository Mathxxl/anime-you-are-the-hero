using System;
using UnityEngine.Video;

public struct GameEvents
{
        public Action<RouteChoice> OnChoiceMade;
        public Action<RouteVideo> OnVideoSelected;
        public Action OnVideoEnd;
        public Action OnStartProj;
}