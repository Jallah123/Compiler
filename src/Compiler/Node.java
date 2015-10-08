package Compiler;

import Tokenizer.Token.TokenType;

public abstract class Node {

	protected Node nextNode;
	protected TokenType IDENTIFIER;
	public abstract void doAction();
}
