using UnityEngine;

public class NextButtonScript : MonoBehaviour
{
    InkManager _inkManager;

    void Start()
    {
        _inkManager = FindObjectOfType<InkManager>();
        if (_inkManager == null)
        {
            Debug.LogError("Ink Manager was not found!");
        }
    }

    public void OnClick()
    {
        _inkManager?.DisplayNextLine();
    }
}
