using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credit
{
    string _name;
    string _role;
    string? _link;

    public Credit(string line)
    {
        string[] pieces = line.Split(',');
        _name = pieces[0];
        _role = pieces[1];
        if(pieces.Length == 3)
            _link = pieces[2];
    }

    public string Name { get { return _name; } set { _name = value; } }
    public string Role { get { return _role; } set { _role = value; } }
    public string Link { get { return _link; } set { _link = value; } }

    public override string ToString()
    {
        return $"{_name} - {_role}\n";
    }
}
