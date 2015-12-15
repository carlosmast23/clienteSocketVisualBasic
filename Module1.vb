Module Module1

    Sub Main()
        Dim sc As SocketCliente = New SocketCliente("127.0.0.1", 9999)
        Console.WriteLine("presione una tecla para iniciar la conexion ...")
        Console.WriteLine("cliente conectado con el servidor...")
        sc.conectar()
        While True
            Console.WriteLine("Ingrese el mensaje para enviar: ")
            Dim msj As String = Console.ReadLine()
            sc.salida(msj)

            If msj = "EXIT" Then
                Exit While
            Else
                Console.WriteLine(sc.leer())
            End If

        End While

    End Sub

End Module
