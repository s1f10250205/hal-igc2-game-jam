using UnityEngine;
using System.Text.RegularExpressions;
using TMPro;

public class ValueSetter : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void SetValue(params string[] values) {
        int count = 0;
        string placeholder = textMeshPro.text;
        string replaced = Regex.Replace(placeholder, "%N", m =>
        {
            count++;
            return values[count];
        });
    }
}
