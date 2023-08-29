using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ChoiceCard : MonoBehaviour
{
        [SerializeField] private Button choiceButton;
        [SerializeField] private TextMeshProUGUI textDescription;

        public void SetButton(string description, UnityAction function)
        {
                if (choiceButton == null) return;
                
                if (textDescription != null) textDescription.text = description;
                
                choiceButton.onClick.AddListener(function);
        }

}