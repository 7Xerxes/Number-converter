Module Module1
    Function percentString(percent As Double)
        Dim stoppingIndex = 0
        Dim looping As Boolean = True
        Dim controller As Boolean = False
        Dim percStr As String = percent.ToString()
        If Not percStr.Contains(".") Then
            Return percStr + ".00%"
        End If
        While looping
            If percStr(stoppingIndex) = "." Then
                controller = 2
                looping = False
            End If
            stoppingIndex += 1
        End While
        stoppingIndex += 2
        If stoppingIndex > percStr.Length() Then
            stoppingIndex = percStr.Length()
        End If
        Return Left(percStr, stoppingIndex) + ".00%"
    End Function
    Sub Main()
        Dim inp As String
        Console.Write("Enter exam result (0-100): ")
        inp = Integer.Parse(Console.ReadLine())

        'Flag prevents multiple grades from printing
        Dim flag As Boolean = False

        For i As Integer = 0 To 4
            '>80 = A, down 10% per grade
            If inp > (80 - (i * 10)) And Not flag Then
                Console.WriteLine("Your result is a " & Chr(65 + i) & "." & "Percentage is" & percentString(inp / 36))
                flag = True
            End If
        Next

        'If they didn't qualify for a grade.
        If Not flag Then
            Console.WriteLine("You failed.")
        End If

        Console.Write("any key to exit..." & "Percentage is" & percentString(inp / 36))
        Console.ReadLine()
    End Sub
End Module
