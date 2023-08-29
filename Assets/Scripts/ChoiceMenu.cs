using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class ChoiceMenu : Manager
{
        [SerializeField] private GameObject choiceCardPrefab;
        [SerializeField] private Transform cardHolder;
        [SerializeField] private GameObject menuObject;
        [SerializeField] private ChoiceManager choiceManager;

        private List<GameObject> _currentCards;

        private void Awake()
        {
                if (cardHolder == null) cardHolder = this.transform;
                _currentCards = new List<GameObject>();
                
                menuObject.gameObject.SetActive(false);
        }

        private void OnEnable()
        {
                manager.Events.OnVideoEnd += VideoEnd;
        }

        private void OnDisable()
        {
                manager.Events.OnVideoEnd -= VideoEnd;
        }

        private void VideoEnd()
        {
                SetChoiceMenu();
                DisplayChoiceMenu();
        }

        private void SetChoiceMenu()
        {
                var elt = choiceManager.GetCurrentChoices();

                foreach (var route in elt)
                {
                        if (choiceCardPrefab == null) return;
                        var newCard = Instantiate(choiceCardPrefab, cardHolder);

                        if (newCard.TryGetComponent(out ChoiceCard choiceCard))
                        {
                                choiceCard.SetButton(route.description, () => ButtonBehaviour(route));
                        }
                        else
                        {
                                Debug.LogWarning("The choice card prefab has not the required script");
                                return;
                        }
                        
                        _currentCards.Add(newCard);
                }
        }

        private void ButtonBehaviour(RouteChoice route)
        {
                manager.Events.OnChoiceMade?.Invoke(route);
                DeleteMenuElements();
                menuObject.gameObject.SetActive(false);
        }

        private void DeleteMenuElements()
        {
                foreach (var card in _currentCards)
                {
                       Destroy(card); 
                }

                _currentCards = new List<GameObject>();
        }
        
        private void DisplayChoiceMenu()
        {
                menuObject.gameObject.SetActive(true);       
        }
}