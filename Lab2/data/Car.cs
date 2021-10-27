using System;
using Newtonsoft.Json;
using System.IO;
using CSharp_Utils;
using System.Reflection;
class Car
{
    public int Weight { get; set; }
    public int Length { get; set; }
    public int MaxSpeed { get; set; }
    public int DoorsCount { get; set; }
    public int Height { get; set; }
}