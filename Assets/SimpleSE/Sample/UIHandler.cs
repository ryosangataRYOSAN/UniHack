using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleSE
{
	public class UIHandler : MonoBehaviour
	{
		public void OnClickPressed(){
			AudioPlayer.PlaySE (SEType.Click);
		}

		public void OnAttack1Pressed(){
			AudioPlayer.PlaySE (SEType.Attack1);
		}

		public void OnAttack2Pressed(){
			AudioPlayer.PlaySE (SEType.Attack2);
		}

	}
}
