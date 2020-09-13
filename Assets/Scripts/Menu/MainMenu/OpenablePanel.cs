using UnityEngine;

public class OpenablePanel : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void Open()
    {
        _animator.SetTrigger("Open");
    }

    public void Close()
    {
        _animator.SetTrigger("Close");
    }

    public void OnCloseButtonClick(OpenablePanel nextPanel)
    {
        Close();
        nextPanel.Open();
    }
}