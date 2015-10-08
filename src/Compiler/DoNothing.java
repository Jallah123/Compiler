package Compiler;

public class DoNothing extends Node {

	@Override
	public void doAction() {
		nextNode.doAction();
	}
}
