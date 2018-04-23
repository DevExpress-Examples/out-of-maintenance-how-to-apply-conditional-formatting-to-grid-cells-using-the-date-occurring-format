Imports System
Imports System.Collections.Generic
Imports System.Threading

Namespace Grid_DateOccurring
    Friend Class DataGenerator
        Public Property [Date]() As Date
        Public Property Sales() As Decimal

        Public Shared Function CreateData() As List(Of DataGenerator)
            Dim data As New List(Of DataGenerator)()

            For i As Integer = 0 To 99
                Dim record As New DataGenerator()
                Dim seed As Integer = CLng(Date.Now.Ticks) And &HFFFF
                Dim startDate As New Date(Date.Today.Year, 1, 1)
                Dim rand As New Random()
                Dim range As Integer = (Date.Today.Subtract(startDate)).Days

                record.Sales = (New Random(seed)).Next(0, 1000)
                record.Date = startDate.AddDays(rand.Next(range))
                data.Add(record)
                Thread.Sleep(3)
            Next i
            Return data
        End Function
    End Class
End Namespace
