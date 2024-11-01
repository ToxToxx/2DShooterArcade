using UnityEngine;
using UnityEngine.EventSystems;

public class PauseResumButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject _activeObject;
    [SerializeField] private GameObject _hiddenObject;

    private void Start()
    {
        if (_hiddenObject != null)
        {
            _hiddenObject.SetActive(false);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ToggleObjects();
    }

    private void ToggleObjects()
    {
        if (_activeObject != null && _hiddenObject != null)
        {
            bool isActive = _activeObject.activeSelf;
            _activeObject.SetActive(!isActive);
            _hiddenObject.SetActive(isActive);
        }
    }
}
