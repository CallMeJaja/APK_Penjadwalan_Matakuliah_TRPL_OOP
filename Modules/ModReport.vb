Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports MySql.Data.MySqlClient

''' <summary>
''' Module untuk menangani integrasi Crystal Reports.
''' Menangani login database dan pengiriman parameter ke report.
''' </summary>
Module ModReport

    ''' <summary>
    ''' Mengonfigurasi koneksi database untuk objek ReportDocument.
    ''' </summary>
    ''' <param name="rpt">Objek report yang akan dikonfigurasi</param>
    Public Sub ConfigureReportConnection(rpt As ReportDocument)
        Dim connectionInfo As New ConnectionInfo()
        
        connectionInfo.ServerName = ModKoneksi.Server & ":" & ModKoneksi.Port
        connectionInfo.UserID = ModKoneksi.User
        connectionInfo.Password = ModKoneksi.Password
        connectionInfo.DatabaseName = ModKoneksi.Database
        connectionInfo.Type = ConnectionInfoType.SQL
        
        For Each subRpt As ReportDocument In rpt.Subreports
            ApplyLogonInfo(subRpt, connectionInfo)
        Next
        
        ApplyLogonInfo(rpt, connectionInfo)
    End Sub

    ''' <summary>
    ''' Menerapkan informasi login ke setiap tabel dalam sebuah ReportDocument.
    ''' </summary>
    ''' <param name="rpt">Objek report.</param>
    ''' <param name="connInfo">Informasi koneksi database.</param>
    Private Sub ApplyLogonInfo(rpt As ReportDocument, connInfo As ConnectionInfo)
        Dim tableLogOnInfo As New TableLogOnInfo()
        tableLogOnInfo.ConnectionInfo = connInfo

        For Each tbl As Table In rpt.Database.Tables
            tbl.ApplyLogOnInfo(tableLogOnInfo)
        Next
    End Sub

    ''' <summary>
    ''' Mengirim parameter ke report secara aman.
    ''' </summary>
    ''' <param name="rpt">Objek report</param>
    ''' <param name="paramName">Nama parameter di Crystal Report</param>
    ''' <param name="val">Nilai yang akan dikirim</param>
    Public Sub SetReportParam(rpt As ReportDocument, paramName As String, val As Object)
        Try
            rpt.SetParameterValue(paramName, val)
        Catch ex As Exception
            Debug.WriteLine($"Parameter {paramName} tidak ditemukan di report.")
        End Try
    End Sub

End Module
