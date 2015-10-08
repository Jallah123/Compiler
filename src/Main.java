import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.LinkedList;

import Compiler.ConditionalJump;
import Compiler.Node;
import Tokenizer.CodeParser;
import Tokenizer.Token;
import Tokenizer.Token.TokenType;
import Tokenizer.Tokenizer;

public class Main {

	public static void main(String[] args) {
		Path currentRelativePath = Paths.get("");
		String s = currentRelativePath.toAbsolutePath().toString();
		Tokenizer tokenizer = new Tokenizer();
		new CodeParser(s + "\\code.txt", tokenizer);
		tokenizer.getTokens();
		LinkedList<Node> nodes = new LinkedList<Node>();
		for (Token t : tokenizer.getTokens()) {
			if(t.getToken() == TokenType.IF) {
				nodes.add(new ConditionalJump());
			}
		}
	}
}
