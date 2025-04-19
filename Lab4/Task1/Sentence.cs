//1 variant
namespace Lab4.Task1;
public class Sentence
{
    //Private fields
    private string _sentence;
    private string[] _arraySentence;
    private string _firstWord;
    private List<string> _arrayDates = new List<string>();
    /// <summary>
    /// Constructor
    /// </summary>
    public Sentence(string sentence)
    {
        _sentence = sentence;
    }
    /// <summary>
    /// Remove punctuation marks. Split sentences into words.
    /// </summary>
    void PrepareSentence()
    {
        _sentence = _sentence.Replace(",", "")
            .Replace("?", "")
            .Replace(":", "")
            .Replace("\"", "")
            .Replace("'", "")
            .Replace("!", "");
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
            if (char.IsDigit(word[0]))
            {
                if (word.Length == 8 && char.IsDigit(word[7]))
                {
                    _arrayDates.Add(word);
                }
                else if (word.Length == 10 && char.IsDigit(word[9]))
                {
                    _arrayDates.Add(word);
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
        return _firstWord + " " + string.Join(" ", _arrayDates);
    }
}