using System;
using System.Collections.Generic;
using System.Linq;

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
        
        private Stack<Token> partnerStack;
        private int level;
        private int lineNumber;
        public LinkedList<Token> tokenList { get; }
        private List<Token> stringList;

        public Tokenizer(string[] lines)
        {
            level = 0;
            lineNumber = 1;
            partnerStack = new Stack<Token>();
            stringList = new List<Token>();
            tokenList = new LinkedList<Token>();

            initMap();
            createTokensFromText(lines);
        }

        private void initMap()
        {
            tokensMap = new Dictionary<string, TokenType>();

            tokensMap["="] = TokenType.EQUALS;
            tokensMap["anders"] = TokenType.ELSE;
            tokensMap["terwijl"] = TokenType.WHILE;
            tokensMap["als"] = TokenType.IF;
            tokensMap[";"] = TokenType.SEMICOLUM;
            tokensMap[">"] = TokenType.GREATERTHAN;
            tokensMap["<"] = TokenType.SMALLERTHAN;
            tokensMap["+"] = TokenType.PLUS;
            tokensMap["-"] = TokenType.MINUS;
            tokensMap["{"] = TokenType.BRACKETOPEN;
            tokensMap["}"] = TokenType.BRACKETCLOSE;
            tokensMap["("] = TokenType.ELLIPSISOPEN;
            tokensMap[")"] = TokenType.ELLIPSISCLOSE;
            tokensMap["\""] = TokenType.STRINGOPENCLOSE;
            tokensMap["print"] = TokenType.PRINT;
            tokensMap["printlijn"] = TokenType.PRINTLINE;
            tokensMap["=="] = TokenType.DOUBLE_EQUALS;
        }
        private void createTokensFromText(string[] lines)
        {
            foreach (string line in lines)
            {
                string[] tokenIdentifiers = line.Split(' ', '\r', '\n', '\t');

                if (tokenIdentifiers.Length != 0 && !(tokenIdentifiers.Length == 1 && tokenIdentifiers[0] == ""))
                {
                    createTokens(tokenIdentifiers);
                    lineNumber++;

                }
            }

            var currentToken = tokenList.First;

            while (currentToken != null)
            {
                if (currentToken.Value.TokenType == TokenType.IDENTIFIER && currentToken.Value.Text == "")
                {
                    currentToken.Value.TokenType = TokenType.ANY;

                }
                currentToken = currentToken.Next;
            }
        }
        private void createTokens(string[] line)
        {
            foreach(string word in line)
            {
                Token token = new Token();
                token.Position = tokenList.Count + 1;
                token.Text = word;
                token.Level = level;
                token.LineNumber = lineNumber;

                if (!tokensMap.ContainsKey(word))
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
                    token.TokenType = tokensMap[word];

                    handlePartner(token);

                    checkCorrectnessPartners(token);


                }
                tokenList.AddLast(token);
            }
        }

        private void handlePartner(Token token)
        {
            if (token.TokenType == TokenType.BRACKETCLOSE || token.TokenType == TokenType.ELLIPSISCLOSE || token.TokenType == TokenType.ELSE)
            {
                token.Partner = getIndexOfToken(partnerStack.Peek());
            }
        }

        private int getIndexOfToken(Token token)
        {
            int index = 0;
            foreach (var t in tokenList)
            {
                if (t == token)
                    return index;
                index++;
            }
            return -1;
        }

        private void checkCorrectnessPartners(Token token)
        {
            switch (token.TokenType)
            {
                case TokenType.BRACKETOPEN:
                    partnerStack.Push(token);
                    level++;
                    break;
                case TokenType.BRACKETCLOSE:
                    if(partnerStack.Peek().TokenType == TokenType.BRACKETOPEN)
                    {
                        partnerStack.Pop();
                        level--;                        
                    }
                    else
                    {
                        generateException(partnerStack.Peek().TokenType, TokenType.BRACKETOPEN);
                    }
                    break;
                case TokenType.ELLIPSISOPEN:
                    partnerStack.Push(token);
                    level++;
                    break;
                case TokenType.ELLIPSISCLOSE:
                    if (partnerStack.Peek().TokenType == TokenType.ELLIPSISOPEN)
                    {
                        partnerStack.Pop();
                        level--;
                    } else
                    {
                        generateException(partnerStack.Peek().TokenType, TokenType.ELLIPSISOPEN);
                    }
                    break;
                case TokenType.IF:
                    partnerStack.Push(token);
                    break;
                case TokenType.ELSE:
                    if (partnerStack.Peek().TokenType == TokenType.IF)
                    {
                        partnerStack.Pop();
                    }else
                    {
                        generateException(partnerStack.Peek().TokenType, TokenType.ELSE);
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
