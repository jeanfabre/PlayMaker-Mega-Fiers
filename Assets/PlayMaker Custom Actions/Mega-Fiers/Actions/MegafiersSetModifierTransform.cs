// (c) Copyright HutongGames, LLC 2010-2012. All rights reserved.

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Mega-Fiers")]
	[Tooltip("Set the transform common parameters of a Mega-Fiers modifier.")]
	public class MegafiersSetModifierTransform : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(MegaModifier))]
		[Tooltip("The GameObject to check.")]
		public FsmOwnerDefault gameObject;


		[Tooltip("The offset")]
		public FsmVector3 offset;
		
		[Tooltip("The gizmo Position")]
		public FsmVector3 gizmoPos;
		
		[Tooltip("The gizmo Rotation")]
		public FsmVector3 gizmoRot;
		
		[Tooltip("The gizmo Scale")]
		public FsmVector3 gizmoScale;
		
		[Tooltip("Repeat every frame")]
		public bool everyFrame;

		public override void Reset()
		{
			gameObject = null;
			offset = null;
			gizmoPos = null;
			gizmoRot = null;
			gizmoScale = new FsmVector3();
			gizmoScale.Value = new Vector3(1,1,1);
			
			everyFrame = false;
		}
		
		private MegaModifier megaModifier;
		
		public override void OnEnter()
		{
			
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			if (go == null)
			{
				return;
			}
			megaModifier = go.GetComponent<MegaModifier>();
			
			if (megaModifier == null)
			{
				LogError("Missing MegaModifier!");
				return;
			}
				
			
			DoSetOffset();

			if (!everyFrame)
			{
				Finish();
			}
		}

		public override void OnUpdate()
		{
			DoSetOffset();
		}

		void DoSetOffset()
		{
			if ( megaModifier !=null)
			{
				if (offset.Value != megaModifier.Offset)
				{
					megaModifier.Offset = offset.Value;
				}
				
				if (gizmoPos.Value != megaModifier.gizmoPos)
				{
					megaModifier.gizmoPos = gizmoPos.Value;
				}
				if (gizmoRot.Value != megaModifier.gizmoRot)
				{
					megaModifier.gizmoRot = gizmoRot.Value;
				}
				if (gizmoScale.Value != megaModifier.gizmoScale)
				{
					megaModifier.gizmoScale = gizmoScale.Value;
				}
			}
		}
	}
}