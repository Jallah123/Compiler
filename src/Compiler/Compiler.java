package Compiler;

import java.util.LinkedList;

import Tokenizer.Token;

public abstract class Compiler {

    public abstract void compile( LinkedList<Token> tokenList, Token begin, Token end );
    
    public Token getLastNode( LinkedList<Token> tokenList, Token current )
	{
    	return current;
	}
}
