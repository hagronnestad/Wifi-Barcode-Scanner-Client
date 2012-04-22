Imports System.Net.Sockets
Imports System.Net
Imports System.Text
Imports System.Threading

Public Class Server
    Private sckDiscovery As New Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp)
    Private sckServer As New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)

    Private sckClient As Socket
    Private rBuffer(0) As Byte

    Public Event BarcodeRead(ByVal Barcode As String)


    Public Sub StartServer()
        sckServer.Bind(New IPEndPoint(IPAddress.Any, 0))
        sckServer.Listen(1000)
        sckServer.BeginAccept(AddressOf _CallbackBeginAccept, sckServer)
    End Sub

    Private Sub _CallbackBeginAccept(ByVal ar As IAsyncResult)
        Dim NewSocket As Socket = CType(ar.AsyncState, Socket).EndAccept(ar)

        If Not sckClient Is Nothing AndAlso sckClient.Connected Then sckClient.Close()
        sckClient = NewSocket

        Dim T As New Thread(AddressOf WaitForBarcode)
        T.Start()


        sckServer.BeginAccept(AddressOf _CallbackBeginAccept, sckServer)
    End Sub

    Private Sub WaitForBarcode()
        Dim l As Integer = 0
        Dim BarCode As String = ""

        Try
            While ((l = sckClient.Receive(rBuffer, 1, SocketFlags.None)) > -1)
                Dim C As String = Encoding.ASCII.GetString(rBuffer)

                Select Case C
                    Case "|"
                        RaiseEvent BarcodeRead(BarCode)

                        Dim T As New Thread(AddressOf WaitForBarcode)
                        T.Start()


                        Exit While


                    Case Else
                        BarCode &= C
                End Select

            End While

        Catch ex As Exception

        End Try
    End Sub



    Public Sub StartDiscoveryDaemon()
        'Starting the DiscoveryDaemon in a new thread causes the application to crash in Windows XP (not in Windows 7).
        'Solution: Don't run in a new thread, the code doesn't block anyway, as it uses asynchronous methods.
        'Dim T As New Thread(AddressOf StartDiscovery)
        'T.Start()

        StartDiscovery()
    End Sub


    Dim Buf(1023) As Byte
    Dim ep As New IPEndPoint(IPAddress.Any, 0)

    Private Sub StartDiscovery()
        sckDiscovery.EnableBroadcast = True
        sckDiscovery.Bind(New IPEndPoint(IPAddress.Any, 50123))

        sckDiscovery.BeginReceiveFrom(Buf, 0, Buf.Length, SocketFlags.None, ep, New AsyncCallback(AddressOf sckListen_ReceiveCallbak), Nothing)
    End Sub

    Public Sub sckListen_ReceiveCallbak(ByVal ar As IAsyncResult)
        Dim BytesReceived As Integer = sckDiscovery.EndReceiveFrom(ar, ep)

        Debug.WriteLine("Client discovered.")

        Dim Reply As String = String.Format("{0}|{1}|{2}", My.Computer.Name, My.Settings.txtComputerID, CType(sckServer.LocalEndPoint, IPEndPoint).Port)
        sckDiscovery.SendTo(Encoding.ASCII.GetBytes(Reply), SocketFlags.None, ep)

        Debug.WriteLine("Reply sent.")

        sckDiscovery.BeginReceiveFrom(Buf, 0, Buf.Length, SocketFlags.None, ep, AddressOf sckListen_ReceiveCallbak, Nothing)

    End Sub
End Class
