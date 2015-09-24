import java.util.ArrayList;
import java.util.Stack;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Tokenizer {

	private ArrayList<TokenInfo> tokenInfos;
	private ArrayList<Token> tokens;
	private Stack<Token> stack;

	public Tokenizer() {
		stack = new Stack<Token>();
		tokenInfos = new ArrayList<TokenInfo>();
		tokens = new ArrayList<Token>();
		initTokenInfo();
	}

	private void initTokenInfo() {
		add("terwijl", Token.TokenType.WHILE);
		add("afdruk", Token.TokenType.PRINT);
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
		tokenInfos
				.add(new TokenInfo(Pattern.compile("^(" + regex + ")"), token));
	}

	public void tokenize(String str) throws Exception {
		String s = str.trim();
		tokens.clear();
		Token tempToken;
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
					s = m.replaceFirst("");
					tempToken = new Token(tokens.size(), lineNumber,
							linePosition, info.token, tok, level);
					tokens.add(tempToken);
					if (tok.equals("}") || tok.equals(")")) {
						linkPartner(tempToken);
						level--;
					}
					if (tok.equals("{") || tok.equals("(")) {
						stack.add(tempToken);
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
					int length = s.length();

					s = s.trim();
					int diff = length - s.length();
					linePosition += diff;
					break;
				}
			}
			if (!match)
				throw new Exception("Unexpected character in input: " + s);
		}
	}

	private void linkPartner(Token tok) throws Exception {
		if (stack.isEmpty()) {
			throw new Exception("Je mist een bracket of ellips.");
		}
		Token tempToken = stack.pop();
		if ((tok.getTokenType() == Token.TokenType.BRACKETSCLOSE && tempToken
				.getTokenType() == Token.TokenType.BRACKETSOPEN)) {
		} else {
			throw new Exception("Verkeerde {} kut.");
		}
		if ((tok.getTokenType() == Token.TokenType.ELLIPSISCLOSE && tempToken
				.getTokenType() == Token.TokenType.ELLIPSISOPEN)) {
		} else {
			throw new Exception("Verkeerde () kut.");
		}

		tok.setPartner(tempToken.getPositionInList());
		tempToken.setPartner(tok.getPositionInList());

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