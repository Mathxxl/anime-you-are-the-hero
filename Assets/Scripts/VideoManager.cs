using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : Manager
{
        [SerializeField] private VideoPlayer videoPlayer;
        private Coroutine _frameRoutine;

        private void OnEnable()
        {
                manager.Events.OnVideoSelected += VideoSelected;
        }

        private void OnDisable()
        {
                manager.Events.OnVideoSelected += VideoSelected;
        }

        private void PlayVideo()
        {
                if (videoPlayer == null)
                {
                        Debug.LogWarning("Trying to play a video with no video player");
                        return;
                }
                
                StopVideo();
                videoPlayer.Play();

                if(_frameRoutine != null) StopCoroutine(_frameRoutine);
                _frameRoutine = StartCoroutine(CheckFrameForVideoEnd());
        }

        private void ChangeVideo(VideoClip clip)
        {
                videoPlayer.source = VideoSource.VideoClip;
                videoPlayer.clip = clip;
        }

        private void ChangeVideoUrl(string url)
        {
                videoPlayer.source = VideoSource.Url;
                videoPlayer.url = url;
        }

        private void StopVideo()
        {
                videoPlayer.Stop();
        }

        private IEnumerator CheckFrameForVideoEnd()
        {
                Debug.Log($"CheckFrameForVideoEnd Routine start");

                if (videoPlayer == null) yield break;

                while (videoPlayer.frameCount == 0)
                {
                        yield return null;
                }
                
                Debug.Log($"Frames to go : {videoPlayer.frameCount}");
                
                while (videoPlayer.frame < (long)videoPlayer.frameCount - 2)
                {
                        //Debug.Log($"Playing {videoPlayer.frame} / {videoPlayer.frameCount}");
                        yield return null;
                }
                videoPlayer.Pause();
                Debug.Log("Video Finished");
                manager.Events.OnVideoEnd?.Invoke();
        }

        private void VideoSelected(RouteVideo route)
        {
                var clip = route.clip;
                if (clip != null)
                {
                        ChangeVideo(clip);
                }
                else
                {
                        ChangeVideoUrl(route.videoPath);
                }
                
                PlayVideo();
        }
}