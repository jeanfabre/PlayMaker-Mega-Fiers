// (c) Copyright HutongGames, LLC 2010-2012. All rights reserved.
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Mega-Fiers")]
	[Tooltip("Link GameObjects to FFD box points.")]
	public class MegaFiersDoCopyObjects : FsmStateAction 
	{
		[RequiredField]
		[CheckForComponent(typeof(MegaModifyObject))]
		public FsmOwnerDefault from;

		[RequiredField]
		[UIHint(UIHint.Variable)]
		public FsmGameObject to;

		public override void Reset()
		{
			from = null;
			to = null;
		}

		public override void OnEnter()
		{
			GameObject go = Fsm.GetOwnerDefaultTarget(from);

			to.Value =	MegaCopyObject.DoCopyObjects(go);

			Finish();

		}
	}
}

