using UnityEngine;
using System;
using System.Linq;
using System.Collections;

public class StateTransition 
{
	public class Transition
	{
		public int transitionNum;
		public Action changePresentAction;

		public Transition(int transitionNum, Action changePresentAction) 
		{
			this.transitionNum = transitionNum;
			this.changePresentAction = changePresentAction;
		}
	}

	Transition[] transitions;

	public StateTransition(params Transition[] transitions) 
	{
		this.transitions = transitions;
	}

	public void ExecuteTransition(int transitionNum)
	{
		Transition transition = transitions.Where(t => t.transitionNum == transitionNum).FirstOrDefault();
		transition.changePresentAction.Invoke();
	}
}