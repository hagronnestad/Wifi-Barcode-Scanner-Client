Imports System.Net
Imports System.Net.Sockets
Imports System.Net.NetworkInformation
Imports System.Text

Public Class BroadcastResponder

    Private sck As New Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp)
    Private inputBuffer(1023) As Byte
    Private remoteEndPoint As New IPEndPoint(IPAddress.Any, 0)

    Public softwareVersion As String = ""
    Public computerID As String = ""
    Public barcodeListenerPort As Integer = 0


    Public Function Start(BroadcastResponderPort As Integer, SoftwareVersion As String, ComputerID As String, BarcodeListenerPort As Integer) As Boolean
        Me.softwareVersion = SoftwareVersion
        Me.computerID = ComputerID
        Me.barcodeListenerPort = BarcodeListenerPort

        Try
            sck.EnableBroadcast = True
            sck.Bind(New IPEndPoint(IPAddress.Any, BroadcastResponderPort))
            sck.BeginReceiveFrom(inputBuffer, 0, inputBuffer.Length, SocketFlags.None, remoteEndPoint, New AsyncCallback(AddressOf BroadcastListenerCallback), Nothing)

        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function


    Private Sub BroadcastListenerCallback(ByVal ar As IAsyncResult)
        Dim bytesReceived As Integer = sck.EndReceiveFrom(ar, remoteEndPoint)

        Dim receivedString As String = Encoding.UTF8.GetString(inputBuffer, 0, bytesReceived)

        If receivedString.StartsWith("WiFi Barcode Scanner Broadcast") Then
            Dim parts() As String = receivedString.Split("|")

            If parts IsNot Nothing AndAlso parts.Length = 3 Then
                Debug.WriteLine(String.Format("Responding to broadcast from app with version number {0} ({1}).", parts(1), parts(2)))

                Dim Reply As String = String.Format("WiFi Barcode Scanner Response|{0}|{1}|{2}", Me.softwareVersion, Me.computerID, Me.barcodeListenerPort)
                sck.SendTo(Encoding.UTF8.GetBytes(Reply), SocketFlags.None, remoteEndPoint)
                Debug.WriteLine("Reply sent.")
            End If

        End If


        sck.BeginReceiveFrom(inputBuffer, 0, inputBuffer.Length, SocketFlags.None, remoteEndPoint, AddressOf BroadcastListenerCallback, Nothing)
    End Sub

End Class
