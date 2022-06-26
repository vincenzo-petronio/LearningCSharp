// See https://aka.ms/new-console-template for more information
using _015_OOP;

var bank1 = new UnicreditBank();
bank1.Hello();
Console.WriteLine($"{bank1.GetBalance()}");

var bank2 = new BnlBankFree();
bank2.Hello();

//Console.WriteLine($"{bank2.GetBalance()}");
Console.WriteLine($"{bank2.Plan}");


Console.ReadLine();