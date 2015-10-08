package Compiler;

public class JumpNode extends Node {
	
	private Node target;
	
	@Override
	public void doAction() {
		target.doAction();
	}	
}
