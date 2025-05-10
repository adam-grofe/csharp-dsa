using System.Collections.Generic;
using Microsoft.VisualBasic;

namespace integer_to_roman;

public class IntToRomanClass
{
    Dictionary<int, string> romanMajors;

    public IntToRomanClass(){
        romanMajors = new Dictionary<int, string>();
        romanMajors.Add(1, "I");
        romanMajors.Add(5, "V");
        romanMajors.Add(10, "X");
        romanMajors.Add(50, "L");
        romanMajors.Add(100, "C");
        romanMajors.Add(500, "D");
        romanMajors.Add(1000, "M");
    }
    public IntToRomanClass(int num) {

    }
}
