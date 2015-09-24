public class Token {
	private int positionInList;
	private int lineNumber;
	private int linePosition;
	private TokenType tokenType;
	private String value;
	private int level;
	private int partner;
	
	public Token(int positionInList, int lineNumber, int linePosition, TokenType tokenType, String value, int level){
		this.positionInList = positionInList;
		this.lineNumber = lineNumber;
		this.linePosition = linePosition;
		this.tokenType = tokenType;
		this.value = value;
		this.level = level;
	}
	
	public enum TokenType {
		IDENTIFIER,
		EQUALS,
		NUMBER,
		SEMICOLON,
		WHILE,
		ELLIPSISOPEN,
		GREATEREQUALS,
		ELLIPSISCLOSE,
		BRACKETSOPEN,
		MINUS,
		BRACKETSCLOSE,
		PRINT
	}

	public int getPositionInList() {
		return positionInList;
	}

	public void setPositionInList(int positionInList) {
		this.positionInList = positionInList;
	}

	public int getLineNumber() {
		return lineNumber;
	}

	public void setLineNumber(int lineNumber) {
		this.lineNumber = lineNumber;
	}

	public int getLinePosition() {
		return linePosition;
	}

	public void setLinePosition(int linePosition) {
		this.linePosition = linePosition;
	}

	public TokenType getTokenType() {
		return tokenType;
	}

	public void setTokenType(TokenType tokenType) {
		this.tokenType = tokenType;
	}

	public String getValue() {
		return value;
	}

	public void setValue(String value) {
		this.value = value;
	}

	public int getLevel() {
		return level;
	}

	public void setLevel(int level) {
		this.level = level;
	}

	public int getPartner() {
		return partner;
	}

	public void setPartner(int partner) {
		this.partner = partner;
	}
	
	
}