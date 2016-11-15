Imports System.Net
Imports System.Net.Sockets
Imports System.IO

Module Module1

    Sub Main()
        Console.WriteLine("It's Client Program.")

        Dim objC As New TcpClient()
        objC.Connect("127.0.0.1", 8000)
        Dim st As NetworkStream = objC.GetStream()
        Dim w As New StreamWriter(st)
        w.AutoFlush = True
        Dim r As New StreamReader(st)

        Dim s As String
        Do
            Console.Write("Please keyin your name: ")
            s = Console.ReadLine()
            w.WriteLine(s)
            Dim sFromServer As String = r.ReadLine()
            Console.WriteLine("server echo: " + sFromServer)
        Loop While s <> "."
        Console.ReadLine()

    End Sub

End Module
