Imports System.Net
Imports System.Net.Sockets
Imports System.Text

Public Class SocketCliente
    Private clientSocket As Socket
    Private serverAddress As IPEndPoint
    Private host As String
    Private puerto As Integer

    Public Sub New(ByRef host As String, ByRef puerto As Integer)
        Me.host = host
        Me.puerto = puerto
    End Sub

    Public Sub conectar()
        Try
            Me.serverAddress = New IPEndPoint(IPAddress.Parse(host), puerto)
            Me.clientSocket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
            Me.clientSocket.Connect(Me.serverAddress)
        Catch ex As SocketException
            Throw New Exception("El socket no se pudo conectar")
        End Try


    End Sub

    Public Function leer() As String
        Dim sizeBuffer(1024) As Byte
        Dim tamanio As Integer = clientSocket.Receive(sizeBuffer)
        Dim myString As String = Encoding.UTF8.GetString(sizeBuffer, 0, tamanio)
        Return myString
    End Function

    Public Function salida(ByRef texto As String)
        Dim msg() As Byte = Encoding.UTF8.GetBytes(texto)
        clientSocket.Send(msg)
        Return True
    End Function

    Public Sub desconectar()
        clientSocket.Close()
    End Sub
End Class
