package Compiler;

public class ConditionalJump extends Node {

	private boolean condition;
	private Node target;
	
	@Override
	public void doAction() {
		if(condition){
			nextNode.doAction();
		} else {
			target.doAction();
		}
	}
}
