using System;
using System.Collections;
using static System.Console;

#region while
int x = 0;
while (x < 10){
    WriteLine(x);
    x++;
}
#endregion

#region do while
//the block runs at least once, then the condition is checked
string? password;
do{
    Write("Enter your password: ");
    password = ReadLine();
}
while (password != "Pa$$w0rd");
WriteLine("Correct!");
#endregion

#region for
for (int y = 1; y <= 10; y++){
    WriteLine(y);
}
#endregion

#region foreach
string[] names = { "Adam", "Barry", "Charlie" };
foreach (string name in names){
    WriteLine($"{name} has {name.Length} characters.");
}
//this is the same as the previous
IEnumerator e = names.GetEnumerator();
while (e.MoveNext()){
    string name = (string)e.Current; // Current is read-only!
    WriteLine($"{name} has {name.Length} characters.");
}
#endregion
