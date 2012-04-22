Imports System.Net
Imports System.Net.Sockets
Imports System.Net.NetworkInformation
Imports System.Text
Imports System.ComponentModel

''' <summary>
''' The BarcodeReceiver receives barcodes from the scanner app
''' and raises an event when a barcode has been received.
''' </summary>
''' <remarks></remarks>
Public Class BarcodeReceiver

    Private sck As New Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp)
    Private bInputBuffer(1023) As Byte
    Private epRemote As New IPEndPoint(IPAddress.Any, 0)
    Private WithEvents bw As New BackgroundWorker


    ''' <summary>
    ''' This event is raised when a barcode has been received from the scanner app.
    ''' </summary>
    ''' <param name="Barcode"></param>
    ''' <remarks></remarks>
    Public Event BarcodeReceived(Barcode As String)

    ''' <summary>
    ''' Binds an UDP socket to a free port, and starts the barcode receiver.
    ''' Use GetLocalPort() to get the local port of the UDP socket.
    ''' </summary>
    ''' <returns>True on success and false on failure.</returns>
    ''' <remarks></remarks>
    Public Function Start() As Boolean
        Try
            ' Bind the socket to a free udp port
            sck.Bind(New IPEndPoint(IPAddress.Any, 0))

            ' Start receiving barcodes with a background worker
            bw.RunWorkerAsync()

        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function

    ''' <summary>
    ''' Gets the local port of the UDP socket.
    ''' </summary>
    ''' <returns>An UDP port number as an Integer.</returns>
    ''' <remarks></remarks>
    Public Function GetLocalPort() As Integer
        Return CType(sck.LocalEndPoint, IPEndPoint).Port
    End Function


    ''' <summary>
    ''' This method receives barcodes asynchronous.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub bw_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bw.DoWork
        Dim bBytesReceived As Integer = sck.ReceiveFrom(bInputBuffer, 0, bInputBuffer.Length, SocketFlags.None, epRemote)
        Dim sReceivedString As String = Encoding.UTF8.GetString(bInputBuffer, 0, bBytesReceived)

        If sReceivedString.StartsWith("WiFi Barcode Scanner Barcode") Then
            Dim Parts() As String = sReceivedString.Split("|")

            If Parts IsNot Nothing AndAlso Parts.Length >= 2 Then
                e.Result = Parts
            End If


        End If
    End Sub

    ''' <summary>
    ''' When a barcode has been received, this event is called.
    ''' This event is called on the main thread, so raising our own events here make them thread safe.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub bw_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bw.RunWorkerCompleted
        Dim Parts() As String = e.Result

        'We are back on the main thread, so it is safe to fire the BarcodeReceived event here
        RaiseEvent BarcodeReceived(Parts(1))

        'Keep receiving those barcodes baby!
        bw.RunWorkerAsync()
    End Sub
End Class
