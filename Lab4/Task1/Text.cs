//1 variant
namespace Lab4.Task1;
public class Text
{
    //Private fields
    private string _text;
    private string[] _arrayText;
    private List<string> _listText = new List<string>();
    private string[] _arrayResult;
    /// <summary>
    /// Constructor
    /// </summary>
    public Text(string text)
    {
        _text = text;
    }
    /// <summary>
    /// Remove last symbol from [string] text
    /// </summary>
    void PrepareText()
    {
        int LastSymbolIndex = _text.Length - 1;
        if (_text[LastSymbolIndex] == '.')
        {
            _text = _text.Remove(LastSymbolIndex);
        }
    }
    /// <summary>
    /// Splitting text into array. Transition to Sentence.cs. Forming list. Parse into array.
    /// </summary>
    void CalculateResult()
    {
        _arrayText = _text.Split(". ");
        foreach (string oldSentence in _arrayText)
        {
            Sentence calcSentence = new Sentence(oldSentence);
            string newSentence = calcSentence.GetResult();
            _listText.Add(newSentence);
        }
        _arrayResult = _listText.ToArray();
    }
    /// <summary>
    /// Print result array. String by string.
    /// </summary>
    public string[] GetResult()
    {
        PrepareText();
        CalculateResult();
        return _arrayResult;
    }
}