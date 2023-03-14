// See https://aka.ms/new-console-template for more information
using ConsoleApp1;
using System;
using System.Reflection;
static string TrimString(string str)
{
    if (string.IsNullOrEmpty(str))
    {
        return str;
    }
    int start = 0;
    int end = str.Length - 1;
    while (start < str.Length && char.IsWhiteSpace(str[start]))
    {
        start++;
    }
    while (end >= 0 && char.IsWhiteSpace(str[end]))
    {
        end--;
    }
    if (end < start)
    {
        return string.Empty;
    }
    return str.Substring(start, end - start + 1);
}

static string GetSubstringBetweenParentheses(string str)
{
    int start = str.IndexOf('(');
    int end = str.IndexOf(')');
    if (start >= 0 && end > start)
    {
        return str.Substring(start + 1, end - start - 1);
    }
    return string.Empty;
}

static function GetFuncitonInfo(string input) {

    function func = new function();
    StreamReader reader = new StreamReader(input);
    string content = reader.ReadToEnd();
    string str = content;
    int leftBracketIndex = str.IndexOf("(");
    int spaceBeforeLeftBracketIndex = str.LastIndexOf(" ", leftBracketIndex);
    int spaceBeforesBLBI = str.LastIndexOf(" ", spaceBeforeLeftBracketIndex - 1);

    string name = str.Substring(spaceBeforeLeftBracketIndex + 1, leftBracketIndex - spaceBeforeLeftBracketIndex - 1);
    string returnValue = str.Substring(spaceBeforesBLBI + 1, spaceBeforeLeftBracketIndex - spaceBeforesBLBI - 1);
    func.name = name;
    func.returnValue = returnValue;
    string paramList = GetSubstringBetweenParentheses(str);
    string[] arr = paramList.Split(',');
    int length = 0;
    foreach (string s in arr)
    {
        string temp = TrimString(s);
        func.param[length++] = temp.Substring(0, temp.IndexOf(" "));
    }
    func.length = length;
    return func;
}

string input = "D:\\temp\\ConsoleApp1\\input.txt";
string output = "D:\\temp\\ConsoleApp1\\output.txt";
string test = "D:\\temp\\ConsoleApp1\\test.txt";

function input_func = GetFuncitonInfo(input);
function output_func = GetFuncitonInfo(output);

Console.WriteLine(output_func.name);

Dictionary<function, function> map = new Dictionary<function, function>(new functionComparer());
map.Add(input_func, output_func);
function test_func = GetFuncitonInfo(test);

if (test_func == input_func) {
    //测试
    Console.WriteLine("456789");
}

if (map.ContainsKey(test_func)) {
    Console.WriteLine("123");
}
