Imports System.Net
Imports System.Net.Sockets
Imports System.IO
Imports System.Threading

Module Module1

    Dim objL As TcpListener

    Sub Main()
        Console.WriteLine("It's Server Program.")
        objL = New TcpListener(New IPAddress({127, 0, 0, 1}), 8000)

        objL.Start()
        Console.WriteLine("Listener is running...")

        Dim t As New Thread(New ThreadStart(AddressOf ProcessSession))
        t.Start()

        Dim t2 As New Thread(New ThreadStart(AddressOf ProcessSession))
        t2.Start()

        Console.ReadLine()

    End Sub

    Sub ProcessSession()
        Dim objSocket As Socket = objL.AcceptSocket()
        Console.WriteLine("AcceptSocket, a session started.")

        Dim st As New NetworkStream(objSocket)
        Dim w As New StreamWriter(st)
        w.AutoFlush = True
        Dim r As New StreamReader(st)

        Dim s As String
        Do
            s = r.ReadLine()
            Console.WriteLine("Server got: " + s)
            ' System.Threading.Thread.Sleep(3000)
            w.WriteLine("Hello! " + s)
        Loop While s <> "."

        st.Close()
        objSocket.Close()
    End Sub


End Module


