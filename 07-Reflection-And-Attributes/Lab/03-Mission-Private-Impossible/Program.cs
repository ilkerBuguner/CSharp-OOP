﻿using System;


public class Program
{
    public static void Main(string[] args)
    {
        Spy spy = new Spy();

        var res = spy.RevealPrivateMethods("Hacker");
        Console.WriteLine(res);
    }
}

