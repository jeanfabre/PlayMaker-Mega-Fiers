// (c) Copyright HutongGames, LLC 2010-2012. All rights reserved.
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory(ActionCategory.String)]
	[Tooltip("Link GameObjects to FFD box points.")]
	public class LinkGameObjectToFfdPoints : FsmStateAction 
	{
		[RequiredField]
		[CheckForComponent(typeof(MegaFFD))]
		public FsmOwnerDefault gameObject;
		
		[RequiredField]
		[CompoundArray("Points", "i,j,k", "GameObject")]
		public FsmString[] pointIJK;
		public FsmGameObject[] pointTarget;
		
		public bool everyFrame;
		
		
		public override void Reset()
		{
			gameObject = null;
			pointIJK = new FsmString[0];
			pointTarget = new FsmGameObject[0];
			
			everyFrame = true;
		}
		
		private MegaFFD _ffd;
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			
			if (go == null)
			{
				Finish();
				return;
			}
			
			
 			_ffd = go.GetComponent<MegaFFD>();
			
			if (_ffd == null)
			{
				Finish();
				return;
			}
			
			ProcessPoints();
			
			if (!everyFrame)
			{
				Finish();
			}
		}
		public override void OnUpdate()
		{
			ProcessPoints();
		}
		
		private void ProcessPoints()
		{
			
			int i = 0;
			foreach(FsmGameObject fsmGo in pointTarget)
			{
				GameObject _go = fsmGo.Value;
				if (_go!=null)
				{
					string _ijk = pointIJK[i].Value;
					
					string[] ijk = _ijk.Split(","[0]);
					int _i = 0;
					int.TryParse(ijk[0],out _i);
					int _j = 0;
					int.TryParse(ijk[1],out _j);	
					int _k = 0;
					int.TryParse(ijk[2],out _k);
					
					_ffd.SetPoint(_i,_j,_k,_go.transform.position);
				}
				
				i++;
			}
			
		}

	}
}
