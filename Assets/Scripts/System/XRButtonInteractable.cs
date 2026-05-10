using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class XRButtonInteractable : XRSimpleInteractable
{
    [SerializeField] Image btnImage;
    [SerializeField] private Color normColor, hilightColor, pressColor, selectColor;
    private bool isPressed;
    void Start()
    {
        ResetColor();
    }
    protected override void OnHoverEntered(HoverEnterEventArgs args)
    {
        base.OnHoverEntered(args);
        btnImage.color = hilightColor;
        isPressed = false;
    }
    protected override void OnHoverExited(HoverExitEventArgs args)
    {
        base.OnHoverExited(args);
        if (!isPressed)
        {
            ResetColor();
        }
    }
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        isPressed = true;
        btnImage.color = pressColor;
        Debug.Log("XR Button OnSelectEntered");
    }
    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        btnImage.color = selectColor;
    }
    public void ResetColor()
    {
        btnImage.color = normColor;
    }
}
