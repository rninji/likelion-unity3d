using UnityEngine;

public class StudyString : MonoBehaviour
{
    string str1 = "hello";
    string[] str2 = new string[3] { "Hello", "Unity", "World" };
    string str3 = "***Hello World ";
    
    void Start()
    {
        Debug.Log(str1[0]); // H
        Debug.Log(str1[2]); // l

        Debug.Log(str2[0]); // Hello
        Debug.Log(str2[2]); // World

        Debug.Log(str1.Length); // 문자열 길이

        
        Debug.Log(str3.Trim()); // 앞뒤 공백 제거 "***Hello World"
        Debug.Log(str3.Trim('*')); // 앞뒤 문자 l 제거 "Hello World "

        string str4 = str1.Replace("he", "Unity"); // he를 Unity로 대체
        Debug.Log(str4); // Unityllo
        
        string text = "Apple,Banana,Orange,Melon,Water Melon,Mango";
        string[] fruits = text.Split(','); // 특정 문자로 쪼개기

        foreach (var fruit in fruits)
            Debug.Log(fruit);
    }
}
