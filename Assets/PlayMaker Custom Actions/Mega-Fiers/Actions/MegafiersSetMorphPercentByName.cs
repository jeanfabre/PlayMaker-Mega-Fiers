// (c) Copyright HutongGames, LLC 2010-2012. All rights reserved.

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Mega-Fiers")]
	[Tooltip("Set MegaMorph percentage for a number of channels using their name reference.")]
	public class MegafiersSetMorphPercentByName : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(MegaMorph))]
		[Tooltip("The GameObject to check.")]
		public FsmOwnerDefault gameObject;

		[CompoundArray("Channels", "Name", "Percent")]
		public FsmString[] name;
		public FsmFloat[] percent;

		[Tooltip("Repeat every frame")]
		public bool everyFrame;

		public override void Reset()
		{
			gameObject = null;
			name = new FsmString[1];
			percent = new FsmFloat[1];
			
			everyFrame = false;
		}
		
		private MegaMorph megaMorph;
		
		public override void OnEnter()
		{
			
		
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			if (go == null)
			{
				return;
			}
			megaMorph = go.GetComponent<MegaMorph>();
			
			if (megaMorph == null)
			{
				LogError("Missing MegaMorph!");
				return;
			}
			
			DoSetPercent();

			if (!everyFrame)
			{
				Finish();
			}
		}

		public override void OnUpdate()
		{
			DoSetPercent();
		}

		void DoSetPercent()
		{
			if ( megaMorph !=null)
			{
				for (int i = 0; i < name.Length; i++) 
				{
					MegaMorphChan _chan = megaMorph.GetChannel(name[i].Value);
					if (_chan != null)
					{
						int _index = _chan.targ;
						float _percent = percent[i].Value ;
						if (_percent !=megaMorph.GetPercent(_index) )
						megaMorph.SetPercent(_index,_percent );
					}
				}
				
				
			}
		}
	}
}