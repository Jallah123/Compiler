
public class Main {

	public static void main(String[] args) {
		Tokenizer tokenizer = new Tokenizer();
		new CodeParser("code.txt", tokenizer);
	}
}
