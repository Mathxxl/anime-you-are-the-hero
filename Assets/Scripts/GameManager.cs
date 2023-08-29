using System;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
        public GameEvents Events;

        private void Start()
        {
                StartCoroutine(Setup());
        }

        private IEnumerator Setup()
        {
                yield return null;
                Events.OnStartProj?.Invoke();
        }
}