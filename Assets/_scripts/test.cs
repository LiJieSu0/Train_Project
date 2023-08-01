using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public int numLine = 3;
    private Dictionary<int, List<int>> _lineData;
    private readonly int[] _patterns =
    {
        0b1000100010001000,
        0b0100010001000100,
        0b0010001000100010,
        0b0001000100001001,
        0b1111000000000000,
        0b0000111100000000,
        0b0000000011110000,
        0b0000000000001111,
        0b1000010000100001,
        0b0001001001001000
    };
    private void Awake()
    {
        InitDictionary();
    }

    private void InitDictionary()
    {
        _lineData = new Dictionary<int, List<int>>();
        for (ushort i = 0; i < 0xFFFF; i++)
        {
            var count = 0;

            foreach (var pattern in _patterns)
            {
                if ((i & pattern) == pattern)
                {
                    count++;
                }
            }


            if (!_lineData.ContainsKey(count))
            {
                _lineData[count] = new List<int>();
            }
            _lineData[count].Add(i);
        }
    }

    [ContextMenu("Trigger")]
    private void Start()
    {
        var random = Random.Range(0, _lineData[numLine].Count);
        var randomBoolArray = ConvertToBoolArray(_lineData[numLine][random]);
        // 印出布林陣列
        for (var i = 0; i < 4; i++)
        {
            var result = string.Empty;
            for (var j = 0; j < 4; j++)
            {
                result += randomBoolArray[i, j] ? "1 " : "0 ";
            }

            Debug.Log(result);
        }
    }

    private bool[,] ConvertToBoolArray(int number)
    {
        var boolArray = new bool[4, 4];

        for (var row = 0; row < 4; row++)
        {
            for (var col = 0; col < 4; col++)
            {
                // 取得對應位元的值，如果為1，則設為true，否則為false
                boolArray[row, col] = ((number >> (row * 4 + col)) & 1) == 1;
            }
        }

        return boolArray;
    }
}
