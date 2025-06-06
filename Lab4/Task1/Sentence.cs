﻿//1 variant
namespace Lab4.Task1;
using System.Text.RegularExpressions;
public class Sentence
{
    //Private fields
    private string _sentence;
    private string[] _arraySentence;
    private string _firstWord;
    private List<string> _arrayDates = new List<string>();
    //Private const
    private const int FirstCharIndex = 0; //First char in word
    private const int LengthShortDate = 8; //Length of DD/MM/YY and DD.MM.YY
    private const int LengthLongDate = 10; //Length of DD.MM.YYYY
    private const int LastShortCharIndex = 7; //Length of last element in short date
    private const int LastLongCharIndex = 9; //Length of last element in long date
    private const string SpaceString = " ";
    /// <summary>
    /// Constructor
    /// </summary>
    public Sentence(string sentence)
    {
        _sentence = sentence;
    }
    /// <summary>
    /// Remove punctuation marks via regular expression. Split sentences into words.
    /// </summary>
    void PrepareSentence()
    {
        var punctuation = new[] { ',', '?', ':', '"', '\'', '!' };
        foreach (var element in punctuation)
        {
            _sentence = _sentence.Replace(element.ToString(), "");
        }
        _arraySentence = _sentence.Split(' ');
    }
    /// <summary>
    /// Take first word from array of words
    /// </summary>
    void TakeFirstWord()
    {
        _firstWord = _arraySentence[0];
    }
    /// <summary>
    /// Take dates from array of words
    /// </summary>
    void TakeDates()
    {
        foreach (string word in _arraySentence)
        {
            if (string.IsNullOrEmpty(word))
            {
                continue;
            }
            if (char.IsDigit(word[FirstCharIndex]))
            {
                if (word.Length == LengthShortDate)
                {
                    if (char.IsDigit(word[LastShortCharIndex]))
                    {
                        _arrayDates.Add(word);
                    }
                }
                else if (word.Length == LengthLongDate)
                {
                    if (char.IsDigit(word[LastLongCharIndex]))
                    {
                        _arrayDates.Add(word);
                    }
                }
            }
        }
    }
    /// <summary>
    /// Prepare result sentence
    /// </summary>
    public string GetResult()
    {
        PrepareSentence();
        TakeFirstWord();
        TakeDates();
        string dates = string.Join(SpaceString, _arrayDates);
        string result = _firstWord + SpaceString + dates;
        return result;
    }
}