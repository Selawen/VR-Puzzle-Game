/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Valve.VR.InteractionSystem
{
    [RequireComponent(typeof(Interactable))]
    public class Moveable : MonoBehaviour
    {
        private Vector3 oldPosition;
        private Quaternion oldRotation;

        protected bool attached = false;
        protected float attachTime;
        protected Vector3 attachPosition;
        protected Quaternion attachRotation;
        protected Transform attachEaseInTransform;

        public UnityEvent onPickUp;
        public UnityEvent onDetachFromHand;
        public HandEvent onHeldUpdate;

        private Hand.AttachmentFlags attachmentFlags = Hand.defaultAttachmentFlags & (~Hand.AttachmentFlags.SnapOnAttach) & (~Hand.AttachmentFlags.DetachOthers) & (~Hand.AttachmentFlags.VelocityMovement);

        [Tooltip("When detaching the object, should it return to its original parent?")]
        public bool restoreOriginalParent = false;

        private Interactable interactable;

        void Awake()
        {
            interactable = this.GetComponent<Interactable>();
        }

        protected virtual void OnAttachedToHand(Hand hand)
        {
            //Debug.Log("<b>[SteamVR Interaction]</b> Pickup: " + hand.GetGrabStarting().ToString());


            attached = true;

            onPickUp.Invoke();

            hand.HoverLock(null);

            attachTime = Time.time;
            attachPosition = transform.position;
            attachRotation = transform.rotation;
        }

        protected virtual void OnDetachedFromHand(Hand hand)
        {
            attached = false;

            onDetachFromHand.Invoke();

            hand.HoverUnlock(null);
        }

        protected virtual void HandAttachedUpdate(Hand hand)
        {


            if (hand.IsGrabEnding(this.gameObject))
            {
                hand.DetachObject(gameObject, restoreOriginalParent);

                // Uncomment to detach ourselves late in the frame.
                // This is so that any vehicles the player is attached to
                // have a chance to finish updating themselves.
                // If we detach now, our position could be behind what it
                // will be at the end of the frame, and the object may appear
                // to teleport behind the hand when the player releases it.
                //StartCoroutine( LateDetach( hand ) );
            }

            if (onHeldUpdate != null)
                onHeldUpdate.Invoke(hand);
        }


        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}*/
