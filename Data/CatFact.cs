﻿using System.ComponentModel.DataAnnotations;

namespace CatFacts;


[Serializable]
public class CatFact
{
    public string fact { get; set; }
    public int length { get; set; }
}
