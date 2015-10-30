using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler
{
    public enum TokenType
    {
        EQUALS,
        SEMICOLUM,
        WHILE,
        ELLIPSISOPEN,
        ELLIPSISCLOSE,
        BRACKETOPEN,
        BRACKETCLOSE,
        MINUS,
        PLUS,
        IF,
        NUMBER,
        IDENTIFIER,
        ELSE,
        GREATERTHAN,
        SMALLERTHAN,
        PRINT,
        PRINTLINE,
        ANY,
        STRINGOPENCLOSE,
        DOUBLE_EQUALS
    }

    public class Tokenizer
    {
        private Dictionary<string, TokenType> tokensMap;
        
        private Stack<TokenType> partnerStack;
        private int level;
        private int lineNumber;
        public LinkedList<Token> tokenList { get; }
        private List<Token> stringList;

        public Tokenizer(string[] lines)
        {
            this.level = 0;
            this.lineNumber = 1;
            this.partnerStack = new Stack<TokenType>();
            this.stringList = new List<Token>();
            this.tokenList = new LinkedList<Token>();

            this.initMap();

            foreach (string line in lines)
            {
                string[] tokenIdentifiers = line.Split(' ', '\r', '\n', '\t');

                if(tokenIdentifiers.Length != 0 && !(tokenIdentifiers.Length == 1 && tokenIdentifiers[0] == ""))
                {
                    this.createTokens(tokenIdentifiers);
                    this.lineNumber++;

                }
            }

            var currentToken = tokenList.First;

            while(currentToken != null)
            {
                if (currentToken.Value.TokenType == TokenType.IDENTIFIER && currentToken.Value.Text == "")
                {
                    currentToken.Value.TokenType = TokenType.ANY;
                    
                }
                currentToken = currentToken.Next;
            }
        }

        private void initMap()
        {
            this.tokensMap = new Dictionary<string, TokenType>();

            this.tokensMap["="] = TokenType.EQUALS;
            this.tokensMap["anders"] = TokenType.ELSE;
            this.tokensMap["terwijl"] = TokenType.WHILE;
            this.tokensMap["als"] = TokenType.IF;
            this.tokensMap[";"] = TokenType.SEMICOLUM;
            this.tokensMap[">"] = TokenType.GREATERTHAN;
            this.tokensMap["<"] = TokenType.SMALLERTHAN;
            this.tokensMap["+"] = TokenType.PLUS;
            this.tokensMap["-"] = TokenType.MINUS;
            this.tokensMap["{"] = TokenType.BRACKETOPEN;
            this.tokensMap["}"] = TokenType.BRACKETCLOSE;
            this.tokensMap["("] = TokenType.ELLIPSISOPEN;
            this.tokensMap[")"] = TokenType.ELLIPSISCLOSE;
            this.tokensMap["\""] = TokenType.STRINGOPENCLOSE;
            this.tokensMap["print"] = TokenType.PRINT;
            this.tokensMap["printlijn"] = TokenType.PRINTLINE;
            this.tokensMap["=="] = TokenType.DOUBLE_EQUALS;
        }

        private void createTokens(string[] line)
        {
            foreach(string word in line)
            {
                Token token = new Token();
                token.Position = tokenList.Count + 1;
                token.Text = word;
                token.Level = this.level;
                token.LineNumber = this.lineNumber;

                if (!this.tokensMap.ContainsKey(word))
                {
                    int wordNumeric;
                    bool result = int.TryParse(word, out wordNumeric);
                    bool isString = word.Contains("\"");
                    if (result)
                    {
                        token.TokenType = TokenType.NUMBER;
                    }
                    else
                    {
                        token.TokenType = TokenType.IDENTIFIER;
                    }
                    if (isString)
                    {
                        token.TokenType = TokenType.STRINGOPENCLOSE;
                        token.Text = token.Text.Substring(1, token.Text.Length - 2);
                    }
                }
                else
                {
                    this.checkCorrectnessPartners(this.tokensMap[word]);
                    
                    token.TokenType = this.tokensMap[word];
                    
                    // this.handlePartner(token);
                }
                this.tokenList.AddLast(token);
            }
        }

        private void handlePartner(Token token)
        {
            switch (token.TokenType) {
                case TokenType.BRACKETCLOSE:

                    break;

            }
        }

        private void checkCorrectnessPartners(TokenType tokenType)
        {
            switch (tokenType)
            {
                case TokenType.BRACKETOPEN:
                    this.partnerStack.Push(tokenType);
                    this.level++;
                    break;
                case TokenType.BRACKETCLOSE:
                    if(this.partnerStack.Peek() == TokenType.BRACKETOPEN)
                    {
                        this.partnerStack.Pop();
                        this.level--;                        
                    }
                    else
                    {
                        generateException(this.partnerStack.Peek(), TokenType.BRACKETOPEN);
                    }
                    break;
                case TokenType.ELLIPSISOPEN:
                    this.partnerStack.Push(tokenType);
                    this.level++;
                    break;
                case TokenType.ELLIPSISCLOSE:
                    if (this.partnerStack.Peek() == TokenType.ELLIPSISOPEN)
                    {
                        this.partnerStack.Pop();
                        this.level--;
                    } else
                    {
                        generateException(this.partnerStack.Peek(), TokenType.ELLIPSISOPEN);
                    }
                    break;
                case TokenType.IF:
                    this.partnerStack.Push(tokenType);
                    break;
                case TokenType.ELSE:
                    if (this.partnerStack.Peek() == TokenType.IF)
                    {
                        this.partnerStack.Pop();
                    }else
                    {
                        generateException(this.partnerStack.Peek(), TokenType.ELSE);
                    }
                    break;
            }
        }

        private void generateException(TokenType found, TokenType expected)
        {
            throw new Exception("Wrong bracket found in stack, \n found " + getKeyByValueFromMap(found) + " but expected " + getKeyByValueFromMap(expected) + " on line " + lineNumber + ".");
        }

        private string getKeyByValueFromMap(TokenType tokenType)
        {
            return tokensMap.FirstOrDefault(x => x.Value.Equals(tokenType)).Key;
        }
    }
}
