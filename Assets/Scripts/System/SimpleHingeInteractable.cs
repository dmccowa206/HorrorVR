using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public abstract class SimpleHingeInteractable : XRSimpleInteractable
{
    public UnityEvent<SimpleHingeInteractable> OnHingeSelected;
    [SerializeField] Vector3 positionLimits;
    private Transform grabHand;
    private Collider hingeCollider;
    private Vector3 hingePositions;
    [SerializeField] bool isLocked;
    [SerializeField] AudioClip hingeMoveClip, closedClip;
    public AudioClip GetHingeMoveClip => hingeMoveClip;
    public AudioClip GetClosedClip => closedClip;
    private const string Default_Layer = "Default";
    private const string Grab_Layer = "Grab";
    protected abstract void ResetHinge();
    protected virtual void Start()
    {
        hingeCollider = GetComponent<Collider>();
    }
    protected virtual void Update()
    {
        if(grabHand != null)
        {
            TrackHand();
        }
    }
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        if (!isLocked)
        {
            Debug.Log("OnSelectEntered: SimpleHinge");
            base.OnSelectEntered(args);
            grabHand = args.interactorObject.transform;
            OnHingeSelected?.Invoke(this);
        }
    }
    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        grabHand = null;
        ChangeLayerMask(Grab_Layer);
        ResetHinge();
    }
    private void TrackHand()
    {
        transform.LookAt(grabHand, transform.forward);
        hingePositions = hingeCollider.bounds.center;
        Debug.Log(grabHand.position);
        if (grabHand.position.x >= hingePositions.x + positionLimits.x ||
                grabHand.position.x <= hingePositions.x - positionLimits.x)
        {
            ReleaseHinge();
            Debug.Log("Release Hinge: X");
        }
        else if (grabHand.position.y >= hingePositions.y + positionLimits.y ||
                grabHand.position.y <= hingePositions.y - positionLimits.y)
        {
            ReleaseHinge();
            Debug.Log("Release Hinge: Y");
        }
        else if (grabHand.position.z >= hingePositions.z + positionLimits.z ||
                grabHand.position.z <= hingePositions.z - positionLimits.z)
        {
            ReleaseHinge();
            Debug.Log("Release Hinge: Z");
        }
    }
    public void ReleaseHinge()
    {
        ChangeLayerMask(Default_Layer);
    }
    private void ChangeLayerMask(string mask)
    {
        interactionLayers = InteractionLayerMask.GetMask(mask);
    }
    public void UnlockHinge()
    {
        isLocked = false;
    }
    public void LockHinge()
    {
        isLocked = true;
    }
}
