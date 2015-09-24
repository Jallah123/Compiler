import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

public class CodeParser {

	private String input;
	private Tokenizer tokenizer;
	
	public CodeParser(String path, Tokenizer tokenizer) {
		this.tokenizer = tokenizer;
		try {
			byte[] encoded = Files.readAllBytes(Paths.get(path));
			input = new String(encoded, StandardCharsets.UTF_8);
			tokenizeInput();
			for (Token t : tokenizer.getTokens()) {
				System.out.println(
						t.getPositionInList() + " partner: " + t.getPartner() + " level: " + t.getLevel() + " value: " + t.getValue() + " lineNumber: " + t.getLineNumber() + " linePosition: " + t.getLinePosition());
			}
		} catch (IOException e) {
			e.printStackTrace();
		}
	}
	private void tokenizeInput(){
		try {
			tokenizer.tokenize(input);
		} catch (Exception e) {
			e.printStackTrace();
		}
	}
}
