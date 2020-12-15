using Ink.Runtime;
using System;
using UnityEngine;
using UnityEngine.UI;

public class InkManager : MonoBehaviour
{
    [SerializeField]
    private TextAsset _inkJsonAsset;
    private Story _story;

    [SerializeField]
    private Text _textField;

    [SerializeField]
    private VerticalLayoutGroup _choiceButtonContainer;
    [SerializeField]
    private Button _choiceButtonPrefab;

    [SerializeField]
    private Color _normalTextColor;
    [SerializeField]
    private Color _thoughtTextColor;

    private CharacterManager _characterManager;

    private int _relationshipStrength;
    public int RelationshipStrength
    {
        get => _relationshipStrength;
        private set
        {
            Debug.Log($"Updating RelationshipStrength value. Old value: {_relationshipStrength}, new value: {value}");
            _relationshipStrength = value;
        }
    }

    private int _mentalHealth;
    public int MentalHealth
    {
        get => _mentalHealth;
        private set
        {
            Debug.Log($"Updating MentalHealth value. Old value: {_mentalHealth}, new value: {value}");
            _mentalHealth = value;
        }
    }

    private static string _loadedState;

    void Start()
    {
        _characterManager = FindObjectOfType<CharacterManager>();

        StartStory();

        InitializeVariables();
    }

    private void StartStory()
    {
        _story = new Story(_inkJsonAsset.text);

        if (!string.IsNullOrEmpty(_loadedState))
        {
            _story?.state?.LoadJson(_loadedState);
            _loadedState = null;
        }

        _story.BindExternalFunction("ShowCharacter",
            (string name, string position, string mood) => _characterManager.ShowCharacter(name, position, mood));

        _story.BindExternalFunction("HideCharacter",
            (string name) => _characterManager.HideCharacter(name));

        _story.BindExternalFunction("ChangeMood",
            (string name, string mood) => _characterManager.ChangeMood(name, mood));

        DisplayNextLine();
        RefreshChoiceView();
    }

    private void InitializeVariables()
    {
        RelationshipStrength = (int)_story.variablesState["relationship_strength"];
        MentalHealth = (int)_story.variablesState["mental_health"];

        _story.ObserveVariable("relationship_strength", (arg, value) =>
        {
            RelationshipStrength = (int)value;
        });

        _story.ObserveVariable("mental_health", (arg, value) =>
        {
            MentalHealth = (int)value;
        });
    }

    public void DisplayNextLine()
    {
        if (_story.canContinue)
        {
            string text = _story.Continue(); // gets next line

            text = text?.Trim(); // removes white space from text

            ApplyStyling();

            _textField.text = text; // displays new text
        }
        else if (_story.currentChoices.Count > 0)
        {
            DisplayChoices();
        }
    }

    private void ApplyStyling()
    {
        if (_story.currentTags.Contains("thought"))
        {
            _textField.color = new Color(_textField.color.r, _textField.color.g, _textField.color.b, 0.5f);
            _textField.fontStyle = FontStyle.Italic;
        }
        else
        {
            _textField.color = new Color(_textField.color.r, _textField.color.g, _textField.color.b, 1f);
            _textField.fontStyle = FontStyle.Normal;
        }
    }

    private void DisplayChoices()
    {
        // check if choices are already being displayed
        if (_choiceButtonContainer.GetComponentsInChildren<Button>().Length > 0) return;

        for (int i = 0; i < _story.currentChoices.Count; i++)
        {
            var choice = _story.currentChoices[i];
            var button = CreateChoiceButton(choice.text);

            button.onClick.AddListener(() => OnClickChoiceButton(choice));
        }
    }

    Button CreateChoiceButton(string text)
    {
        // creates the button from a prefab
        var choiceButton = Instantiate(_choiceButtonPrefab);

        choiceButton.transform.SetParent(_choiceButtonContainer.transform, false);

        // sets text on the button
        var buttonText = choiceButton.GetComponentInChildren<Text>();
        buttonText.text = text;

        return choiceButton;
    }

    void OnClickChoiceButton(Choice choice)
    {
        _story.ChooseChoiceIndex(choice.index);
        _story.Continue();
        RefreshChoiceView();
        DisplayNextLine();
    }

    // Destroys all the old content and choices.
    void RefreshChoiceView()
    {
        if (_choiceButtonContainer != null)
        {
            foreach (var button in _choiceButtonContainer.GetComponentsInChildren<Button>())
            {
                Destroy(button.gameObject);
            }
        }
    }

    public string GetStoryState()
    {
        return _story.state.ToJson();
    }

    public static void LoadState(string state)
    {
        _loadedState = state;
    }
}
