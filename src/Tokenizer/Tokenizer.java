package Tokenizer;
import java.util.ArrayList;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

import Tokenizer.Token.TokenType;

public class Tokenizer {

	private ArrayList<TokenInfo> tokenInfos;
	private ArrayList<Token> tokens;

	public Tokenizer() {
		tokenInfos = new ArrayList<TokenInfo>();
		tokens = new ArrayList<Token>();
		initTokenInfo();
	}

	private void initTokenInfo() {
		add("terwijl", Token.TokenType.WHILE);
		add("afdruk", Token.TokenType.PRINT);
		add("als", Token.TokenType.IF);
		add("anders", Token.TokenType.ELSE);
		add("=", Token.TokenType.EQUALS);
		add(";", Token.TokenType.SEMICOLON);
		add(">=", Token.TokenType.GREATEREQUALS);
		add("\\{", Token.TokenType.BRACKETSOPEN);
		add("\\}", Token.TokenType.BRACKETSCLOSE);
		add("\\(", Token.TokenType.ELLIPSISOPEN);
		add("\\)", Token.TokenType.ELLIPSISCLOSE);
		add("[-]", Token.TokenType.MINUS);
		add("[0-9]+", Token.TokenType.NUMBER);
		add("[a-zA-Z][a-zA-Z0-9_]*", Token.TokenType.IDENTIFIER);
	}

	public void add(String regex, Token.TokenType token) {
		tokenInfos.add(new TokenInfo(Pattern.compile("^(" + regex + ")"), token));
	}

	public void tokenize(String str) throws Exception {
		String s = str.trim();
		tokens.clear();
		int lineNumber = 1;
		int linePosition = 1;
		int level = 0;
		while (!s.equals("")) {
			boolean match = false;
			for (TokenInfo info : tokenInfos) {
				Matcher m = info.regex.matcher(s);
				if (m.find()) {
					match = true;
					String tok = m.group().trim();
					if (tok.equals("}") || tok.equals(")")) {
						level--;
					}
					s = m.replaceFirst("");
					tokens.add(new Token(tokens.size(), lineNumber, linePosition, info.token, tok, level));
					linkPartner(tok, level);
					if (tok.equals("{") || tok.equals("(")) {
						level++;
					}
					linePosition += tok.length();
					if (s != "") {
						try {
							if (s.charAt(1) == '\n') {
								lineNumber++;
								linePosition = 1;
							}
						} catch (StringIndexOutOfBoundsException e) {

						}
					}
					s = s.trim();
					break;
				}
			}
			if (!match)
				throw new Exception("Unexpected character in input: " + s);
		}
	}
	private void linkPartner(String tok, int level){
		if (tok.equals("}")) {
			for (int i = tokens.size() - 1; i >= 0; i--) {
				if (tokens.get(i).getLevel() == level) {
					if (tokens.get(i).getValue().equals("{")) {
						tokens.get(tokens.size() - 1).setPartner(i);
						tokens.get(i).setPartner(tokens.size() - 1);
					}
				}
			}
		}
		if (tok.equals(")")) {
			for (int i = tokens.size() - 1; i >= 0; i--) {
				if (tokens.get(i).getLevel() == level) {
					if (tokens.get(i).getValue().equals("(")) {
						tokens.get(tokens.size() - 1).setPartner(i);
						tokens.get(i).setPartner(tokens.size() - 1);
					}
				}
			}
		}
	}
	private class TokenInfo {
		public final Pattern regex;
		public final Token.TokenType token;

		public TokenInfo(Pattern regex, Token.TokenType token) {
			super();
			this.regex = regex;
			this.token = token;
		}
	}

	public ArrayList<Token> getTokens() {
		return tokens;
	}
}